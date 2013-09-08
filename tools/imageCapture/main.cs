function showImageCaptureWin(%val)
{
   if ( %val && $TAP::isDev )
   {
      if ( !isObject(ImageCaptureWin) )
         exec("tools/imageCapture/imageCaptureWinGui.cs");
         
      if ( ImageCaptureWin.isAwake() )
         Canvas.popDialog(ImageCaptureWin);
      else
         Canvas.pushDialog(ImageCaptureWin);
   }
}

GlobalActionMap.bind(keyboard, "ctrl f8", showImageCaptureWin);
