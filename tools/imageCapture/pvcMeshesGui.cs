function PVCMeshDlg::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
      Canvas.pushDialog(%this);
}

function PVCMeshDlg::updateMeshList(%this)
{
   %numMeshes = $currentPVC.GetNumMeshes();
   %numControls = MeshControlDlg-->checkBoxArray.GetCount();

   // Make sure we have the right number of controls in the array
   if ( %numControls > %numMeshes )
   {  // Too many controls, delete them all and start over
      MeshControlDlg-->checkBoxArray.deleteAllObjects();
      %numControls = 0;
   }
   
   for (%i = %numControls; %i < %numMeshes; %i++)
   {
      %this.addNewMeshControl(%i);
   }
   
   // Now that we have the correct number of controls, fill in the text and value for each
   for (%i = 0; %i < %numMeshes; %i++)
   {
      %meshStatus = $currentPVC.GetMeshVisibility(%i);
      %meshName = getField(%meshStatus, 0);
      %visVal = getField(%meshStatus, 1);
      MeshControlDlg-->checkBoxArray.getObject(%i).setText( %meshName );
      MeshControlDlg-->checkBoxArray.getObject(%i).setValue( (%visVal $= "true") ? 1 : 0 );
   }
   
   // Now fill in the LOD box
   %numDetails = $currentPVC.GetNumDetails();
   echo("Num Details = " @ %numDetails );
   PVCMeshLODList.Clear();
   for ( %i = 0; %i < %numDetails; %i++ )
   {
      %detailSize = $currentPVC.GetDetailSize(%i);
      echo("Detail Size = " @ %detailSize);
      PVCMeshLODList.add( %detailSize, %i );
   }
   if ( (%this.PVCDetailLevel $= "") || (%this.PVCDetailLevel < 0) || 
         (%this.PVCDetailLevel >= %numDetails) )
      %this.PVCDetailLevel = 0;
   $currentPVC.SetCurrentDetail(%this.PVCDetailLevel);
   PVCMeshLODList.setSelected(%this.PVCDetailLevel);
}

function PVCMeshDlg::ChangeMeshLOD(%this)
{
   %this.PVCDetailLevel = PVCMeshLODList.getSelected();
   $currentPVC.SetCurrentDetail(PVCMeshLODList.getSelected());
}

function PVCMeshDlg::onBaseMeshBtn(%this)
{
   $currentPVC.ShowModelSkin();
   $currentPVC.UpdateMeshStates();

   %numMeshes = $currentPVC.GetNumMeshes();
   for (%i = 0; %i < %numMeshes; %i++)
   {
      %meshStatus = $currentPVC.GetMeshVisibility(%i);
      %visVal = getField(%meshStatus, 1);
      MeshControlDlg-->checkBoxArray.getObject(%i).setValue( (%visVal $= "true") ? 1 : 0 );
   }
}

function PVCMeshDlg::addNewMeshControl(%this, %meshIndex)
{
   // Create an instance of the control
   %newCtrlID = new GuiCheckBoxCtrl() {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "GuiCheckBoxProfile";
      //Profile = "GuiCheckboxListProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "226 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      Command = "PVCMeshDlg.meshStateChange(" @ %meshIndex @ ");";
      tooltipprofile = "GuiToolTipProfile";
      hovertime = "1000";
      text = "";
      groupNum = "-1";
      buttonType = "ToggleButton";
      useMouseEvents = "0";
      useInactiveState = "0";
   };

   // Add it to the control array
   MeshControlDlg-->checkBoxArray.addGuiControl(%newCtrlID);
}

function PVCMeshDlg::meshStateChange(%this, %meshIndex)
{  // Toggle the nesh visibility status for the selected mesh
   %meshStatus = $currentPVC.GetMeshVisibility(%meshIndex);
   %meshName = getField(%meshStatus, 0);
   %visVal = getField(%meshStatus, 1);

   $currentPVC.hideMesh( %meshName, (%visVal $= "true") ? true : false );
}

function PVCMeshDlg::saveSettings(%this, %file)
{  // Save all settings needed to restore the window to it's current state
   // save the position and size.
   %file.WriteLine("PVCMeshDlg.PVCDetailLevel = \"" @ %this.PVCDetailLevel @ "\";" );
   /*%pos = MeshControlDlg.getPosition();
   %ext = MeshControlDlg.getExtent();
   %file.WriteLine("MeshControlDlg.setPosition(" @ getWord(%pos, 0) @ ", " @ getWord(%pos, 1) @ ");");
   %file.WriteLine("MeshControlDlg.setExtent(" @ getWord(%ext, 0) @ ", " @ getWord(%ext, 1) @ ");");*/
}

/*function showPVCMatEditor(%val)
{
   if (%val)
   {
      if ( MatEdPropertiesWindow.isAwake() )
         Canvas.popDialog(MatEdPropertiesWindow);
      else
      {
         if ( !isObject( MaterialEd ) )
            MaterialEd::open();
         Canvas.pushDialog(MatEdPropertiesWindow);
      }
   }
}
GlobalActionMap.bind( keyboard, "ctrl F11", showPVCMatEditor );*/
