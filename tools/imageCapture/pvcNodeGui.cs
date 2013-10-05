function PVCNodeDlg::onWake(%this)
{
   %this.updateNodeList();
   
   PVCNodeShapeText.setVisible(%this.isAddDlg);
   PVCNodeShapeName.setVisible(%this.isAddDlg);
   PVCMountBrowseBtn.setVisible(%this.isAddDlg);
   PVCNodeShapeName.setActive(false);
   PVCNodeShapeName.setText(%this.shapeName);
   
   if ( %this.isAddDlg )
      PVCNodeActionBtn.setText("Mount Shape");
   else
      PVCNodeActionBtn.setText("Clear Node");
}

function PVCNodeDlg::updateNodeList(%this)
{
   // Empty the text control
   PVCNodeList.clear();
   
   %numNodes = $currentPVC.GetNumNodes();
   if ( (%this.nodeSelection $= "") || (%this.nodeSelection < 0) || 
         (%this.nodeSelection >= %numNodes) )
      %this.nodeSelection = 0;

   for ( %i = 0; %i < %numNodes; %i++ )
   {
      %nodeName = $currentPVC.GetNodeName(%i);
      PVCNodeList.add( %nodeName, %i );
   }

   PVCNodeList.setSelected(%this.nodeSelection);
   PVCNodeList.sort();
}

function PVCNodeDlg::ChangeNodeSel(%this)
{
   %this.nodeSelection = PVCNodeList.getSelected();
}

function PVCNodeDlg::onShapeBrowse(%this)
{  // Let the user browse for a suitable overlay bitmap.
   getLoadFilename( "Shape Files|*.dts;*.dae|DTS Files|*.dts|COLLADA Files|*.dae", %this @ ".onShapeSelect", %this.shapePath);
}

function PVCNodeDlg::onShapeSelect(%this, %path)
{
   if ( (%path $= "") || (%path $= %this.shapePath) )
      return;  // Nothings changed

   %path = makeRelativePath( %path, getMainDotCSDir() );
   %this.shapePath = %path;
   %this.shapeName = fileName(%path);
   PVCNodeShapeName.setText(%this.shapeName);
}

function PVCNodeDlg::onActionButton(%this)
{
   %nodeName = PVCNodeList.getText();
   if ( %this.isAddDlg )
   {
      $currentPVC.mountEquipment(%this.shapePath, %nodeName);
   }
   else
   {
      $currentPVC.unmountEquipment(%nodeName);
   }
   
   PVCMountDlg.updateMountsList();
   PVCSkinDlg.updateSkinsList();
   Canvas.popDialog(%this);
}
