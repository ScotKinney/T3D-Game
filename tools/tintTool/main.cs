// BloodClans Script Modification (MAR) - Tint tool >>>
function runTintTool(%val)
{
   if ( !%val )
      return;

   //if ( !checkToolPermission(6, "use the Character Customization Option Tool") )
      //return;
   
   // Create the tool window
   if ( !isObject(TintTool) )
   {
      exec("tools/tintTool/tintTool.gui");
      exec("tools/tintTool/tintToolGui.cs");
   }
      
   if ( !TintTool.isAwake() )
      Canvas.pushDialog(TintTool);
   else
      Canvas.popDialog(TintTool);
}

GlobalActionMap.bind(keyboard, "ctrl f6", runTintTool);
// BloodClans Script Modification (MAR) - Tint tool >>>
