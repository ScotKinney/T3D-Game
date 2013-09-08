// BloodClans Script Modification (MAR) - Option tool >>>
function runOptionTool(%val)
{
   if ( !%val || !$TAP::isDev )
      return;

   //if ( !checkToolPermission(6, "use the Character Customization Option Tool") )
      //return;
   
   // Create the tool window
   if ( !isObject(OptionTool) )
   {
      exec("tools/optionTool/optionTool.gui");
      exec("tools/optionTool/optionToolGui.cs");
   }
      
   if ( !OptionTool.isAwake() )
      Canvas.pushDialog(OptionTool);
   else
      Canvas.popDialog(OptionTool);
}

GlobalActionMap.bind(keyboard, "ctrl f7", runOptionTool);
// BloodClans Script Modification (MAR) - Item tool >>>
