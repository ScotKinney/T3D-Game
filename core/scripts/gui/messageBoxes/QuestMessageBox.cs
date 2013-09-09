//-----------------------------------------------------------------------------
//------------------------------------------------------------------------------
//
// Purpose: Display and process input from a generic message/text input window.
//
// Author: Michael A. Reino
//------------------------------------------------------------------------------

if( !isObject( QuestMessageTitleProfile ) )
   exec("./QuestMessageProfiles.cs");

if( isObject( QuestMessageBox ) )
   QuestMessageBox.delete();
exec("./QuestMessageBox.gui");

//------------------------------------------------------------------------------
function ShowQuestMessageBox(%title, %message, %hasInput, %text1, %callback1,
                          %text2, %callback2, %text3, %callback3,
                          %defaultButton, %initText)
{
   // Set some reasonable defaults
   if ( %hasInput $= "" )
      %hasInput = false;
   if ( %text1 $= "" )
      %text1 = "OK";
   if ( %defaultButton $= "" )
      %defaultButton = 1;

   // Copy control ID's for the buttons to an array
   QuestMessageBox.btnCtrl[1] = QuestMessageBox-->Button1;
   QuestMessageBox.btnCtrl[2] = QuestMessageBox-->Button2;
   QuestMessageBox.btnCtrl[3] = QuestMessageBox-->Button3;
      
   //LoEMessageBoxFrame.text = %title;
   QuestMessageBoxTitle.setText(%title);
   //LoEMessageBox.profile = "GuiOverlayProfile";
   QuestMessageBox.defaultButton = %defaultButton;
   QuestMessageBox.hasInput = %hasInput;

   %numButtons = 0;
   if ( %text1 !$= "" )
   {
      %numButtons++;
      QuestMessageBox.btnCallback1 = %callback1;
      QuestMessageBox-->Button1.setText(%text1);
   }
   if ( %text2 !$= "" )
   {
      %numButtons++;
      QuestMessageBox.btnCallback2 = %callback2;
      QuestMessageBox-->Button2.setText(%text2);
   }
   if ( %text3 !$= "" )
   {
      %numButtons++;
      QuestMessageBox.btnCallback3 = %callback3;
      QuestMessageBox-->Button3.setText(%text3);
   }
   QuestMessageBox.numButtons = %numButtons;
   
   QuestMessageBox-->InputBox.setText(%initText);

   Canvas.pushDialog(QuestMessageBox);
   QuestMessageBox.MBSetText(%message, %title);
}

function QuestMessageBox::MBSetText(%this, %msg, %title)
{
   %vertPadding = 8; // Use 8 pixels vertically between controls
   %headerGap = (%title !$= "" ) ? 28 : 0;
   
   // Set the Title text
   //%ext = %title.getExtent();
   //%title.setText(((%title.format !$= "") ? %title.format : "<just:center>") @ %titleMsg);
   //%title.forceReflow();

   // set the body text
   QuestMessageBoxText.setText(((%textBox.format !$= "") ? %textBox.format : "<just:center>") @ %msg);
   QuestMessageBoxText.forceReflow(); // Force a resize
   
   // Get extents for frame and all controls
   %framePos = QuestMessageBoxFrame.getPosition();
   %frameExtent = QuestMessageBoxFrame.getExtent();
   %textExtent = QuestMessageBoxText.getExtent();
   %inputExtent = %this-->InputBox.getExtent();
   %buttonExtent = %this-->Button1.getExtent();
   
   // Calculate the frame size needed for the text and current window setup
   %frameHeight = getWord(%textExtent, 1) + getWord(%buttonExtent, 1) + (3 * %vertPadding);
   if ( %this.hasInput )
      %frameHeight += getWord(%inputExtent, 1) + %vertPadding;
   %frameHeight += %headerGap;

   // Dock the message box to the top of the chat hud if it's on screen
   if ( Canvas.getContent() == PlayGui.getId() )
   {
      %chatPos = OuterChatHud.getPosition();
      %frameY = getWord(%chatPos, 1) - %frameHeight;
   }
   else
   {
      %screenExtent = Canvas.getExtent();
      %frameY = (getWord(%screenExtent, 1) - %frameHeight) / 2;
   }

   // Resize the frame window before any controls are moved
   //QuestMessageBoxFrame.resize(getWord(%framePos, 0), getWord(%framePos, 1) - ((%frameHeight - getWord(%frameExtent, 1)) / 2),
   QuestMessageBoxFrame.resize(getWord(%framePos, 0), %frameY,
                 getWord(%frameExtent, 0), %frameHeight);
                 
   // Now cascade the controls vertically
   %nextYPos = %vertPadding + %headerGap;
   %curPos = QuestMessageBoxText.getPosition();
   QuestMessageBoxText.resize(getWord(%curPos, 0), %nextYPos,
            getWord(%textExtent, 0), getWord(%textExtent, 1) );
   %nextYPos += getWord(%textExtent, 1) + %vertPadding;

   %this-->InputBox.setVisible(%this.hasInput);   
   if ( %this.hasInput )
   {  // Show the input line
      %curPos = %this-->InputBox.getPosition();
      %this-->InputBox.resize(getWord(%curPos, 0), %nextYPos,
               getWord(%inputExtent, 0), getWord(%inputExtent, 1) );
      %nextYPos += getWord(%inputExtent, 1) + %vertPadding;
   }
   
   // Position the buttons
   %buttonPadding = (getWord(%frameExtent, 0) - (%this.numButtons * getWord(%buttonExtent, 0))) / (%this.numButtons + 1);
   %nextXPos = %buttonPadding;
   %nextYPos = %frameHeight - (getWord(%buttonExtent, 1) + %vertPadding);
   for ( %i = 1; %i <= 3; %i++ )
   {
      if ( %i <= %this.numButtons )
      {
         %this.btnCtrl[%i].resize( %nextXPos, %nextYPos, getWord(%buttonExtent, 0), getWord(%buttonExtent, 1) );
         %this.btnCtrl[%i].setVisible(true);
         %nextXPos += getWord(%buttonExtent, 0) + %buttonPadding;
      }
      else
         %this.btnCtrl[%i].setVisible(false);
   }
   //sfxPlayOnce( messageBoxBeep );
}

function QuestMessageBox::onSleep( %this )
{
   QuestMessageBox.btnCallback1 = "";
   QuestMessageBox.btnCallback2 = "";
   QuestMessageBox.btnCallback3 = "";
}

function QuestMessageBox::MessageCallback( %this, %buttonNum )
{
   if ( %buttonNum == 0 )
      %buttonNum = %this.defaultButton;

   // Save the callback, because poping the dialog will clear it
   %callback = %this.btnCallback[%buttonNum];
   if ( QuestMessageBox.hasInput && (%callback !$= "") )
   {
      %inputText = QuestMessageBox-->InputBox.getText();
      %callback = strreplace(%callback, "#", %inputText);
   }
   
   Canvas.popDialog(QuestMessageBox);
   if ( %callback !$= "" )
      eval(%callback);
}

//PlayGui.ConfirmHorseBuy(100, "Palimino", "Palimino", "3000");