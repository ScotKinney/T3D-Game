function PVCAnimationDlg::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
   {
      Canvas.pushDialog(%this);
      //AnimControlDlg.setPositionGlobal(getWord(AnimControlDlg.lastPos, 0), getWord(AnimControlDlg.lastPos, 1));
   }
}

function PVCAnimationDlg::initThreadLists(%this)
{  // Fill in the thread list boxes with the animation sequence names
   // Clear the current contents
   PVCActionList.clear();
   PVCLookList.clear();
   PVCBlendList.clear();
   %actionThreadFound = false;
   %lookThreadFound = false;
   %blendThreadFound = false;
   PVCBlendList.add( "<None Selected>", -1 );
   
   %numThreads = $currentPVC.GetNumSequences();
   for ( %i = 0; %i < %numThreads; %i++ )
   {  // Loop through all names and put in the correct list box
      %curName = $currentPVC.GetSequenceName( %i );
      
      if ( (strpos(strlwr(%curName), "look") != -1) || (strpos(strlwr(%curName), "pistol", 1) != -1) )
         PVCLookList.add( %curName, %i );
      else
         PVCActionList.add( %curName, %i );

      PVCBlendList.add( %curName, %i );
      
      if ( %this.PVCSeqName[0] $= %curName )
         %actionThreadFound = true;
      if ( %this.PVCSeqName[1] $= %curName )
         %lookThreadFound = true;
      if ( %this.PVCSeqName[2] $= %curName )
         %blendThreadFound = true;
   }
   
   if ( %actionThreadFound == false )
   {
      PVCActionList.setFirstSelected();
      %threadID = PVCActionList.getSelected();
      %this.PVCSeqName[0] = PVCActionList.getTextById(%threadID);
   }
   
   if ( %lookThreadFound == false )
   {
      PVCLookList.setFirstSelected();
      %threadID = PVCLookList.getSelected();
      %this.PVCSeqName[1] = PVCLookList.getTextById(%threadID);
   }

   if ( %blendThreadFound == false )
   {
      PVCBlendList.setFirstSelected();
      %threadID = PVCBlendList.getSelected();
      %this.PVCSeqName[2] = PVCBlendList.getTextById(%threadID);
   }
   
   PVCActionList.sort();
   PVCLookList.sort();
   PVCBlendList.sort();

   PVCActionList.setText(%this.PVCSeqName[0]);
   PVCLookList.setText(%this.PVCSeqName[1]);
   PVCBlendList.setText(%this.PVCSeqName[2]);
   
   %this.setupThread(0);
   %this.setupThread(1);
   %this.setupThread(2);
   
   %this.InitAnimationButtons();
}

function PVCAnimationDlg::InitAnimationButtons(%this)
{
   for ( %i = 0; %i < 3; %i++ )
   {
      switch$ ( %this.PVCThreadState[%i] )
      {
         case "play":
            NameToID("PVCPlayButton" @ %i).performClick();
         case "pause":
            NameToID("PVCPauseButton" @ %i).performClick();
         case "stop":
            NameToID("PVCStopButton" @ %i).performClick();
      }
   }
}

function PVCAnimationDlg::setupThread(%this, %threadID)
{
   NameToID("PauseTimeVal" @ %threadID).SetText("");
   if ( %this.PVCThreadState[%threadID] $= "stop" )
      return; // Don't start the thread
      
   if ( %this.PVCThreadState[%threadID] $= "pause" )
      %scaleVal = "0.0"; // Time scale set to 0 because the thread is paused.
   else
      %scaleVal = %this.PVCScaleVal[%threadID];
      
   $currentPVC.SetThread(%threadID, %this.PVCSeqName[%threadID],
                         %this.PVCStartPos[%threadID], %scaleVal);
}

function PVCAnimationDlg::pauseThread(%this, %threadID)
{
   %this.PVCThreadState[%threadID] = "pause";
   %curPos = $currentPVC.PauseThread(%threadID);

   if ( %curPos > -1 )
   {
      NameToID("AnimStartVal" @ %threadID).SetText(%curPos);
      %curTime = $currentPVC.GetThreadTime(%threadID);
      NameToID("PauseTimeVal" @ %threadID).SetText(%curTime @ " seconds.");
   }
   else
      %this.setupThread( %threadID );
}

function PVCAnimationDlg::saveSettings(%this, %file)
{  // Save all settings needed to restore the window to it's current state
   for ( %i = 0; %i < 3; %i++ )
   {
      %file.WriteLine("PVCAnimationDlg.PVCSeqName" @ %i @ " = \"" @ %this.PVCSeqName[%i] @ "\";" );
      %file.WriteLine("PVCAnimationDlg.PVCThreadState" @ %i @ " = \"" @ %this.PVCThreadState[%i] @ "\";" );
      %file.WriteLine("PVCAnimationDlg.PVCStartPos" @ %i @ " = \"" @ %this.PVCStartPos[%i] @ "\";" );
      %file.WriteLine("PVCAnimationDlg.PVCScaleVal" @ %i @ " = \"" @ %this.PVCScaleVal[%i] @ "\";" );
   }
   
   // save the position
   %file.WriteLine("AnimControlDlg.lastPos = \"" @ AnimControlDlg.lastPos @ "\";" );
}

function AnimControlDlg::onSleep(%this)
{
   %pos = %this.getPosition();
   %this.lastPos = %pos;
}

function AnimControlDlg::onWake(%this)
{
   %pos = %this.getPosition();
   %this.position = %this.lastPos;
   //%this.lastPos = %pos;
}

//Cape_Spartan
//B_LShin|B_RShin
//BM_SpartanCape
//Briefs_Spartan
//B_LShin|B_RShin
//SpartanBriefs