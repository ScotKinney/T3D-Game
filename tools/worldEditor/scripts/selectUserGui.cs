//

function SelectUserGui::onWake(%this)
{
   // No search results yet, so hide the results box
   %this.showResults(false);
}

function SelectUserGui::showResults(%this, %shouldShow)
{
   %this-->scrollControl.setVisible(%shouldShow);
   %yOffset = getWord(%this-->scrollControl.extent,1);
   if ( %shouldShow )
   {
      if ( %this.resultsShown )
         return;

      %this.resultsShown = true;
   }
   else
   {
      if ( !%this.resultsShown )
         return;

      %yOffset = -%yOffset;
      %this.resultsShown = false;
   }

   %this-->Frame.setExtent(getWord(%this-->Frame.extent,0),
         getWord(%this-->Frame.extent,1) + %yOffset);
   %this-->SelectBtn.setPosition(getWord(%this-->SelectBtn.position,0),
         getWord(%this-->SelectBtn.position,1) + %yOffset);
   %this-->CancelBtn.setPosition(getWord(%this-->CancelBtn.position,0),
         getWord(%this-->CancelBtn.position,1) + %yOffset);
}

//------------------------------------------------------------------------------
function SelectUserGui::addSearchResults(%this, %line)
{
   %resCount = getBarWord(%line, 1);      // The number of matches
   %this-->SearchResults.clear();

   for (%i = 0; %i < %resCount; %i++)
   {
      %id = getBarWord(%line, 2 + (%i*2));
      %name = getBarWord(%line, 3 + (%i*2));
      %this-->SearchResults.addRow(%id, %name);
   }

   if (%resCount == 0)
      %this-->SearchResults.addRow("-1", guiStrings.noResults);
   else
      %this-->SearchResults.sort(0, true);

   %this.showResults(true);
}

//------------------------------------------------------------------------------
function SelectUserGui::onNameClick(%this)
{  // A name in the search results has been clicked
   %playerID = %this-->SearchResults.getSelectedId();
   if ( %playerID == -1 )
      return; // No results

   %text = %this-->SearchResults.getRowTextById(%playerID);
   %name = getField(%text, 0);

   // Copy the name into the text box
   %this-->EditControl.setText(%name);
}

//------------------------------------------------------------------------------
function SelectUserGui::onSearchButton(%this)
{
   %text = %this-->EditControl.getText();
   clientChat.searchCtrl = %this;
   sendChatCommand("psrch|" @ %text);
   return;
}

//------------------------------------------------------------------------------
function SelectUserGui::onSelectClick(%this)
{
   %text = %this-->EditControl.getText();
   if ( %text $= "" )
      return;

   %this.callingCtrl.userSelected(%text);
   Canvas.popDialog(%this);
}

