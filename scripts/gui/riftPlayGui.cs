// ----------------------------------------------------------------------------
// Play Gui For Rift View
// ----------------------------------------------------------------------------

function RiftPlayGui::onWake(%this)
{
   $enableDirectInput = "1";
   activateDirectInput();

   // just update the action map here
   unbindChatCommands();
   moveMap.push();

   $TAP::WebResponder = %this-->WebResponder;
}

function RiftPlayGui::onSleep(%this)
{
   // pop the keymaps
   moveMap.pop();
   bindChatCommands();
}
