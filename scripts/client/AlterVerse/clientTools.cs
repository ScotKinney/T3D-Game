// Client Build Tools
// Overrides for toggleGuiEditor and toggleEditor

function guiEditorToggle(%make)
{
   if ( %make && $TAP::isDev )
      checkToolsLoaded("gui");
}

function worldEditorToggle(%make)
{
   if( !$TAP::onServer || !%make )
      return;

   checkToolsLoaded("world");
}

GlobalActionMap.bind( keyboard, "f10", guiEditorToggle );
GlobalActionMap.bind(keyboard, "f11", worldEditorToggle);

function toggleToolNow(%type)
{
   if ( %type $= "gui" )
      toggleGuiEditor();
   else if ( %type $= "world" )
      toggleEditor();
}

function checkToolsLoaded(%type)
{
   if ( isObject(EditorLoadingGui) )
   {
      toggleToolNow(%type);  // Tools are loaded already.
      return;
   }
   
   Canvas.pushDialog(ToolsLoadingGui);
   Canvas.repaint();
   
   schedule(0, 0, LoadTools, %type);
}

function LoadTools(%type)
{
   // Create a group for the audio data blocks   
   %oldGroup = $instantGroup;
   $instantGroup = 0;
   if( isObject( AVToolGroup ) )
      AVToolGroup.delete();
   %missionGroup = new SimGroup(AVToolGroup);
   $instantGroup = %missionGroup;

   loadDirs("tools");
   lateToolStart();
   $instantGroup = %oldGroup;

   Canvas.popDialog(ToolsLoadingGui);
   Canvas.repaint();
   
   schedule(0, 0, toggleToolNow, %type);
}
