/*
File:             loginDlg.cs
Author:           Guy Allard

Description:      Provides username and password verification for initial
                  client connection to the lobby server.

Revision History:
19 Apr 2010:      Created file.
20 Jan 2012:      Revised to work with new login gui renamed LoginGui.cs. (MAR)
30 Arp 2013:      Revised to work with new scripts for mysql based site
*/

$serverPath = "www.alterverse.com:80";
$scriptPath = "/public_web_dev/";
//$scriptPath = "/public_web/";

// Functions for AlterVerse MainMenu/Login screen

function LoginGui::onWake(%this)
{
   $DesignMode = false;
   //%this-->DevText.setVisible(isDevBuild());
   //%this-->DevBtn.setVisible(isDevBuild());
   %this-->DevText.setVisible(false);
   %this-->DevBtn.setVisible(false);

   if ( $pref::Player::Name !$= "" )
   {
      %this-->UserNameInput.setText($pref::Player::Name);
   }
   
   if ( $pref::Player::Password !$= "" )
   {
      %this-->PasswordInput.setText($pref::Player::Password);
   }

   // Startup the background music
   %this.playLoginMusic();

   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   // Pop/Push the chat dialog so it is on top if connected to chat server
   if ( MainChatHud.isAwake() )
      Canvas.popDialog(MainChatHud);

   if (isObject(clientChat) && clientChat.connected)
      Canvas.pushDialog(MainChatHud);
}

function LoginGui::onSleep(%this)
{
   // Stop the background music
   %this.stopLoginMusic();
}

function LoginGui::playLoginMusic(%this)
{
   %this.bgMusic = new SFXProfile()
   {
      filename    = "art/sound/LogInMusic.ogg";
      description = AudioMusicLoop2D;
   };
   %this.bgMusicId = sfxPlay(%this.bgMusic);
}

function LoginGui::stopLoginMusic(%this)
{
   if ( isObject(%this.bgMusic) )
   {
      sfxStop(%this.bgMusicId);
      %this.bgMusic.delete();
      %this.bgMusic = 0;
   }
}

function LoginGui::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents. Sizes and positions are taken from the
   // reference art and scaled to the current screen height (%newHeight)
   // The reference art is 1600x900.
   %verticalScale = %newHeight / 900;
   %horizontalScale = %newWidth / 1600;

   // Input box
   // The input box is 363x261 and positioned at 616,302 on the background image
   %croppedWidth = %verticalScale > %horizontalScale;
   %cropX = 0;
   %cropY = 0;
   if ( %croppedWidth )
   {
      %cropX = mRound(((1600 * %verticalScale) - %newWidth) / 2);
      %inputXPos = mRound(616 * %verticalScale) - %cropX;
      %inputYPos = mRound(302 * %verticalScale);
      %useScale = %verticalScale;
   }
   else
   {
      %cropY = mRound(((900 * %horizontalScale) - %newHeight) / 2);
      %inputXPos = mRound(616 * %horizontalScale);
      %inputYPos = mRound(302 * %horizontalScale) - %cropY;
      %useScale = %horizontalScale;
   }
   %inputXExtent = mRound(363 * %useScale);
   %inputYExtent = mRound(261 * %useScale);
   //%this->TestControl.resize(%inputXPos, %inputYPos, %inputXExtent, %inputYExtent);
   
   // resize te fonts used on this page
   %this.resizeFonts(%useScale);
   
   // Input boxes are 255x32
   %xExtent = mRound(255 * %useScale);
   %yExtent = mRound(32 * %useScale);
   
   // User name input is positioned at 667,339
   %xPos = mRound(667 * %useScale) - %cropX;
   %yPos = mRound(339 * %useScale) - %cropY;
   %this->UserNameInput.resize(%xPos, %yPos, %xExtent, %yExtent);

   // Password input is positioned at 667,406
   %yPos = mRound(406 * %useScale) - %cropY;
   %this->PasswordInput.resize(%xPos, %yPos, %xExtent, %yExtent);

   // Input labels are 231x25
   %xExtent = mRound(231 * %useScale);
   %yExtent = mRound(25 * %useScale);

   // User name label is positioned at 672,314
   %xPos = mRound(672 * %useScale) - %cropX;
   %yPos = mRound(314 * %useScale) - %cropY;
   %this->UserNameLabel.resize(%xPos, %yPos, %xExtent, %yExtent);

   // Password label is positioned at 679,382
   %yPos = mRound(382 * %useScale) - %cropY;
   %this->PasswordLabel.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The link labels and buttons are 152x19
   %xExtent = mRound(152 * %useScale);
   %yExtent = mRound(19 * %useScale);
   
   // Signups are at 636,461 and 636,481
   %xPos = mRound(636 * %useScale) - %cropX;
   %yPos = mRound(461 * %useScale) - %cropY;
   %this->SignupText.resize(%xPos, %yPos, %xExtent, %yExtent);
   %yPos = mRound(481 * %useScale) - %cropY;
   %this->SignupButton.resize(%xPos, %yPos, %xExtent, %yExtent);

   // Lost passwords are at 795,461 and 795,481
   %xPos = mRound(795 * %useScale) - %cropX;
   %yPos = mRound(461 * %useScale) - %cropY;
   %this->LostPassText.resize(%xPos, %yPos, %xExtent, %yExtent);
   %yPos = mRound(481 * %useScale) - %cropY;
   %this->LostPassButton.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The enter button is 138x34 and positioned at 821,544
   %xExtent = mRound(138 * %useScale);
   %yExtent = mRound(34 * %useScale);
   %xPos = mRound(821 * %useScale) - %cropX;
   %yPos = mRound(544 * %useScale) - %cropY;
   %this->PlayBtn.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The enter text is 138x19 and positioned at 821,523
   %xExtent = mRound(138 * %useScale);
   %yExtent = mRound(19 * %useScale);
   %xPos = mRound(821 * %useScale) - %cropX;
   %yPos = mRound(523 * %useScale) - %cropY;
   %this->EnterText.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The Prefs and dev mode buttons are 54x41 and positioned at 382,727 with
   // 18 pixels between horizontally
   %xExtent = mRound(54 * %useScale);
   %yExtent = mRound(41 * %useScale);
   %xPos = mRound(382 * %useScale) - %cropX;
   %yPos = mRound(727 * %useScale) - %cropY;
   %textYPos = mRound(705 * %useScale) - %cropY;
   %textYExtent = mRound(19 * %useScale);
   %this->PrefsText.resize(%xPos, %textYPos, %xExtent, %textYExtent);
   %this->PrefsBtn.resize(%xPos, %yPos, %xExtent, %yExtent);
   
   %xPos += mRound(72 * %useScale); // 54 width + 18 spacing = 72
   %this->DevText.resize(%xPos, %textYPos, %xExtent, %textYExtent);
   %this->DevBtn.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The exit button is 54x41 and positioned at 1174,727
   %xPos = mRound(1174 * %useScale) - %cropX;
   %this->ExitText.resize(%xPos, %textYPos, %xExtent, %textYExtent);
   %this->ExitBtn.resize(%xPos, %yPos, %xExtent, %yExtent);
}

function LoginGui::resizeFonts(%this, %scaleFactor)
{
   // Torque adjusts font sizes, to get the true point size we need to increase
   // the requested point size x1.6 for Trajan and x1.2 for Arial
   %trajanMult = 1.6;
   %arialMult = 1.2;
   
   // The text input font is 16 point
   %fontPoint = 14 * %scaleFactor;
   AVLoginEditProfile.fontSize = mRound(%fontPoint * %arialMult);
   AVLoginLabelProfile.fontsize = mRound(%fontPoint * %trajanMult);

   // The button font is 12 point
   %fontPoint = 12 * %scaleFactor;
   AVLoginButtonProfile.fontSize = mRound(%fontPoint * %trajanMult);
   AVLoginLinkProfile.fontSize = mRound(%fontPoint * %trajanMult);
}

function LoginGui::onEnterButton(%this)
{
   %this.setActive( false );
   %this.stopLoginMusic();
   $InitialConnection = true;
   
   $pref::Player::Name = %this->UserNameInput.getText();
   $currentUsername = $pref::Player::Name;
   
   %tmpPswd = %this->PasswordInput.getText();
   
   if( $currentUsername $= "" || %tmpPswd $= "" )
   {  
      processLoginFailure( "Invalid user name or password" );
      return;
   }

   // If a password was entered, create a new hash
   %pwLen = strlen(%tmpPswd);
   if ( %pwLen > 0 )
   {
      %hiddenPW = strrepeat("*", %pwLen);
      if (strcmp(%hiddenPW, %tmpPswd) != 0)
      {
         $pref::Player::Hash = getStringMD5( %tmpPswd );
      }
   }
   $pref::Player::Password = %hiddenPW;
   $currentPassword = $pref::Player::Password;
   $currentHash = $pref::Player::Hash;
      
   %this.loginStage1();
}

function LoginGui::loginStage1(%this)
{
   new HttpObject(httpLoginStage1){
      status = "failure";
      message = "";
   };
   
   httpLoginStage1.get( $serverPath, $scriptPath @ "avLoginStage1.php", "uname=" @ $currentUsername );
}

function LoginGui::loginStage2(%this)
{
   // hash our password combined with the supplied hash
   %pwdHash = getStringMD5( $currentHash @ $currentPasswordHash );
      
   new HttpObject(httpLoginStage2){
      status = "failure";
      message = "";
   };
   
   httpLoginStage2.get( $serverPath, 
                        $scriptPath @ "avLoginStage2.php", 
                        "uname=" @ $currentUsername @"\t"@ "pwd=" @ %pwdHash );  
}

// process the results from the stage 1 login request
function httpLoginStage1::process( %this )
{
   switch$( %this.status )
   {
   case "success":
      $currentPasswordHash = %this.hash;
      $currentPlayerID = %this.playerID;
      $pref::Party = %this.playerID;
      
      // login stage 1 complete - server has sent us a hash that we will use
      // to encrypt our password for second stage of login check      
      // move onto stage 2
      LoginGui.loginStage2();
   
   default:
      processLoginFailure( %this.message );
   }
   
   %this.schedule(0, delete);
}

// process the results of the login stage 2 request
function httpLoginStage2::process(%this)
{
   switch$( %this.status )
   {
   case "success":
      // store updated hash string
      $currentPasswordHash = %this.hash;
      // and the server to log into
      $serverToJoin = %this.server;
      // and the manifest paths
      $manifestRoot = %this.manifestRoot;
      $manifestFile = %this.manifestFile;
      // is user a subscriber
      $IsSubscriber = %this.subscriber;
      // the clan that the user belongs to
      $pref::Player::ClanID = %this.clan_id;
      $pref::Player::WorldID = %this.world_id;
      $pref::Player::SkullLevel = %this.skulls;
      %timeLeft = %this.time_left - 3600; // Time zone issue, web reports 1 hour more than the real time
      $AlterVerse::RoundEnd = mFloor(getSimTime() / 1000) + %timeLeft;
      //%timeLeft = %this.time_left - (24 * 60 * 60);
      %timeLeft = %timeLeft - (24 * 60 * 60);
      $cutoffTime = mFloor(getSimTime() / 1000) + %timeLeft;
      $pref::Player::Name = %this.fullName;
      $currentUsername = $pref::Player::Name;

      // login stage 2 complete
      startIntroVideo();
   
   default:
      processLoginFailure( %this.message );
   }
   
   %this.schedule(0, delete);
}

// login failed for some reason
function processLoginFailure( %message )
{
   error( "login failed -" SPC %message );
   MessageBoxOK( "Login Failed", 
                 %message, 
                 "LoginGui.setActive(true);" );
}
