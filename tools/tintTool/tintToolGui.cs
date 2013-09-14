
function TintTool::onWake(%this)
{
   if ( $AlterVerse::AvSet $= "" )
      $AlterVerse::AvSet = "Base";
   %this.FillFixedLists();

   %this.setMode("existing");
   %this.localChanges = false;
   %this.dbChanges = false;
   %this.pendingCommand = "";
   %this.addedItems = "";
   %this.lastOverlayFile = "art/players/base/tints/Tan03.png";
   %this.UpdateState();

   // Put the names into the item list
   %this.curItemID = 0;
   %this.getItemList(true);
}

function TintTool::onSleep(%this)
{
   if ( isObject(%this.curItem) )
      %this.curItem.delete();
}

function TintTool::getItemList(%this, %setSelection)
{
   %category = %this-->CatFilter.getText();
   %subcat = %this-->SubFilter.getText();
   %this.SendDBCommand("GetTintNames", "TCat="@%category@"&TSub="@%subcat, %setSelection);
}

function TintTool::fillItemList(%this, %result)
{
   TintTool-->ItemList.Clear();

	if ( %result.NumTints <= 0 )
	{  // No options found ?!!
	   echo("***No character tints found");
	   return;
	}
	   
   %firstValidId = "";
   %validCurItem = false;
   for ( %i = 0; %i < %result.NumTints; %i++ )
   {
      %curName = GetCommaWord(%result.Tint[%i], 1);
      %curID = GetCommaWord(%result.Tint[%i], 0);
      TintTool-->ItemList.add( %curName, %curID );
      if ( %firstValidId $= "" )
         %firstValidId = %curID;
      if ( %this.curItemID == %curID )
         %validCurItem = true;
   }

   // Select the current item or first in the list if there's no current
   %selectID = ((%this.curItemID > 0) && %validCurItem) ? %this.curItemID : %firstValidId;
   TintTool-->ItemList.setSelected(%selectID, %result.flag);

   if ( %this.pendingCommand !$= "" )
      eval(%this.pendingCommand);
}

function TintTool::setMode(%this, %newMode)
{
   %this.mode = %newMode;
   TintTool-->ItemList.SetActive(%this.mode $= "existing");
   TintTool-->ItemList.SetVisible(%this.mode $= "existing");
   TintTool-->ItemNameEdit.SetActive(%this.mode !$= "existing");
   TintTool-->ItemNameEdit.SetVisible(%this.mode !$= "existing");
   //TintTool-->CategoryText.SetVisible(%this.mode $= "existing");
   TintTool-->CategoryList.SetActive(true);
   TintTool-->CategoryList.SetVisible(true);
   TintTool-->SubCategoryList.SetActive(true);
   TintTool-->SubCategoryList.SetVisible(true);
   TintTool-->UpdateButton.SetText((%this.mode $= "existing") ? "Update DB" : "Add To DB");
}

function TintTool::UpdateState(%this)
{
   TintTool-->UpdateButton.SetActive(%this.localChanges);
}

function TintTool::onLocalChange(%this)
{
   %this.localChanges = true;
   TintTool-->UpdateButton.SetActive(%this.localChanges);
}

function TintTool::FillFixedLists(%this)
{  // Fill in all drop menus that contain fixed lists of options

   // Category filter list. 
   TintTool-->CatFilter.Clear();
   TintTool-->CatFilter.add( "All", 0 );
   TintTool-->CatFilter.add( "Tint", 1 );
   TintTool-->CatFilter.add( "Tatoo", 2 );
   TintTool-->CatFilter.add( "WarPaint", 3 );
   TintTool-->CatFilter.add( "FacialHair", 4 );
   TintTool-->CatFilter.add( "Scar", 5 );
   TintTool-->CatFilter.setSelected(0, false);

   // Sub-Category filter list. 
   TintTool-->SubFilter.Clear();
   TintTool-->SubFilter.add( "All", 0 );
   TintTool-->SubFilter.add( "None", 1 );
   TintTool-->SubFilter.add( "Face", 2 );
   TintTool-->SubFilter.add( "Body", 3 );
   TintTool-->SubFilter.add( "Limbs", 4 );
   TintTool-->SubFilter.setSelected(0, false);

   // Category list. 
   TintTool-->CategoryList.Clear();
   TintTool-->CategoryList.add( "Tint", 0 );
   TintTool-->CategoryList.add( "Tatoo", 1 );
   TintTool-->CategoryList.add( "WarPaint", 2 );
   TintTool-->CategoryList.add( "FacialHair", 3 );
   TintTool-->CategoryList.add( "Scar", 4 );
   TintTool-->CategoryList.setSelected(0, false);

   // Sub-Category list. 
   TintTool-->SubCategoryList.Clear();
   TintTool-->SubCategoryList.add( "None", 0 );
   TintTool-->SubCategoryList.add( "Face", 1 );
   TintTool-->SubCategoryList.add( "Body", 2 );
   TintTool-->SubCategoryList.add( "Limbs", 3 );
   TintTool-->SubCategoryList.setSelected(0, false);

   // Model List (Currently only one for each gender)
   TintToolGenPage-->ModelList.Clear();
   TintToolGenPage-->ModelList.add( "Base", 0 );
   TintToolGenPage-->ModelList.setSelected(0);

   // Gender 
   TintToolGenPage-->GenderList.Clear();
   TintToolGenPage-->GenderList.add( "Male", 0 );
   TintToolGenPage-->GenderList.add( "Female", 1 );
   TintToolGenPage-->GenderList.add( "Unisex", 2 );
   TintToolGenPage-->GenderList.setSelected(0, false);

   // Homeland (Should be filled from DB...) 
   TintToolGenPage-->homeWorldList.Clear();
   TintToolGenPage-->homeWorldList.add( "All", 0 );
   TintToolGenPage-->homeWorldList.add( "Kardia", 1 );
   TintToolGenPage-->homeWorldList.add( "Free Jack", 2 );
   TintToolGenPage-->homeWorldList.add( "Mythriel", 3 );
   TintToolGenPage-->homeWorldList.add( "Valhalla", 4 );
   TintToolGenPage-->homeWorldList.add( "Tokara", 5 );
   TintToolGenPage-->homeWorldList.setSelected(0, false);
}

function TintTool::onItemSelChange(%this)
{
   if ( %this.localChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "TintTool.onItemSelChange();";
      %this.askSaveChange();
      return;
   }

   if ( isObject(%this.curItem) )
      %this.curItem.delete();

   // The current tint selection has changed. Get the data for the new tint
   // from the database.
   %itemID = TintTool-->ItemList.getSelected();
   %this.SendDBCommand("GetTintData", "TID="@%itemID, "");
}

function TintTool::onTintDataRead(%this, %result)
{
   %this.curItem = new ScriptObject() {};
   %this.curItem.ID = GetCommaWord(%result.TintData, 0);
   %this.curItem.Category = GetCommaWord(%result.TintData, 1);
   %this.curItem.model = GetCommaWord(%result.TintData, 2);
   %this.curItem.gender = GetCommaWord(%result.TintData, 3);
   %this.curItem.dispName = GetCommaWord(%result.TintData, 4);
   %this.curItem.overlay = GetCommaWord(%result.TintData, 5);
   %this.curItem.skins = GetCommaWord(%result.TintData, 6);
   %this.curItem.worldSet = GetCommaWord(%result.TintData, 7);
   %this.curItem.SubCategory = GetCommaWord(%result.TintData, 8);

   %this.curItemID = %this.curItem.ID;
   %this.initAllFields(%this.curItem);
   %this.localChanges = false;
   %this.UpdateState();
}

function TintTool::onOverlayEdit(%this)
{
   %path = TintToolGenPage-->OverlayNameEdit.getText();
   if ( isFile(%path) )
      TintToolGenPage-->OverlayBmpCtrl.setBitmap(%path);
   %this.lastOverlayFile = %path;
   %this.localChanges = true;
   %this.UpdateState();
}

function TintTool::onOverlaySelect(%this, %path)
{
   if ( %path $= "" )
      return;

   %path = makeRelativePath( %path, getMainDotCSDir() );

   if ( %path $= %this.lastOverlayFile )
      return;  // Nothings changed

   %this.lastOverlayFile = %path;
   
   TintToolGenPage-->OverlayBmpCtrl.setBitmap(%path);
   TintToolGenPage-->OverlayNameEdit.setText(%path);

   %this.localChanges = true;
   %this.UpdateState();
}

function TintTool::onOverlayBrowsebtn(%this)
{  // Bring up the load dialog to let the user select a new Overlay image
   getLoadFilename( "Image Files|*.png;*.jpg|JPG Files|*.jpg|PNG Files|*.png", %this @ ".onOverlaySelect", %this.lastOverlayFile);
}

function TintTool::initAllFields(%this, %itemDB)
{  // Put the data from the database into all screen controls
   TintTool-->CategoryList.setText(%itemDB.Category);
   TintTool-->SubCategoryList.setText(%itemDB.SubCategory);
   
   %this.initGeneralTab(%itemDB);
}

function TintTool::initGeneralTab(%this, %itemDB)
{
   TintToolGenPage-->ModelList.setSelected(%itemDB.model, false);
   TintToolGenPage-->GenderList.setSelected(%itemDB.gender, false);
   TintToolGenPage-->DispNameEdit.setText(%itemDB.dispName);

   %overLayFile = %itemDB.overlay;
   if ( "/" $= getSubStr(%overLayFile, 0, 1) )
      %overLayFile = "art/players/" @ $AlterVerse::AvSet @ "/tints" @ %overLayFile;

   TintToolGenPage-->OverlayNameEdit.setText(%overLayFile);
   TintToolGenPage-->OverlayBmpCtrl.setBitmap(%overLayFile);
   %this.lastOverlayFile = %overLayFile;

   TintToolGenPage-->skinNamesEdit.setText(%itemDB.skins);
   
   // Fill the holeworld box
   TintToolGenPage-->homeWorldList.setSelected(%itemDB.worldSet, false);
}

function TintTool::saveChanges(%this)
{  // Save all changed fields to the database
   if ( %this.mode !$= "existing" )
   {  // New item so get the name and category.
      %tintName = TintTool-->ItemNameEdit.getText();
      %category = TintTool-->CategoryList.getText();
      if ( %tintName $= "" )
      {
         MessageBoxOK("No Item Name...", "You must enter a unique item name and select a category before the item can be added.");
         %this.pendingCommand = "";
         return;
      }
      
      // Insert a new record in the database
      %this.SendDBCommand("NewTint", "TName="@%tintName@"&TCat="@%category, "");
   }
   else
      %this.doUpdateQuery(false);
}

function TintTool::recordAdded(%this, %result)
{
   // Now read in the record that we just added
   if ( isObject(%this.curItem) )
      %this.curItem.delete();
   %this.curItem = new ScriptObject() {};
   %this.curItem.ID = GetCommaWord(%result.TintData, 0);
   %this.curItem.Category = GetCommaWord(%result.TintData, 1);
   %this.curItem.model = GetCommaWord(%result.TintData, 2);
   %this.curItem.gender = GetCommaWord(%result.TintData, 3);
   %this.curItem.dispName = GetCommaWord(%result.TintData, 4);
   %this.curItem.overlay = GetCommaWord(%result.TintData, 5);
   %this.curItem.skins = GetCommaWord(%result.TintData, 6);
   %this.curItem.worldSet = GetCommaWord(%result.TintData, 7);
   %this.curItem.SubCategory = GetCommaWord(%result.TintData, 8);

   %this.curItemID = %this.curItem.ID;
   %this.dbChanges = true;
   %this.addedItems = true;
   %this.setMode("existing");
   %this.doUpdateQuery(true);
}

function TintTool::doUpdateQuery(%this, %newTint)
{
   // Build the update query for the item
   %queryStr = %this.makeUpdateQS(%this.curItem);

   if ( %queryStr $= "" )
      return;
   
   // If the query begins with a comma, strip it off.
   if ( "," $= getSubStr(%queryStr, 0, 1) )
      %queryStr = getSubStr(%queryStr, 1);
   %fullQuery = "Update AV" @ $AlterVerse::AvSet @ "Tints Set " @ %queryStr @ " Where ID='" @ %this.curItemID @ "'";

   // Send the query to the database
   %this.SendDBCommand("RunTintUpdate", "TID="@%this.curItemID@"&IQY="@%fullQuery, %newTint);
}

function TintTool::updateApplied(%this, %result)
{
   %this.dbChanges = true;
   %this.localChanges = false;
   %this.UpdateState();
   
   if ( isObject(%this.curItem) )
      %this.curItem.delete();
   %this.curItem = new ScriptObject() {};
   %this.curItem.ID = GetCommaWord(%result.TintData, 0);
   %this.curItem.Category = GetCommaWord(%result.TintData, 1);
   %this.curItem.model = GetCommaWord(%result.TintData, 2);
   %this.curItem.gender = GetCommaWord(%result.TintData, 3);
   %this.curItem.dispName = GetCommaWord(%result.TintData, 4);
   %this.curItem.overlay = GetCommaWord(%result.TintData, 5);
   %this.curItem.skins = GetCommaWord(%result.TintData, 6);
   %this.curItem.worldSet = GetCommaWord(%result.TintData, 7);
   %this.curItem.SubCategory = GetCommaWord(%result.TintData, 8);

   %this.curItemID = %this.curItem.ID;

   if ( %result.flag )
      %this.getItemList(false);   
   else if ( %this.pendingCommand !$= "" )
      eval(%this.pendingCommand);
}

function TintTool::makeUpdateQS(%this, %itemDB)
{
   %queryStr = "";
   %queryStr = %this.makeQSGeneralTab(%itemDB, %queryStr);
   
   return %queryStr;
}

function TintTool::makeQSGeneralTab(%this, %itemDB, %queryStr)
{
   %testVal = %this-->CategoryList.getText();
   if ( %itemDB.Category !$= %testVal )
      %queryStr = %queryStr @ ",Category='" @ %testVal @ "'";

   %testVal = %this-->SubCategoryList.getText();
   if ( %itemDB.SubCategory !$= %testVal )
      %queryStr = %queryStr @ ",SubCategory='" @ %testVal @ "'";

   %testVal = TintToolGenPage-->ModelList.getSelected();
   if ( %itemDB.model !$= %testVal )
      %queryStr = %queryStr @ ",model='" @ %testVal @ "'";

   %testVal = TintToolGenPage-->GenderList.getSelected();
   if ( %itemDB.gender != %testVal )
      %queryStr = %queryStr @ ",gender='" @ %testVal @ "'";

   %testVal = TintToolGenPage-->DispNameEdit.getText();
   if ( %itemDB.dispName !$= %testVal )
      %queryStr = %queryStr @ ",dispName='" @ %testVal @ "'";

   %testVal = TintToolGenPage-->OverlayNameEdit.getText();
   if ( %itemDB.Overlay !$= %testVal )
   {
      %testVal = strreplace(%testVal, "art/players/" @ $AlterVerse::AvSet @ "/tints", "");
      %queryStr = %queryStr @ ",Overlay='" @ %testVal @ "'";
   }

   %testVal = TintToolGenPage-->skinNamesEdit.getText();
   if ( %itemDB.skins !$= %testVal )
      %queryStr = %queryStr @ ",skins='" @ %testVal @ "'";
   
   %testVal = TintToolGenPage-->homeWorldList.getSelected();
   if ( %itemDB.worldSet != %testVal )
      %queryStr = %queryStr @ ",worldSet='" @ %testVal @ "'";

   return %queryStr;
}

function TintTool::getCSData(%this)
{
   %this.SendDBCommand("GetTintList", "", "");
}

function TintTool::writeCSFile(%this, %result)
{  // Generate an updated avTints.cs file
   if ( %result.NumTints < 1 )
      return;

   %this.startCSFile();
   
   for ( %i = 0; %i < %result.NumTints; %i++ )
   {
      %this.writeOptionData( %result.Tint[%i] );
   }

   %this.endCSFile();
   
   %message = "Remember to commit the changed file.";
   MessageBoxOK("avTints.cs has been written...", %message, %this.pendingCommand);
}

function TintTool::saveDeclined(%this)
{  // The database update has been declined, so resume the pending command
   if ( %this.pendingCommand !$= "" )
      eval(%this.pendingCommand);
}

function TintTool::askSaveChange(%this)
{  // Bring up a dialog to check if the user wants to save the field changes
   %this.localChanges = false;
   MessageBoxYesNo("Save Fields?", "Would you like to save your changed fields to the database?",
         "TintTool.saveChanges();", "TintTool.saveDeclined();");
}

function TintTool::askCSWrite(%this)
{  // Bring up a dialog to check if the user wants to regenerate the
   // avOptions.cs file
   %this.dbChanges = false;
   MessageBoxYesNo("Generate tints file?", "The changes to the database will not be available in-game until the tints file has been updated. Would you like to generate the avTints.cs file now?",
         "TintTool.getCSData();", "TintTool.saveDeclined();");
}

function TintTool::onNewbtn(%this)
{
   if ( %this.localChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "TintTool.onNewbtn();";
      %this.askSaveChange();
      return;
   }

   %this.curItemID = 0;
   %this.initAllFields("");
   %this.setMode("new");
   %this.UpdateState();
}

function TintTool::onUpdatebtn(%this)
{
   if ( %this.localChanges )
   {
      %this.pendingCommand = "TintTool.onUpdatebtn();";
      %this.localChanges = false;
      %this.saveChanges();
      return;
   }
   
   %this.setMode("existing");
   %this.UpdateState();
}

function TintTool::onClosebtn(%this)
{
   if ( %this.localChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "TintTool.onClosebtn();";
      %this.askSaveChange();
      return;
   }
   
   if ( %this.dbChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "TintTool.onClosebtn();";
      %this.askCSWrite();
      return;
   }
   
   Canvas.popDialog(%this);
}

// Open and put the header lines into avTints.cs
function TintTool::startCSFile(%this)
{
   %filename = "art/players/"@ $AlterVerse::AvSet @ "/avTints.cs";
   %fo = new FileObject();
   
   if ( isObject(%fo) && %fo.openForWrite( %filename ) )
   {
      %fo.writeLine("// Automatically generated avatar tints/tatoos script");
      %fo.writeLine("// File: art/players/" @ $AlterVerse::AvSet @ "/avTints.cs");
      %fo.writeLine("// Do not edit this file directly. Update the database");
      %fo.writeLine("// and use the tint/tatoo tool (ctrl-F6) to regenerate.\n");

      %fo.writeLine("if( isObject( AvatarTints ) )");
      %fo.writeLine("   AvatarTints.delete();");
      %fo.writeLine("new ArrayObject(AvatarTints);\n");
      
      %this.dbicsFile = %fo;
   }
}

// Close the file
function TintTool::endCSFile(%this)
{
   %this.dbicsFile.close();
   %this.dbicsFile.delete();
}

// Write the dataline to define this item
function TintTool::writeOptionData(%this, %dataLine)
{
   %tintID = GetCommaWord(%dataLine, 0);

   %this.dbicsFile.writeLine("AvatarTints.add(" @ %tintID @ ",\"" @ %dataLine @"\");");
}

function TintTool::handleDBResult(%this, %result)
{
   switch$( %result.command )
   {
      case "GetTintNames":
         %this.fillItemList(%result);
      case "GetTintData":
         %this.onTintDataRead(%result);
      case "NewTint":
         %this.recordAdded(%result);
      case "RunTintUpdate":
         %this.updateApplied(%result);
      case "GetTintList":
         %this.writeCSFile(%result);
      default:
         echo("Valid command with no handler??? (" @ %result.command @ ")");
   }
}

function TintTool::SendDBCommand(%this, %command, %params, %flag)
{
   %request = new HTTPObject() {
      class = "getTintData";
      status = "failure";
      message = "";
      command = %command;
      sender = %this;
      flag = %flag;  // Any generic flag data needed by the response processor
   };

   switch$(%command)
   {
      case "GetTintNames":
         %message = "Filling tint list...Please Wait.";
      case "GetTintList":
         %message = "Loading tint data...Please Wait.";
      case "GetTintData":
         %message = "Loading tint data...Please Wait.";
      case "NewTint":
         %message = "Inserting record...Please Wait.";
      default:
         %message = "Updating database...Please Wait.";
   }

   MessageBoxOK("Communicating with database", %message, "");
   MessageBoxOKDlg-->Button0.setVisible(false);

   %argStr = "Cmnd=" @ %command @ "&avSet=" @ $AlterVerse::AvSet;
   if ( %params !$= "" )
      %argStr = %argStr @ "&" @ %params;
   %request.get( $serverPath, "/private_web/" @ "getToolData.php", %argStr );
}

function getTintData::process( %this )
{
   Canvas.popDialog(MessageBoxOKDlg);
   MessageBoxOKDlg-->Button0.setVisible(true);

   switch$( %this.status )
   {
      case "success":
         %this.sender.handleDBResult(%this);
      default:
         echo(%this.message);
         MessageBoxOK( "Database Error", 
                    %this.message );
   }
   %this.schedule(0, delete);
}
