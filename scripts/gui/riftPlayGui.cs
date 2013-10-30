function RiftPlayGui::onWake(%this)
{
   $enableDirectInput = "1";
   activateDirectInput();

   // just update the action map here
   unbindChatCommands();
   moveMap.push();

   //PutTLOnTop();  // Bring the TL gui back onto the canvas
   $TAP::WebResponder = %this-->WebResponder;
}

function RiftPlayGui::onSleep(%this)
{
   // pop the keymaps
   moveMap.pop();
   bindChatCommands();
}
