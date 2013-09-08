//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------


//------------------------------------------------------------------------------
// Hard coded images referenced from C++ code
//------------------------------------------------------------------------------

//   editor/SelectHandle.png
//   editor/DefaultHandle.png
//   editor/LockedHandle.png


//------------------------------------------------------------------------------
// Functions
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// Mission Editor 
//------------------------------------------------------------------------------

function Editor::create()
{
   // Not much to do here, build it and they will come...
   // Only one thing... the editor is a gui control which
   // expect the Canvas to exist, so it must be constructed
   // before the editor.
   new EditManager(Editor)
   {
      profile = "GuiContentProfile";
      horizSizing = "right";
      vertSizing = "top";
      position = "0 0";
      extent = "640 480";
      minExtent = "8 8";
      visible = "1";
      setFirstResponder = "0";
      modal = "1";
      helpTag = "0";
      open = false;
   };
}

function Editor::getUndoManager(%this)
{
   if ( !isObject( %this.undoManager ) )
   {
      /// This is the global undo manager used by all
      /// of the mission editor sub-editors.
      %this.undoManager = new UndoManager( EUndoManager )
      {
         numLevels = 200;
      };
   }
   return %this.undoManager;
}

function Editor::setUndoManager(%this, %undoMgr)
{
   %this.undoManager = %undoMgr;
}

function Editor::onAdd(%this)
{
   // Ignore Replicated fxStatic Instances.
   EWorldEditor.ignoreObjClass("fxShapeReplicatedStatic");
}

function Editor::checkActiveLoadDone()
{
   if(isObject(EditorGui) && EditorGui.loadingMission)
   {
      Canvas.setContent(EditorGui);
      EditorGui.loadingMission = false;
      return true;
   }
   return false;
}

//------------------------------------------------------------------------------
function toggleEditor()
{
   if (Canvas.isFullscreen())
   {
      MessageBoxOK("Windowed Mode Required", "Please switch to windowed mode to access the Mission Editor.");
      return;
   }
   
   %timerId = startPrecisionTimer();

   if( $InGuiEditor )
      GuiEdit();

//Geev 5/23/2013			 
   if (!$IsOneWorld)
   {
      forestEditorToolBar.visible = true;
      TerrainEditorGrabTerrain.visible = true;
      PrefabBar1.visible = true;
      PrefabBar2.visible = true;
      TerrainEditorGrabTerrain.visible = true;
      btnGrabTerrain.enabled = true;

      pushInstantGroup();

      if ( !isObject( Editor ) )
      {
         Editor::create();
         MissionCleanup.add( Editor );
         MissionCleanup.add( Editor.getUndoManager() );
      }
         
      if( EditorIsActive() )
      {
         if (theLevelInfo.type $= "DemoScene") 
         {
            commandToServer('dropPlayerAtCamera');
            Editor.close("SceneGui");   
         } 
         else 
            Editor.close("PlayGui");
      }
      else 
      {
         if ( !$GuiEditorBtnPressed )
         {
            canvas.pushDialog( EditorLoadingGui );
            canvas.repaint();
         }
         else
            $GuiEditorBtnPressed = false;

         Editor.open();
			
         // Cancel the scheduled event to prevent
         // the level from cycling after it's duration
         // has elapsed.
         cancel($Game::Schedule);

         if (theLevelInfo.type $= "DemoScene")
            commandToServer('dropCameraAtPlayer', true);


         canvas.popDialog(EditorLoadingGui);
      }

      popInstantGroup();

//Geev 5/23/2013		  
   }
   else
   {
      forestEditorToolBar.visible = false;
      TerrainEditorGrabTerrain.visible = false;
      PrefabBar1.visible = false;
      PrefabBar2.visible = false;
      TerrainEditorGrabTerrain.visible = false;
      btnGrabTerrain.enabled = false;

      pushInstantGroup();
         
      if ( !isObject( Editor ) )
      {
         Editor::create();
         ClientMissionCleanup.add( Editor );
         ClientMissionCleanup.add( Editor.getUndoManager() );
      }
         
      if( EditorIsActive() )
      {
         if (theLevelInfo.type $= "DemoScene") 
         {
            commandToServer('dropPlayerAtCamera');
            Editor.close("SceneGui");   
         } 
         else 
            Editor.close("PlayGui");
      }
      else 
      {
         if ( !$GuiEditorBtnPressed )
         {
            canvas.pushDialog( EditorLoadingGui );
            canvas.repaint();
         }
         else
            $GuiEditorBtnPressed = false;

         Editor.open();

         // Cancel the scheduled event to prevent
         // the level from cycling after it's duration
         // has elapsed.
         cancel($Game::Schedule);

         if (theLevelInfo.type $= "DemoScene")
            commandToServer('dropCameraAtPlayer', true);
               
            
         canvas.popDialog(EditorLoadingGui);
      }

      popInstantGroup();
      $dropcameracount = 0; 	
   }
      
   %elapsed = stopPrecisionTimer( %timerId );
   warn( "Time spent in toggleEditor() : " @ %elapsed / 1000.0 @ " s" );
}

//------------------------------------------------------------------------------
//  The editor action maps are defined in editor.bind.cs
//GlobalActionMap.bind(keyboard, "f11", toggleEditor);


// The scenario:
// The editor is open and the user closes the level by any way other than
// the file menu ( exit level ), eg. typing disconnect() in the console.
//
// The problem:
// Editor::close() is not called in this scenario which means onEditorDisable
// is not called on objects which hook into it and also gEditingMission will no
// longer be valid.
//
// The solution:
// Override the stock disconnect() function which is in game scripts from here
// in tools so we avoid putting our code in there.
//
// Disclaimer:
// If you think of a better way to do this feel free. The thing which could
// be dangerous about this is that no one will ever realize this code overriding
// a fairly standard and core game script from a somewhat random location.
// If it 'did' have unforscene sideeffects who would ever find it?

package EditorDisconnectOverride
{
   function disconnect(%isTransfer)
   {
      if ( isObject( Editor ) && Editor.isEditorEnabled() )
      {
         //if (isObject( MainMenuGui ))
            Editor.close("MainMenuGui");
      }
      
      Parent::disconnect(%isTransfer);  
   }
};
activatePackage( EditorDisconnectOverride );
//Geev 5/23/2013	
function Inspector_onFinishPopulateDataBlocks(%GuiPopupMenuCtrlID,%selectedValue,%isrecall)
{
   if (!isObject(%GuiPopupMenuCtrlID))
      return;
   if ($clientCmdInspector_FinishcreateDataBlockType_Sort[%GuiPopupMenuCtrlID]!$="1")
      {
      schedule("1000","0","Inspector_onFinishPopulateDataBlocks",%GuiPopupMenuCtrlID,%selectedValue,1);
      return;
      }
      
   if (%selectedValue!$="")
      {
      %idx = %GuiPopupMenuCtrlID.findtext(%selectedValue);
       if (%idx!$="-1")
      {
      %GuiPopupMenuCtrlID.setSelected(%idx,0);
      }
   else
      {
      %GuiPopupMenuCtrlID.setField("text",%selectedValue);
      }
      }
}

function Inspector_FinishcreateDataBlockType(%dbstring,%GuiPopupMenuCtrlID,%hasmore)
{
   if (!isObject(%GuiPopupMenuCtrlID))
       return;
   $clientCmdInspector_FinishcreateDataBlockType[%GuiPopupMenuCtrlID] = $clientCmdInspector_FinishcreateDataBlockType[%GuiPopupMenuCtrlID] @ %dbstring;
   if (!(%dbstring $= ""))
      return;
    for (%i =0; %i< getWordCount($clientCmdInspector_FinishcreateDataBlockType[%GuiPopupMenuCtrlID]);%i++)
    {
      if (getword($clientCmdInspector_FinishcreateDataBlockType[%GuiPopupMenuCtrlID],%i)!$="")
      {
         if (isObject(%GuiPopupMenuCtrlID))
         {
            %GuiPopupMenuCtrlID.add(getword($clientCmdInspector_FinishcreateDataBlockType[%GuiPopupMenuCtrlID],%i), %i,0);
         }
      }
    }
   %GuiPopupMenuCtrlID.sort();
   $clientCmdInspector_FinishcreateDataBlockType_Sort[%GuiPopupMenuCtrlID] = 1;
}
                  
