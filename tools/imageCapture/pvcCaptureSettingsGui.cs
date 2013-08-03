function PVCCaptureDlg::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
      Canvas.pushDialog(%this);
}

function PVCCaptureDlg::initSettings(%this)
{
   // fill in the capture format options
   PVCFormatList.Clear();
   PVCFormatList.add( "JPG", 0 );
   PVCFormatList.add( "PNG", 1 );
   PVCFormatList.setSelected(%this.captureFormat $= "JPG" ? 0 : 1);
   %this.onUseOverlayBtn();
   
   PVCOverlayName.setActive(false); // sorry you can't type in the file names
   PVCBackroundName.setActive(false);
   
   // Set our initial text values
   PVCBackroundName.setText(%this.bitmapName);
   %this.updateColors();
   %this.updateBackgroundDims();

   // Fill in the background options
   if (%this.backgroundMode == 0) 
      PVCSolidColorBtn.setStateOn(true);
   else
      PVCBitmapBtn.setStateOn(true);
      
   if (%this.bitmapMode == 0) 
      PVCBackFSBtn.setStateOn(true);
   else if (%this.bitmapMode == 1) 
      PVCBackBDBtn.setStateOn(true);
   else
      PVCBackCustBtn.setStateOn(true);
   
   %this.onBackgroundModeBtn(%this.backgroundMode);
}

function PVCCaptureDlg::onUseOverlayBtn(%this)
{  // The overlay button has been clicked, set availability of input fields
   PVCOverlayBrowseBtn.setActive(%this.useOverlayBmp);
   PVCCaptXDim.setActive(!%this.useOverlayBmp);
   PVCCaptYDim.setActive(!%this.useOverlayBmp);
   
   if ( %this.useOverlayBmp )
   {  // Overlay in use
      // If there is no bitmap, make the user select one.
      if ( %this.overlayName $= "" )
         %this.onOverlayBrowse();
      else
      {
         %path = %this.overlayName;
         %this.overlayName = "";
         %this.onOverlaySelect(%path);
      }
   }
   else
   {
      // Set the dimensions into the capture control
      SSCaptureFrame.installOverlay("");
      PVCCaptXDim.setText(%this.captureXDim);
      PVCCaptYDim.setText(%this.captureYDim);
      SSCaptureFrame.setCaptureSize(%this.captureXDim, %this.captureYDim);
   }
}

function PVCCaptureDlg::onOverlayBrowse(%this)
{  // Let the user browse for a suitable overlay bitmap.
   getLoadFilename( "Image Files|*.png;*.jpg|JPEG Files|*.jpg|PNG Files|*.png", %this @ ".onOverlaySelect", %this.overlayName);
}

function PVCCaptureDlg::onBitmapBrowse(%this)
{  // Let the user browse for a background bitmap.
   getLoadFilename( "Image Files|*.png;*.jpg|JPEG Files|*.jpg|PNG Files|*.png", %this @ ".onBitmapSelect", %this.bitmapName);
}

function PVCCaptureDlg::onOverlaySelect(%this, %path)
{  // The overlay bitmap has been changed
   if ( (%path $= "") || (%path $= %this.overlayName) )
      return;  // Nothings changed
      
   %path = makeRelativePath( %path, getMainDotCSDir() );
   if ( SSCaptureFrame.installOverlay(%path) )
   {  // The overlay was accepted.
      %this.overlayName = %path;
   }
   else if ( SSCaptureFrame.installOverlay(%this.overlayName) )
   {  // Put the original overlay back in
   }
   else
   {  // We have no overlay to put in so turn off overlay mode.
      %this.overlayName = "";
      %this.useOverlayBmp = false;
      PVCOverlayName.setText(%this.overlayName);
      %this.onUseOverlayBtn();
      return;
   }

   // Get the dimensions from the capture control to display on screen
   %curSize = SSCaptureFrame.getCaptureSize();  
   %this.captureXDim = getWord(%curSize, 0);
   %this.captureYDim = getWord(%curSize, 1);
   PVCCaptXDim.setText(%this.captureXDim);
   PVCCaptYDim.setText(%this.captureYDim);
   
   PVCOverlayName.setText(%this.overlayName);
   return;
}

function PVCCaptureDlg::onCaptureSizeChange(%this)
{  // The capture size has been changed
   %maxExtent = $currentPVC.getExtent();

   // Update the values because this is called before the variable is set.   
   %curXVal = PVCCaptXDim.getText();
   %curYVal = PVCCaptYDim.getText();
   
   if ( %curXVal <= 4 )
      return; // Probably retyping
   if ( %curXVal > getWord(%maxExtent, 0) )
   {
      %curXVal = getWord(%maxExtent, 0);
      PVCCaptXDim.setText(%curXVal);
   }

   if ( %curYVal <= 4 )
      return; // Probably retyping
   if ( %curYVal > getWord(%maxExtent, 1) )
   {
      %curYVal = getWord(%maxExtent, 1);
      PVCCaptYDim.setText(%curYVal);
   }

   %this.captureXDim = %curXVal;
   %this.captureYDim = %curYVal;
   // Set the dimensions into the capture control
   SSCaptureFrame.setCaptureSize(%this.captureXDim, %this.captureYDim);

   return;
}

function PVCCaptureDlg::onBackgroundModeBtn(%this, %newMode)
{  // Reset all field states for the current mode
   PVCBackgroundRVal.setActive(%newMode == 0);
   PVCBackgroundGVal.setActive(%newMode == 0);
   PVCBackgroundBVal.setActive(%newMode == 0);
   PVCColorPickBtn.setActive(%newMode == 0);
   
   PVCBackgroundBrowseBtn.setActive(%newMode == 1);
   PVCBackFSBtn.setActive(%newMode == 1);
   PVCBackBDBtn.setActive(%newMode == 1);
   PVCBackCustBtn.setActive(%newMode == 1);
   PVCBackXDim.setActive((%newMode == 1) && (%this.bitmapMode == 2));
   PVCBackYDim.setActive((%newMode == 1) && (%this.bitmapMode == 2));
   
   %this.backgroundMode = %newMode;
   
   %this.installColor();
   if ( %newMode == 1 )
      %this.installBitmap();
}

function PVCCaptureDlg::onColorChange(%this)
{  // The capture background color has been changed
   %newRVal = PVCBackgroundRVal.getText();
   %newGVal = PVCBackgroundGVal.getText();
   %newBVal = PVCBackgroundBVal.getText();
   
   if ( (%newRVal $= "") || (%newRVal < 0) )
      return;
   if ( %newRVal > 255 )
      %newRVal = 255;
      
   if ( (%newGVal $= "") || (%newGVal < 0) )
      return;
   if ( %newGVal > 255 )
      %newGVal = 255;
      
   if ( (%newBVal $= "") || (%newBVal < 0) )
      return;
   if ( %newBVal > 255 )
      %newBVal = 255;
      
   %this.backgroundColor = %newRVal SPC %newGVal SPC %newBVal SPC "255";
   %this.installColor();
   %this.updateColors();
}

function PVCCaptureDlg::onColorBrowse(%this)
{  // Open the color picker to choose a color
   GetColorI( %this.backgroundColor, %this.getId() @ ".colorPicked", %this.getRoot() );
}

function PVCCaptureDlg::colorPicked(%this, %color)
{
   %this.backgroundColor = %color;
   %this.installColor();
   %this.updateColors();
}

function PVCCaptureDlg::updateColors(%this)
{
   PVCBackgroundRVal.setText(getWord(%this.backgroundColor, 0));
   PVCBackgroundGVal.setText(getWord(%this.backgroundColor, 1));
   PVCBackgroundBVal.setText(getWord(%this.backgroundColor, 2));
}

function PVCCaptureDlg::installColor(%this)
{
   GuiICBackgroundProfile.fillColor = %this.backgroundColor;
   icBitmapBackground.setVisible(false);
}

function PVCCaptureDlg::onBitmapSelect(%this, %path)
{  // The overlay bitmap has been changed
   if ( (%path $= "") || (%path $= %this.bitmapName) )
      return;  // Nothings changed
      
   %path = makeRelativePath( %path, getMainDotCSDir() );
   %this.bitmapName = %path;
   %this.installBitmap();
}
function PVCCaptureDlg::installBitmap(%this)
{
   icBitmapBackground.setVisible(true);
   icBitmapBackground.setBitmap(%this.bitmapName, true);
   
   if ( %this.bitmapMode == 0 )
      %useDim = Canvas.getExtent();
   else if ( %this.bitmapMode == 1 )
      %useDim = icBitmapBackground.getExtent();
   else
      %useDim = %this.bitmapXDim SPC %this.bitmapYDim;

   icBitmapBackground.setExtent(getWord(%useDim, 0), getWord(%useDim, 1));
   %this.bitmapXDim = getWord(%useDim, 0);
   %this.bitmapYDim = getWord(%useDim, 1);
   %this.updateBackgroundDims();
   %this.centerBitmap();
}

function PVCCaptureDlg::updateBackgroundDims(%this)
{
   PVCBackXDim.setText(%this.bitmapXDim);
   PVCBackYDim.setText(%this.bitmapYDim);
}

function PVCCaptureDlg::onBmpSizeChange(%this)
{  // The capture size has been changed
   %maxExtent = Canvas.getExtent();

   // Update the values because this is called before the variable is set.   
   %curXVal = PVCBackXDim.getText();
   %curYVal = PVCBackYDim.getText();
   
   if ( %curXVal <= 4 )
      return; // Probably retyping
   if ( %curXVal > getWord(%maxExtent, 0) )
   {
      %curXVal = getWord(%maxExtent, 0);
      PVCBackXDim.setText(%curXVal);
   }

   if ( %curYVal <= 4 )
      return; // Probably retyping
   if ( %curYVal > getWord(%maxExtent, 1) )
   {
      %curYVal = getWord(%maxExtent, 1);
      PVCBackYDim.setText(%curYVal);
   }

   %this.bitmapXDim = %curXVal;
   %this.bitmapYDim = %curYVal;
   // Set the dimensions into the bitmap control
   icBitmapBackground.setExtent(%this.bitmapXDim, %this.bitmapYDim);
   %this.centerBitmap();
}

function PVCCaptureDlg::centerBitmap(%this, %newMode)
{
   %maxExtent = Canvas.getExtent();
   %xPos = (getWord(%maxExtent, 0) - %this.bitmapXDim) / 2;
   %yPos = (getWord(%maxExtent, 1) - %this.bitmapYDim) / 2;
   icBitmapBackground.resize(%xPos, %yPos, %this.bitmapXDim, %this.bitmapYDim);
}

function PVCCaptureDlg::onBitmapModeBtn(%this, %newMode)
{  // Resize the bitmap for the current mode
   PVCBackXDim.setActive( %newMode == 2 );
   PVCBackYDim.setActive( %newMode == 2 );
   
   %this.bitmapMode = %newMode;
   %this.installBitmap();
}
function PVCCaptureDlg::saveSettings(%this, %file)
{  // Save all settings needed to restore the window to it's current state
   %file.WriteLine("PVCCaptureDlg.captureFormat = \"" @ %this.captureFormat @ "\";" );
   %file.WriteLine("PVCCaptureDlg.useOverlayBmp = \"" @ %this.useOverlayBmp @ "\";" );
   %file.WriteLine("PVCCaptureDlg.overlayName = \"" @ %this.overlayName @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.captureXDim = \"" @ %this.captureXDim @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.captureYDim = \"" @ %this.captureYDim @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.isFullAlpha = \"" @ %this.isFullAlpha @ "\";" );

   %file.WriteLine("PVCCaptureDlg.backgroundMode = \"" @ %this.backgroundMode @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.backgroundColor = \"" @ %this.backgroundColor @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.bitmapMode = \"" @ %this.bitmapMode @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.bitmapName = \"" @ %this.bitmapName @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.bitmapXDim = \"" @ %this.bitmapXDim @ "\";" );   
   %file.WriteLine("PVCCaptureDlg.bitmapYDim = \"" @ %this.bitmapYDim @ "\";" );   
}

function SSCaptureFrame::onCaptureDone(%this)
{  // The capture has completed so show the preview window.
   //Canvas.pushDialog(PVCPreviewDlg, 0, true);
   Canvas.pushDialog(PVCPreviewDlg);
   %xDim = PVCCaptureDlg.captureXDim;
   %yDim = PVCCaptureDlg.captureYDim;
   if ( PVCPreviewDlg.firstDisplay $= "" )
      PVCPreviewDlg.firstDisplay = true;
   else
      ImagePreviewDlg.resize( 0, 0, ((%xDim < 200) ? %xDim : 200), %yDim + 80);
   ImagePreviewBmp.setExtent(%xDim, %yDim);
   %fileName = "tools/imageCapture/preview" @ (PVCCaptureDlg.captureFormat $= "JPG" ? ".jpg" : ".png");
   ImagePreviewBmp.setBitmap(%fileName, true);
   return;
}

function PVCPreviewDlg::SaveImage(%this)
{
   if ( PVCCaptureDlg.captureFormat $= "JPG" )
      %format = "JPEG Files|*.jpg";
   else
      %format = "PNG Files|*.png";
      
   getSaveFilename( %format, %this @ ".onSaveFile", "", true);
}

function PVCPreviewDlg::onSaveFile(%this, %filename)
{
   %filename = makeRelativePath( %filename, getMainDotCsDir() );
   %fileExtension = (PVCCaptureDlg.captureFormat $= "JPG" ? ".jpg" : ".png");
   if(strStr(%filename, ".") == -1)
   {
      %fileName = %fileName @ (PVCCaptureDlg.captureFormat $= "JPG" ? ".jpg" : ".png");
   }
   
   %previewFile = "tools/imageCapture/preview" @ %fileExtension;
   if ( isFile(%previewFile) )
      pathCopy(%previewFile, %fileName, false);
      
   Canvas.popDialog(PVCPreviewDlg);
}

function PVCPreviewDlg::onSleep(%this)
{
   %fileExtension = (PVCCaptureDlg.captureFormat $= "JPG" ? ".jpg" : ".png");

   %previewFile = "tools/imageCapture/preview" @ %fileExtension;
   if ( isFile(%previewFile) )
      fileDelete(%previewFile);

   %previewFile = "tools/imageCapture/preview0" @ %fileExtension;
   if ( isFile(%previewFile) )
      fileDelete(%previewFile);

   %previewFile = "tools/imageCapture/preview1" @ %fileExtension;
   if ( isFile(%previewFile) )
      fileDelete(%previewFile);

   %previewFile = "tools/imageCapture/preview2" @ %fileExtension;
   if ( isFile(%previewFile) )
      fileDelete(%previewFile);
}
