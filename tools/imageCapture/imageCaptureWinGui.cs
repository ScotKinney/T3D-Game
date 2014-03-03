
// Load all script and guis needed by the image capture tool
exec("./pvcProfiles.cs");
exec("./gui/imageCaptureWin.gui");
exec("./gui/pvcAnimation.gui");
exec("./gui/pvcMeshes.gui");
exec("./gui/pvcCaptureSettings.gui");
exec("./gui/pvcMounts.gui");
exec("./gui/pvcNode.gui");
exec("./gui/pvcSkins.gui");
exec("./gui/pvcTexture.gui");
exec("./gui/pvcLighting.gui");
exec("./gui/pvcPreviewWin.gui");
exec("./gui/pvcGroundSpeed.gui");

exec("./pvcAnimationGui.cs");
exec("./pvcMeshesGui.cs");
exec("./pvcCaptureSettingsGui.cs");
exec("./pvcMountsGui.cs");
exec("./pvcSkinsGui.cs");
exec("./pvcTextureGui.cs");
exec("./pvcLightingGui.cs");
exec("./pvcNodeGui.cs");
exec("./pvcGroundSpeedGui.cs");

function ImageCaptureWin::onWake(%this)
{
   // If the right mouse button was bound, unbind it but remember the state so
   // it can be restored in onSleep
   %this.rightMouseBind = globalActionMap.getCommand(mouse, button1);
   if ( %this.rightMouseBind !$= "" )
      globalActionMap.unbind( mouse, button1);

   // Assign the player view control to a global var so the control guis know 
   // where to send their input.
   $currentPVC = icModelViewCtrl;
   
   // Load any saved settings
   if ( isFile("tools/imageCapture/icData.cs") )
      exec("tools/imageCapture/icData.cs");

   // Setup the background and image capture settings
   PVCCaptureDlg.initSettings();
   
   // Setup our scene lights
   PVCLightingDlg.setupAllLights();

   // Install the current shape   
   %this.UpdateShapeDisplay();
   Canvas.pushDialog(PVCPreviewDlg);
   Canvas.popDialog(PVCPreviewDlg);
}

function ImageCaptureWin::onSleep(%this)
{
   // Close any control windows that may be left open
   if (PVCCaptureDlg.isAwake())
      Canvas.popDialog(PVCCaptureDlg);
   if (PVCAnimationDlg.isAwake())
      Canvas.popDialog(PVCAnimationDlg);
   if (PVCMeshDlg.isAwake())
      Canvas.popDialog(PVCMeshDlg);
   if (PVCMountDlg.isAwake())
      Canvas.popDialog(PVCMountDlg);
   if (PVCSkinDlg.isAwake())
      Canvas.popDialog(PVCSkinDlg);
   if (PVCLightingDlg.isAwake())
      Canvas.popDialog(PVCLightingDlg);
   if (PVCGroundDlg.isAwake())
      Canvas.popDialog(PVCGroundDlg);

   // Delete any materials created by the skins window
      
   // Save the current settings
   %this.saveICSettings();
   
   // restore the right mouse bind
   if ( %this.rightMouseBind !$= "" )
      globalActionMap.bind(mouse, button1, %this.rightMouseBind);
}

function ImageCaptureWin::saveICSettings(%this)
{
   // Save all settings needed to restore the window to it's current state
   %file = new FileObject();      
   if(isObject(%file))
   {
      %file.openForWrite("tools/imageCapture/icData.cs");
      
      // Shape file
      %file.WriteLine("ImageCaptureWin.shapePath = \"" @ %this.shapePath @ "\";" );
      
      // Now give each control window a chance to save settings
      PVCCaptureDlg.saveSettings(%file);
      PVCAnimationDlg.saveSettings(%file);
      PVCMeshDlg.saveSettings(%file);
      PVCMountDlg.saveSettings(%file);
      PVCSkinDlg.saveSettings(%file);
      PVCLightingDlg.saveSettings(%file);
      
      %file.close();
      %file.delete();
   }
}

function ImageCaptureWin::OnCaptureBtn(%this)
{  // Capture the current framed image
   %formatID = PVCFormatList.getSelected();
   if ( (%formatID == 0) && (PVCCaptureDlg.useOverlayBmp || (PVCCaptureDlg.backgroundMode == 0)) )
   {  // We can't write alpha to a jpg
      MessageBoxOK("Alpha Not Supported", "Torque does not support writting an alpha channel to a jpg, switching to png.");
      %formatID = 1;
      PVCCaptureDlg.captureFormat = "PNG";
      PVCFormatList.setSelected(1);
   }
   %formatStr = (%formatID == 0) ? ".jpg" : ".png";
   
   // Make sure the format is current
   SSCaptureFrame.captureFormat = %formatStr;
   
   %fileName = "tools/imageCapture/preview";
   
   // If we're doing full alpha with a bitmap background, pass the bitmap control
   %hideControl = (PVCCaptureDlg.isFullAlpha && (PVCCaptureDlg.backgroundMode == 1)) ? icBitmapBackground : "";

   // Take the screen shot
   SSCaptureFrame.captureFrame( %fileName, icModelViewCtrl, PVCCaptureDlg.isFullAlpha, GuiICBackgroundProfile, %hideControl );
   
   if ( !PVCCaptureDlg.useOverlayBmp && (PVCCaptureDlg.backgroundMode != 0) )
      SSCaptureFrame.schedule(500, "onCaptureDone");
}

function ImageCaptureWin::OnShapeBtn(%this)
{  // Bring up the load dialog to let the user select a new base shape
   getLoadFilename( "Shape Files|*.dts;*.dae|DTS Files|*.dts|COLLADA Files|*.dae", %this @ ".onShapeSelect", %this.shapePath);
}

function ImageCaptureWin::onShapeSelect(%this, %path)
{
   if ( (%path $= "") || (%path $= %this.shapePath) )
      return;  // Nothings changed

   %path = makeRelativePath( %path, getMainDotCSDir() );
   %this.shapePath = %path;
   %this.UpdateShapeDisplay();
}

function ImageCaptureWin::OnCapSettingsBtn(%this)
{  // Toggle the capture settings dialog
   PVCCaptureDlg.toggle();
}

function ImageCaptureWin::OnAnimationsBtn(%this)
{  // Toggle the animation control window
   PVCAnimationDlg.toggle();
}

function ImageCaptureWin::OnMeshesBtn(%this)
{  // Toggle the Meshes window
   PVCMeshDlg.toggle();
}

function ImageCaptureWin::OnMountsBtn(%this)
{  // Toggle the mount shape dialog
   PVCMountDlg.toggle();
}

function ImageCaptureWin::OnReskinBtn(%this)
{  // Bring up the material reskinning dialog
   PVCSkinDlg.toggle();
}

function ImageCaptureWin::OnLightsBtn(%this)
{  // Bring up the lighting dialog
   PVCLightingDlg.toggle();
}

function ImageCaptureWin::OnGroundSpeedBtn(%this)
{  // Bring up the ground speed dialog
   PVCGroundDlg.toggle();
}

function ImageCaptureWin::UpdateShapeDisplay(%this)
{
   // Put the shape into the view control
   icModelViewCtrl.setModel(%this.shapePath);
   
   // Update all control guis to show the correct options for this shape
   PVCAnimationDlg.initThreadLists();
   PVCMeshDlg.updateMeshList();
   PVCMountDlg.updateMountsList();
   PVCSkinDlg.updateSkinsList();
   PVCGroundDlg.updateNodeList();
}
