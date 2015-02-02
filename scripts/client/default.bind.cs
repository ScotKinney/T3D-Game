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

if ( isObject( moveMap ) )
   moveMap.delete();
new ActionMap(moveMap);


//------------------------------------------------------------------------------
// Non-remapable binds
//------------------------------------------------------------------------------

function escapeFromGame()
{
   if ( $Server::ServerType $= "SinglePlayer" )
      MessageBoxYesNo( "Exit", "Leave the AlterVerse?", "disconnect();", "");
   else
      MessageBoxYesNo( "Disconnect", "Leave the AlterVerse?", "disconnect();", "");
}

moveMap.bindCmd(keyboard, "escape", "", "handleEscape();");

function showPlayerList(%val)
{
   if (%val)
      UserListGui.toggle();
}

moveMap.bind( keyboard, F2, showPlayerList );

function hideHUDs(%val)
{
   if (%val)
      HudlessPlayGui.toggle();
}

moveMap.bind(keyboard, "ctrl h", hideHUDs);

function doScreenShotHudless(%val)
{
   if(%val)
   {
      canvas.setContent(HudlessPlayGui);
      //doScreenshot(%val);
      schedule(10, 0, "doScreenShot", %val);
   }
   else
      canvas.setContent(PlayGui);
}

moveMap.bind(keyboard, "alt p", doScreenShotHudless);

//------------------------------------------------------------------------------
// Movement Keys
//------------------------------------------------------------------------------

$movementSpeed = 1; // m/s
$runLocked = false;

function setSpeed(%speed)
{
   if(%speed)
      $movementSpeed = %speed;
}

function moveleft(%val)
{
   if ( $runLocked )
      toggleRunLock(1);
   $mvLeftAction = %val * $movementSpeed;
}

function moveright(%val)
{
   if ( $runLocked )
      toggleRunLock(1);
   $mvRightAction = %val * $movementSpeed;
}

function moveforward(%val)
{
   if ( $runLocked )
      toggleRunLock(1);
   $mvForwardAction = %val * $movementSpeed;
}

function movebackward(%val)
{
   if ( $runLocked )
      toggleRunLock(1);
   $mvBackwardAction = %val * $movementSpeed;
}

function toggleRunLock(%val)
{
   if ( %val )
   {
      if ( $runLocked )
      {
         $mvForwardAction = 0;
         $runLocked = false;
         if ( ($mvTriggerCount5 % 2) == 1 )
            $mvTriggerCount5++;
      }
      else
      {
         $mvForwardAction = 1;
         $runLocked = true;
      }
   }
}

function turnLeft( %val )
{
   $mvYawRightSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function turnRight( %val )
{
   $mvYawLeftSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panUp( %val )
{
   $mvPitchDownSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function panDown( %val )
{
   $mvPitchUpSpeed = %val ? $Pref::Input::KeyboardTurnSpeed : 0;
}

function getMouseAdjustAmount(%val)
{
   // based on a default camera FOV of 90'
   return(%val * ($cameraFov / 90) * 0.01) * $pref::Input::LinkMouseSensitivity;
}

function getGamepadAdjustAmount(%val)
{
   // based on a default camera FOV of 90'
   return(%val * ($cameraFov / 90) * 0.01) * 5.0;
}

$mvYaw = 0;
$mvPitch = 0;
function yaw(%val)
{
   %yawAdj = getMouseAdjustAmount(%val);
   if( isObject(ServerConnection) &&
      ServerConnection.isControlObjectRotDampedCamera() )
   {
      // Clamp and scale
      %yawAdj = mClamp(%yawAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %yawAdj *= 0.5;
   }

   $mvYaw += %yawAdj;
}

function pitch(%val)
{
   %pitchAdj = getMouseAdjustAmount(%val);
   if( isObject(ServerConnection) &&
      ServerConnection.isControlObjectRotDampedCamera() )
   {
      // Clamp and scale
      %pitchAdj = mClamp(%pitchAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %pitchAdj *= 0.5;
   }

   $mvPitch += %pitchAdj;
}

function jump(%val)
{
   $mvTriggerCount2++;
   if (%val && (($mvTriggerCount2 % 2) == 0))
      $mvTriggerCount2++;
}

function gamePadMoveX( %val )
{
   if(%val > 0)
   {
      $mvRightAction = %val * $movementSpeed;
      $mvLeftAction = 0;
   }
   else
   {
      $mvRightAction = 0;
      $mvLeftAction = -%val * $movementSpeed;
   }
}

function gamePadMoveY( %val )
{
   if(%val > 0)
   {
      $mvForwardAction = %val * $movementSpeed;
      $mvBackwardAction = 0;
   }
   else
   {
      $mvForwardAction = 0;
      $mvBackwardAction = -%val * $movementSpeed;
   }
}

function gamepadYaw(%val)
{
   %yawAdj = getGamepadAdjustAmount(%val);
   if(ServerConnection.isControlObjectRotDampedCamera())
   {
      // Clamp and scale
      %yawAdj = mClamp(%yawAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %yawAdj *= 0.5;
   }

   if(%yawAdj > 0)
   {
      $mvYawLeftSpeed = %yawAdj;
      $mvYawRightSpeed = 0;
   }
   else
   {
      $mvYawLeftSpeed = 0;
      $mvYawRightSpeed = -%yawAdj;
   }
}

function gamepadPitch(%val)
{
   %pitchAdj = getGamepadAdjustAmount(%val);
   if(ServerConnection.isControlObjectRotDampedCamera())
   {
      // Clamp and scale
      %pitchAdj = mClamp(%pitchAdj, -m2Pi()+0.01, m2Pi()-0.01);
      %pitchAdj *= 0.5;
   }

   if(%pitchAdj > 0)
   {
      $mvPitchDownSpeed = %pitchAdj;
      $mvPitchUpSpeed = 0;
   }
   else
   {
      $mvPitchDownSpeed = 0;
      $mvPitchUpSpeed = -%pitchAdj;
   }
}

moveMap.bind( keyboard, a, moveleft );
moveMap.bind( keyboard, d, moveright );
moveMap.bind( keyboard, left, moveleft );
moveMap.bind( keyboard, right, moveright );

moveMap.bind( keyboard, w, moveforward );
moveMap.bind( keyboard, s, movebackward );
moveMap.bind( keyboard, up, moveforward );
moveMap.bind( keyboard, down, movebackward );
moveMap.bind( keyboard, r, toggleRunLock );

moveMap.bind( keyboard, space, jump );
moveMap.bind( mouse, xaxis, yaw );
moveMap.bind( mouse, yaxis, pitch );

moveMap.bind( gamepad, thumbrx, "D", "-0.23 0.23", gamepadYaw );
moveMap.bind( gamepad, thumbry, "D", "-0.23 0.23", gamepadPitch );
moveMap.bind( gamepad, thumblx, "D", "-0.23 0.23", gamePadMoveX );
moveMap.bind( gamepad, thumbly, "D", "-0.23 0.23", gamePadMoveY );

moveMap.bind( gamepad, btn_a, jump );
moveMap.bindCmd( gamepad, btn_back, "disconnect();", "" );

moveMap.bindCmd(gamepad, dpadl, "toggleLightColorViz();", "");
moveMap.bindCmd(gamepad, dpadu, "toggleDepthViz();", "");
moveMap.bindCmd(gamepad, dpadd, "toggleNormalsViz();", "");
moveMap.bindCmd(gamepad, dpadr, "toggleLightSpecularViz();", "");

// ----------------------------------------------------------------------------
// Stance/pose
// ----------------------------------------------------------------------------

function doCrouch(%val)
{
   $mvTriggerCount3++;
   if (%val && (($mvTriggerCount3 % 2) == 0))
      $mvTriggerCount3++;
}
moveMap.bind(keyboard, g, doCrouch);
moveMap.bind(gamepad, btn_b, doCrouch);

function doProne(%val)
{
   $mvTriggerCount4++;
   if (%val && (($mvTriggerCount4 % 2) == 0))
      $mvTriggerCount4++;
}
moveMap.bind(keyboard, h, doProne);

//------------------------------------------------------------------------------
// Gamepad Trigger
//------------------------------------------------------------------------------

function gamepadFire(%val)
{
   if(%val > 0.1 && !$gamepadFireTriggered)
   {
      $gamepadFireTriggered = true;
      $mvTriggerCount0++;
   }
   else if(%val <= 0.1 && $gamepadFireTriggered)
   {
      $gamepadFireTriggered = false;
      $mvTriggerCount0++;
   }
}

function gamepadAltTrigger(%val)
{
   if(%val > 0.1 && !$gamepadAltTriggerTriggered)
   {
      $gamepadAltTriggerTriggered = true;
      $mvTriggerCount1++;
   }
   else if(%val <= 0.1 && $gamepadAltTriggerTriggered)
   {
      $gamepadAltTriggerTriggered = false;
      $mvTriggerCount1++;
   }
}

moveMap.bind(gamepad, triggerr, gamepadFire);

//------------------------------------------------------------------------------
// Zoom and FOV functions
//------------------------------------------------------------------------------

if($Pref::Player::CurrentFOV $= "")
   $Pref::Player::CurrentFOV = $pref::Player::DefaultFOV / 2;

// toggleZoomFOV() works by dividing the CurrentFOV by 2.  Each time that this
// toggle is hit it simply divides the CurrentFOV by 2 once again.  If the
// FOV is reduced below a certain threshold then it resets to equal half of the
// DefaultFOV value.  This gives us 4 zoom levels to cycle through.

function toggleZoomFOV()
{
    $Pref::Player::CurrentFOV = $Pref::Player::CurrentFOV / 2;

    if($Pref::Player::CurrentFOV < 5)
        resetCurrentFOV();

    if(ServerConnection.zoomed)
      setFOV($Pref::Player::CurrentFOV);
    else
    {
      setFov(ServerConnection.getControlCameraDefaultFov());
    }
}

function resetCurrentFOV()
{
   $Pref::Player::CurrentFOV = ServerConnection.getControlCameraDefaultFov() / 2;
}

function turnOffZoom()
{
   ServerConnection.zoomed = false;
   setFov(ServerConnection.getControlCameraDefaultFov());
   Reticle.setVisible(true);
   zoomReticle.setVisible(false);

   // Rather than just disable the DOF effect, we want to set it to the level's
   // preset values.
   //DOFPostEffect.disable();
   ppOptionsUpdateDOFSettings();
}

function setZoomFOV(%val)
{
   if(%val)
      toggleZoomFOV();
}

function toggleZoom(%val)
{
   if (%val)
   {
      ServerConnection.zoomed = true;
      setFov($Pref::Player::CurrentFOV);
      Reticle.setVisible(false);
      zoomReticle.setVisible(true);

      DOFPostEffect.setAutoFocus( true );
      DOFPostEffect.setFocusParams( 0.5, 0.5, 50, 500, -5, 5 );
      DOFPostEffect.enable();
   }
   else
   {
      turnOffZoom();
   }
}

function mouseButtonZoom(%val)
{
   toggleZoom(%val);
}

//moveMap.bind(keyboard, f, setZoomFOV); // f for field of view
moveMap.bind(keyboard, t, toggleZoom);
//moveMap.bind( mouse, button1, mouseButtonZoom );

//------------------------------------------------------------------------------
// Camera & View functions
//------------------------------------------------------------------------------

function toggleFreeLook( %val )
{
   if ( %val )
      $mvFreeLook = true;
   else
      $mvFreeLook = false;
}

function toggleFirstPerson(%val)
{
   if (%val)
   {
      ServerConnection.setFirstPerson(!ServerConnection.isFirstPerson());
   }
}

function toggleCamera(%val)
{
   if (%val)
      commandToServer('ToggleCamera');
}

moveMap.bind( keyboard, v, toggleFreeLook ); // v for vanity
moveMap.bind(keyboard, tab, toggleFirstPerson );
//moveMap.bind(keyboard, "alt c", toggleCamera);

//moveMap.bind( gamepad, btn_start, toggleCamera );
moveMap.bind( gamepad, btn_x, toggleFirstPerson );

function toggleFreeAim(%val)
{
   $mvTriggerCount0++;
   if (%val && (($mvTriggerCount0 % 2) == 0))
      $mvTriggerCount0++;
}
moveMap.bind( keyboard, "lcontrol", toggleFreeAim );

// ----------------------------------------------------------------------------
// Misc. Player stuff
// ----------------------------------------------------------------------------

moveMap.bindCmd(keyboard, "ctrl w", "commandToServer('playCel',\"wave\");", "");
moveMap.bindCmd(keyboard, "ctrl s", "commandToServer('playCel',\"salute\");", "");

moveMap.bindCmd(keyboard, "ctrl k", "commandToServer('suicide');", "");

function toggleAnimGui(%val)
{
   if (%val && isObject(XtraAnimGui))
      XtraAnimGui.toggleGui();
}
moveMap.bind(keyboard, "ctrl a", toggleAnimGui);

//------------------------------------------------------------------------------
// Message HUD functions
//------------------------------------------------------------------------------

function pageMessageHudUp( %val )
{
   if ( %val )
      pageUpMessageHud();
}

function pageMessageHudDown( %val )
{
   if ( %val )
      pageDownMessageHud();
}

function resizeMessageHud( %val )
{
   if ( %val )
      cycleMessageHudSize();
}

globalActionMap.bind(keyboard, enter, toggleMessageHud );
moveMap.bind(keyboard, "enter", toggleMessageHud );
moveMap.bind(keyboard, y, teamMessageHud );
moveMap.bind(keyboard, "pageUp", pageMessageHudUp );
moveMap.bind(keyboard, "pageDown", pageMessageHudDown );
moveMap.bind(keyboard, "p", resizeMessageHud );

//------------------------------------------------------------------------------
// Helper Functions
//------------------------------------------------------------------------------

function dropCameraAtPlayer(%val)
{
   if (%val)
      commandToServer('dropCameraAtPlayer');
}

function dropPlayerAtCamera(%val)
{
   if (%val)
      commandToServer('DropPlayerAtCamera');
}

moveMap.bind(keyboard, "F8", dropCameraAtPlayer);
moveMap.bind(keyboard, "F7", dropPlayerAtCamera);

function bringUpOptions(%val)
{
   if (%val)
      Canvas.pushDialog(OptionsDlg);
}

GlobalActionMap.bind(keyboard, "ctrl o", bringUpOptions);


//------------------------------------------------------------------------------
// Debugging Functions
//------------------------------------------------------------------------------
$DrawColShapes = false;
function togglePhysicsDraw(%val)
{
   if (%val)
   {
      $DrawColShapes = !$DrawColShapes;
      $player::renderCollision = $DrawColShapes;
      //physicsDebugDraw($DrawColShapes);
   }
}
moveMap.bind(keyboard, "F9", togglePhysicsDraw);

//------------------------------------------------------------------------------
//
// Start profiler by pressing ctrl f3
// ctrl f3 - starts profile that will dump to console and file
//
function doProfile(%val)
{
   if (%val)
   {
      // key down -- start profile
      echo("Starting profile session...");
      profilerReset();
      profilerEnable(true);
   }
   else
   {
      // key up -- finish off profile
      echo("Ending profile session...");

      profilerDumpToFile("profilerDumpToFile" @ getSimTime() @ ".txt");
      profilerEnable(false);
   }
}

GlobalActionMap.bind(keyboard, "ctrl F3", doProfile);

//------------------------------------------------------------------------------
// Misc.
//------------------------------------------------------------------------------

GlobalActionMap.bind(keyboard, "tilde", toggleConsole);
GlobalActionMap.bindCmd(keyboard, "alt k", "cls();","");
GlobalActionMap.bindCmd(keyboard, "alt enter", "", "Canvas.attemptFullscreenToggle();");
GlobalActionMap.bindCmd(keyboard, "F1", "", "contextHelp();");
//moveMap.bindCmd(keyboard, "n", "toggleNetGraph();", "");

function toggleHudCurtain(%val)
{
   if ( $CurtainManager::renderGui )
   {
      $CurtainManager::renderGui = false;
      $CurtainManager::renderHUD = true;
   }
   else
   {
      $CurtainManager::renderHUD = false;
      $CurtainManager::renderGui = true;
   }
}
//moveMap.bindCmd(keyboard, "ctrl h", "toggleHudCurtain();", "");

// mouse cursor toggle by right mouse button
globalActionMap.bind( mouse, button1, toggleCursor );
function toggleCursor( %val ) 
{
   // Key bind is removed in the editor so isEditing check is no longer needed 
   //%editing = isObject(EditorGui) && Canvas.getContent() == EditorGui.getId();
   %playing = Canvas.getContent() == PlayGui.getId();
   
   //if(!%playing && !%editing)
   if( !%playing )
      return;
      
   if( %val ) 
   {
      if ( isEventPending(PlayGui.hoverEvent) )
         cancel(PlayGui.hoverEvent);

      if ( isObject(InfoBox) )
      {
         InfoBoxBackdrop.visible = false;
         InfoBox.visible = false;
      }

      if(Canvas.isCursorOn())
         hideCursor();
      else
         showCursor();
   }
} 

moveMap.bind(keyboard, "lshift", sprint);
moveMap.bind(keyboard, "rshift", sprint);
function sprint(%val)
{
   if ( $runLocked )
      return;

   if ( ($mvTriggerCount5 % 2) != %val )
      $mvTriggerCount5++;
}

// ----------------------------------------------------------------------------
// 3D TAP-Link
// ----------------------------------------------------------------------------
//function toggle3DTL(%val)  
//{  
   //if (%val)  
   //{  
      //// use the lantern item in inventory. Lantern Item is ID 88
      //commandToServer('Use3DTL');
   //}  
//}  
//moveMap.bind( keyboard, "alt t", toggle3DTL );
moveMap.bindCmd(keyboard, "alt t", "commandToServer('Use3DTL');", "");

// --------------------------
// Mount Controls
// --------------------------
moveMap.bind(keyboard, "+", fasterMount);
moveMap.bind(keyboard, "-", slowerMount);
function fasterMount(%val)
{
   if ( ($mvTriggerCount5 % 2) != %val )
      $mvTriggerCount5++;
}
function slowerMount(%val)
{
   if ( ($mvTriggerCount4 % 2) != %val )
      $mvTriggerCount4++;
}

function dismountRide(%val)
{
   $mvTriggerCount1++;
   if (%val && (($mvTriggerCount1 % 2) == 0))
      $mvTriggerCount1++;
}
moveMap.bind( keyboard, "m", dismountRide );

// --------------------------
// Lantern Bind
// --------------------------
function toggleFlashlight(%val)  
{  
   if (%val)  
   {  
      // use the lantern item in inventory. Lantern Item is ID 74
      commandToServer('UseItem', "74", "1", "5");
   }  
}  
moveMap.bind( keyboard, "l", toggleFlashlight );

moveMap.bindCmd(keyboard, "c", "MainChatHud.toggleChatLog(1);", "");//MAR

// --------------------------
// 3rd Person Camera Movement
// --------------------------
function stepTo(%val)
{
   if (%val)
   {
      if ( isObject(ServerConnection) &&
         ServerConnection.getControlObject().isMethod("getAVCamDistance") )
      {
         //if ( ServerConnection.getControlObject().isMounted() )
            //%camObject = ServerConnection.getControlObject().getControlObject();
         //else
            %camObject = ServerConnection.getControlObject();

         %distance = %camObject.getAVCamDistance(%distance);
         %distance -= 0.5;
         if (%distance <= 0 )
         {
            %distance = 0;
            if ( !ServerConnection.isFirstPerson() )
               ServerConnection.setFirstPerson(true);
         }
         %camObject.setAVCamDistance(%distance);
      }
   }
}

function stepFro(%val)
{
   if (%val)
   {
      if ( isObject(ServerConnection) &&
         ServerConnection.getControlObject().isMethod("getAVCamDistance") )
      {
         //if ( ServerConnection.getControlObject().isMounted() )
            //%camObject = ServerConnection.getControlObject().getControlObject();
         //else
            %camObject = ServerConnection.getControlObject();

         %distance = %camObject.getAVCamDistance(%distance);
         if ( %distance >= 15 )
            return; // Don't zoom out to more than 15 units
         %distance += 0.5;
         if ( ServerConnection.isFirstPerson() )
         {
            ServerConnection.setFirstPerson(false);
            %distance = 0.5;
         }
         %camObject.setAVCamDistance(%distance);
      }
   }
}

function cameraZoomWheel(%val)
{
   if ( %val > 0 )
      stepTo(true);
   else if ( %val < 0 )
      stepFro(true);
}

moveMap.bind(keyboard,  home,       stepTo );
moveMap.bind(keyboard,  end,        stepFro );
moveMap.bind(mouse, "zaxis", cameraZoomWheel);

//------------------------------------------------------------------------------
// Attack keys and modifiers
//------------------------------------------------------------------------------

$ActiveWeaponSlot = 0;
$UsingFeet = false;
function activateRHWeapon(%val) { if ( %val > 0 ) $ActiveWeaponSlot = 0; }
function activateLHWeapon(%val) { if ( %val > 0 ) $ActiveWeaponSlot = 1; }
function activateRFWeapon(%val) { if ( %val > 0 ) $ActiveWeaponSlot = 2; }
function activateLFWeapon(%val) { if ( %val > 0 ) $ActiveWeaponSlot = 3; }
function setUsingFeet(%val) { $UsingFeet = %val; }
function setUsingLeftHand(%val) { $UsingLeftHand = %val; }
moveMap.bind(keyboard, q, activateLHWeapon);
moveMap.bind(keyboard, e, activateRHWeapon);
moveMap.bind(keyboard, z, activateLFWeapon);
moveMap.bind(keyboard, c, activateRFWeapon);
moveMap.bind(keyboard, f, setUsingFeet);
moveMap.bind(keyboard, x, setUsingLeftHand);

function doAttack(%attackNum)
{
   if ( $mvFreeLook )
      return;
   commandToServer('DoAttack', $ActiveWeaponSlot, %attackNum, "1");
}
function ceaseAttack()
{
   commandToServer('DoAttack', $ActiveWeaponSlot, "0", "0");
}
moveMap.bindCmd(keyboard, "1", "doAttack(0);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "2", "doAttack(1);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "3", "doAttack(2);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "4", "doAttack(3);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "5", "doAttack(4);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "6", "doAttack(5);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "7", "doAttack(6);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "8", "doAttack(7);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "9", "doAttack(8);", "ceaseAttack();");
moveMap.bindCmd(keyboard, "0", "doAttack(9);", "ceaseAttack();");

$LastAttackSlot = 0;
function doRandomAttack(%val)
{
   if ( $mvFreeLook && !$Tap::isDev )
      return;

   if ( %val )
   {
      %slot = 0;
      if ( $UsingLeftHand )
         %slot = 1;
      else if ( $UsingFeet )
         %slot = getRandom(2, 3);
      $LastAttackSlot = %slot;
   }
   commandToServer('DoAttack', $LastAttackSlot, -1, %val);
}

function mouseFire(%val)
{
   if ( %val && isObject(ServerConnection) &&
      ServerConnection.isFirstPerson() &&
      ServerConnection.getControlObject().isMethod("testWebShapeHit") &&
      ServerConnection.getControlObject().testWebShapeHit() )
      return;

   doRandomAttack(%val);
}
moveMap.bind( mouse, button0, mouseFire );

function unmountWeapon(%val)
{
   if (%val)
      commandToServer('unmountWeapon');
}

moveMap.bind(keyboard, u, unmountWeapon);
moveMap.bind( keyboard, e, toggleCraftingGui );

