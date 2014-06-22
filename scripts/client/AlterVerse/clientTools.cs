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

   if ( isObject( Editor ) && EditorIsActive() )
      toggleEditor();
   else
      commandToServer('GetBuildRights');
}

GlobalActionMap.bind( keyboard, "f10", guiEditorToggle );
GlobalActionMap.bind(keyboard, "f11", worldEditorToggle);

function clientCmdSetBuildRights(%rights, %ownerName, %ownServer)
{
   $TAP::BuildRights = %rights;
   $TAP::OwnServer = %ownServer;
   if ( %rights > 0 )
      checkToolsLoaded("world");
   else
   {
      %message = "You do not have build rights on this server.\n" @
         "Request build rights from " @ %ownerName;
      MessageBoxOK("Denied!", %message);
   }
}

function clientCmdRightsRefused(%errNum)
{  // A request to assign build rights has been denied
   %message = guiStrings.mbRightsErr[%errNum];
   MessageBoxOK("Denied!", %message, "BuildRightsGui.rightsUpdate();");
}

function clientCmdRightsAccepted()
{  // A request to assign build rights has been accepted
   if ( isObject(BuildRightsGui) && BuildRightsGui.isAwake() )
     BuildRightsGui.rightsUpdate();
}

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

function showMetrics(%val)
{
   if ( %val )
      metrics("FPS GFX");
}
GlobalActionMap.bind( keyboard, "alt m", showMetrics );
