
function ArnTransferGui::onWake(%this)
{
   if ($pref::gui::TransferPos $= "")
      $pref::gui::TransferPos = TransferWnd.getPosition();
       
   %resx = getWord(Canvas.getVideoMode(), $WORD::RES_X);
   %resy = getWord(Canvas.getVideoMode(), $WORD::RES_Y);
   
   %winx = getWord($pref::gui::TransferPos, 0);
   %winy = getWord($pref::gui::TransferPos, 1);
  
   %winextx = getWord(TransferWnd.getExtent(), 0);
   %winexty = getWord(TransferWnd.getExtent(), 1);
   
   if (%winx < 0 ) %winx = 0;
   if (%winy < 0 ) %winy = 0;
   if ((%winx + %winextx) > %resx ) %winx = (%resx - %winextx);
   if ((%winy + %winexty) > %resy ) %winy = (%resy - %winexty);
   
   $pref::gui::TransferPos = %winx SPC %winy;

   if ($pref::gui::TransferPos !$= "")
      TransferWnd.position = $pref::gui::TransferPos;

   %this-->ArnsInReserve.setText($AlterVerse::ArnsInReserve);
}

function ArnTransferGui::Close(%this)
{
   $pref::gui::TransferPos = TransferWnd.getPosition();
   Canvas.popDialog(%this);
}

function ArnTransferGui::onMaxClicked(%this)
{
   %this-->ArnsToTransfer.setText($AlterVerse::ArnsInReserve);
}

function ArnTransferGui::onTransferClicked(%this)
{  // Tell the server to transfer the arns
   %arnsToTransfer = %this-->ArnsToTransfer.getText();
   if ( %arnsToTransfer > 0 && %arnsToTransfer <= $AlterVerse::ArnsInReserve )
   {
      sfxPlayOnce(Audio2D, "art/sound/bankaction");
      commandToServer('TransferArn', %arnsToTransfer);
      %this.Close();
   }

   %this.Close();
}

function ArnTransferGui::toggleGui(%this)
{
   if ( %this.isAwake() )
   {
      %this.close();
      return;
   }
   
   Canvas.pushDialog(%this);
}
