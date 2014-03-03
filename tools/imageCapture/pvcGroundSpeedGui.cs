function PVCGroundDlg::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
      Canvas.pushDialog(%this);
}

function PVCGroundDlg::onWake(%this)
{
   %this.updateNodeList();
}

function PVCGroundDlg::updateNodeList(%this)
{
   // Empty the list control
   PVCGSNodeList.clear();
   
   %numNodes = $currentPVC.GetNumNodes();
   if ( (%this.nodeSelection $= "") || (%this.nodeSelection < 0) || 
         (%this.nodeSelection >= %numNodes) )
      %this.nodeSelection = 0;

   for ( %i = 0; %i < %numNodes; %i++ )
   {
      %nodeName = $currentPVC.GetNodeName(%i);
      PVCGSNodeList.add( %nodeName, %i );
   }

   PVCGSNodeList.setSelected(%this.nodeSelection);
   PVCGSNodeList.sort();
}

function PVCGroundDlg::ChangeNodeSel(%this)
{
   %this.nodeSelection = PVCGSNodeList.getSelected();
   %nodeName = PVCGSNodeList.getText();
   $currentPVC.setGSMeasurementNode(%nodeName);
}

function PVCGroundDlg::ResetValues(%this)
{
   $currentPVC.resetGSValues();
}

function PVCGroundDlg::UpdateValues(%this)
{
   %animDur = $currentPVC.getActionDurration();
   %animName = PVCAnimationDlg.PVCSeqName[0];
   %outText = "Animation: " @ %animName @ ", Durration: " @ %animDur;
   %this-->AnimText.setText(%outText);
   echo("\n");
   echo(%outText);
   
   %xRange = $currentPVC.XMax - $currentPVC.XMin;
   %yRange = $currentPVC.YMax - $currentPVC.YMin;
   %outText = "XMin: " @ $currentPVC.XMin @ ", XMax: " @ $currentPVC.XMax @ ", XRange " @ %xRange;
   %this-->XRangeText.setText(%outText);
   echo(%outText);
   %outText = "YMin: " @ $currentPVC.YMin @ ", YMax: " @ $currentPVC.YMax @ ", YRange " @ %yRange;
   %this-->YRangeText.setText(%outText);
   echo(%outText);

   %xSpeed = 0;
   %ySpeed = 0;
   if ( %animDur > 0 )
   {
      %xSpeed = %xRange;
      %ySpeed = %yRange;
   }
   %outText = "XSpeed = " @ %xSpeed @ "/s, YSpeed = " @ %ySpeed @ "/s";
   %this-->GSText.setText(%outText);
   echo(%outText);
   echo("\n");
}
