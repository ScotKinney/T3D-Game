function PVCMountDlg::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
      Canvas.pushDialog(%this);
}

function PVCMountDlg::onWake(%this)
{
   %this.updateMountsList();
}

function PVCMountDlg::updateMountsList(%this)
{
   // Empty the text control
   PVCMountList.clear();
   
   %numMounts = $currentPVC.getNumMounts();
   for ( %i = 0; %i < %numMounts; %i++ )
   {
      %nodeName = $currentPVC.getMountSlotName(%i);
      %shapeName = $currentPVC.getMountShapeName(%i);
      PVCMountList.addRow(%i, %nodeName TAB fileName(%shapeName));
   }
   
   if ( %numMounts == 0 )
   {
      PVCMountList.addRow(%i, "No Shapes Mounted" TAB " ");
      PVCMountClearBtn.setActive(false);
   }
   else
      PVCMountClearBtn.setActive(true);
}

function PVCMountDlg::AddMount(%this)
{
   PVCNodeDlg.isAddDlg = true;
   Canvas.pushDialog(PVCNodeDlg);
}

function PVCMountDlg::ClearNode(%this)
{
   PVCNodeDlg.isAddDlg = false;
   Canvas.pushDialog(PVCNodeDlg);
}


function PVCMountDlg::saveSettings(%this, %file)
{  // Save all settings needed to restore the window to it's current state
   //%file.WriteLine("PVCCaptureDlg.captureFormat = \"" @ %this.captureFormat @ "\";" );

   // save the position and size.
   /*%pos = MeshControlDlg.getPosition();
   %ext = MeshControlDlg.getExtent();
   %file.WriteLine("MeshControlDlg.setPosition(" @ getWord(%pos, 0) @ ", " @ getWord(%pos, 1) @ ");");
   %file.WriteLine("MeshControlDlg.setExtent(" @ getWord(%ext, 0) @ ", " @ getWord(%ext, 1) @ ");");*/
}
