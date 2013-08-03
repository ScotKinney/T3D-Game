function PVCLightingDlg::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
      Canvas.pushDialog(%this);
}

function PVCLightingDlg::onWake(%this)
{
}

function PVCLightingDlg::onUseLightBtn(%this, %lightNum)
{
   if ( %lightNum == 0 )
      return;  // Can't turn off the main light
      
   $currentPVC.setLightOn(%lightNum, %this.useLight[%lightNum]);
}

function PVCLightingDlg::onColorSwatch(%this, %colorCtrl, %oldColor, %lightNum)
{
   %this.curLightNum = %lightNum;
   %this.curColorCtrl = %colorCtrl;
   GetColorF( %oldColor, %this.getId() @ ".colorPicked", %this.getRoot() );
}

function PVCLightingDlg::colorPicked(%this, %color)
{
   %this.lightColor[%this.curLightNum] = %color;
   %this.curColorCtrl.color = %color;
   
   $currentPVC.setLightColor(%this.curLightNum, %color);
}

function PVCLightingDlg::onBrightnessChange(%this, %controlID, %lightNum)
{
   %curBrightnessVal = %controlID.getText();
   %this.brightness[%lightNum] = %curBrightnessVal;

   $currentPVC.setLightBrightness(%lightNum, %curBrightnessVal);
}

function PVCLightingDlg::onDirChangeX(%this, %controlID, %lightNum)
{
   %curVal = %controlID.getText();
   %this.lightDirX[%lightNum] = %curVal;
   %this.updateLightDir(%lightNum);
}

function PVCLightingDlg::onDirChangeY(%this, %controlID, %lightNum)
{
   %curVal = %controlID.getText();
   %this.lightDirY[%lightNum] = %curVal;
   %this.updateLightDir(%lightNum);
}

function PVCLightingDlg::onDirChangeZ(%this, %controlID, %lightNum)
{
   %curVal = %controlID.getText();
   %this.lightDirZ[%lightNum] = %curVal;
   %this.updateLightDir(%lightNum);
}

function PVCLightingDlg::updateLightDir(%this, %lightNum)
{
   %direction = %this.lightDirX[%lightNum] SPC %this.lightDirY[%lightNum] SPC %this.lightDirZ[%lightNum];
   
   $currentPVC.setLightDir(%lightNum, %direction);
}

function PVCLightingDlg::setupAllLights(%this)
{
   for ( %i = 0; %i < 4; %i++ )
   {
      $currentPVC.setLightOn(%i, %this.useLight[%i]);
      $currentPVC.setLightColor(%i, %this.lightColor[%i]);
      nameToID("PVCLightColorCtrl" @ %i).color = %this.lightColor[%i];
      $currentPVC.setLightBrightness(%i, %this.brightness[%i]);

      %direction = %this.lightDirX[%i] SPC %this.lightDirY[%i] SPC %this.lightDirZ[%i];
      $currentPVC.setLightDir(%i, %direction);
   }
}

function PVCLightingDlg::saveSettings(%this, %file)
{  // Save all settings needed to restore the window to it's current state
   for ( %i = 0; %i < 4; %i++ )
   {
      %file.WriteLine("PVCLightingDlg.useLight" @ %i @ " = \"" @ %this.useLight[%i] @ "\";" );
      %file.WriteLine("PVCLightingDlg.brightness" @ %i @ " = \"" @ %this.brightness[%i] @ "\";" );
      %file.WriteLine("PVCLightingDlg.lightColor" @ %i @ " = \"" @ %this.lightColor[%i] @ "\";" );
      %file.WriteLine("PVCLightingDlg.lightDirX" @ %i @ " = \"" @ %this.lightDirX[%i] @ "\";" );
      %file.WriteLine("PVCLightingDlg.lightDirY" @ %i @ " = \"" @ %this.lightDirY[%i] @ "\";" );
      %file.WriteLine("PVCLightingDlg.lightDirZ" @ %i @ " = \"" @ %this.lightDirZ[%i] @ "\";" );
   }

   // save the position and size.
   /*%pos = MeshControlDlg.getPosition();
   %ext = MeshControlDlg.getExtent();
   %file.WriteLine("MeshControlDlg.setPosition(" @ getWord(%pos, 0) @ ", " @ getWord(%pos, 1) @ ");");
   %file.WriteLine("MeshControlDlg.setExtent(" @ getWord(%ext, 0) @ ", " @ getWord(%ext, 1) @ ");");*/
}
