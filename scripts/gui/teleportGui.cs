// ----------------------------------------------------------------------------
// Intro video gui
// If $pref::shortIntro is set, a shorter framed video will be played.
// ----------------------------------------------------------------------------

function TeleportGui::PlayVideo(%this, %volume)
{
   if ( %this-->VideoFrame.isLoading() )
      %this.schedule(100, "PlayVideo", %volume);
   else
   {
      %vidSel = ($pref::shortIntro ? 0 : 1);
      %this-->VideoFrame.execJavaScript("StartWormhole(" @ %volume @ "," @ %vidSel @ ");");
   }
}

function TeleportGui::onWake(%this)
{
   // Hide the mask if we're playing the long video
   %this-->VideoMask.setVisible($pref::shortIntro);

   %screenExtent = Canvas.getExtent();
   %this.onResize(getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   %volume = $pref::SFX::masterVolume * $pref::SFX::channelVolume3;
   %this.PlayVideo(%volume);

   PutTLOnTop();  // Bring the TL gui back onto the canvas
   %this.videoCanceled = false;
}

function TeleportGui::cancelVideo(%this)
{
   if ( !%this.videoCanceled )
      stopIntroVideo();

   %this.videoCanceled = true;
}

function TeleportGui::onResize(%this, %newWidth, %newHeight)
{
   %this.resize(0, 0, %newWidth, %newHeight);
   if ( $pref::shortIntro )
   {  // Playing the smaller/shorter video behind a mask
      // The portal opening is 691x691 at 455, 98 on the 1600x900 frame image
      %wideAR = 16/9;
      %cropX = 0;
      %cropY = 0;

      %this-->VideoFrame.Resolution = "1296 736";
      %this-->VideoFrame.ForceCenter = false;
      if ( (%newWidth/%newHeight) < %wideAR )
      {
         %frameHeight = %newHeight;
         %frameWidth = mFloor(%newHeight * %wideAR);
         %frameX = mFloor((%newWidth - %frameWidth) / 2);
         %frameY = 0;
         %portScale = %newHeight/900;
         %cropX = mRound(((1600 * %portScale) - %newWidth) / 2);
         %portX = mRound(455 * %portScale) - %cropX;
         %portY = mRound(98 * %portScale);
      }
      else
      {
         %frameWidth = %newWidth;
         %frameHeight = mFloor(%newWidth / %wideAR);
         %frameY = mFloor((%newHeight - %frameHeight) / 2);
         %frameX = 0;
         %portScale = %newWidth/1600;
         %cropY = mRound(((900 * %portScale) - %newHeight) / 2);
         %portX = mRound(455 * %portScale);
         %portY = mRound(98 * %portScale) - %cropY;
      }
      %portSize = mRound(691 * %portScale);

      // The video res is 1280x720, 1296x736 with frame
      %vidScale = %portSize/736;
      %vidWidth = mRound(1296 * %vidScale);
      %vidX = %portX - (mRound((%vidWidth - %portSize) / 2));

      %this-->VideoFrame.resize(%vidX, %portY, %vidWidth, %portSize);
      %this-->VideoMask.setVisible(true);
      %this-->VideoMask.resize(%frameX, %frameY, %frameWidth, %frameHeight);
   }
   else
   {  // Playing the long video with no mask
      %this-->VideoMask.setVisible(false);
      %this-->VideoFrame.ForceCenter = true;

      // The video is 1920x1080, but will be padded to 1928x1092 by the html
      %this-->VideoFrame.Resolution = "1920 1080";
      //%this-->VideoFrame.Resolution = "1936 1096"; 
      %this-->VideoFrame.ForcePadding = "0 0"; 

      %this-->VideoFrame.resize(0, 0, %newWidth, %newHeight);
      %this-->VideoInput.resize(0, 0, %newWidth, %newHeight);
   }

   // Set the curtain scale and rotation for stereo view mode.
   %xScale = %newWidth/%newHeight;
   %guiScale = %xScale @ " 1 1";
   setGuiCurtainScale(%guiScale);
   // give a 15 degree rotation amount
   %maxRot = mDegToRad(15) SPC "0" SPC mDegToRad(15 * %xScale);
   setGuiCurtainMaxRot(%maxRot);
}

function IntroInputCtrl::onInputEvent(%this, %device, %action, %state)
{
   //echo("Device: " @ %device @ ", Action: " @ %action @ ", State: " @ %state);
   if ( (%device $= "mouse0") || ((%device $= "keyboard") && (%action $= "space")) )
      TeleportGui.cancelVideo();
}
