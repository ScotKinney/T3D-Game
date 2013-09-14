
function OptionTool::onWake(%this)
{
   if ( $AlterVerse::AvSet $= "" )
      $AlterVerse::AvSet = "Base";
   %this.FillFixedLists();   

   %this.setMode("existing");
   %this.localChanges = false;
   %this.dbChanges = false;
   %this.pendingCommand = "";
   %this.addedItems = "";
   %this.UpdateState();

   // Put the names into the item list
   %this.curItemID = 0;
   %this.getItemList(true);
}

function OptionTool::onSleep(%this)
{
}

function OptionTool::getItemList(%this, %setSelection)
{
   %this.SendDBCommand("GetOptNames", "", %setSelection);
}

function OptionTool::fillItemList(%this, %result)
{
   OptionTool-->ItemList.Clear();

	if ( %result.NumOptions <= 0 )
	{  // No options found ?!!
	   echo("***No character options found");
	   return;
	}
	   
   %firstValidId = "";
   for ( %i = 0; %i < %result.NumOptions; %i++ )
   {
      %curName = GetCommaWord(%result.Option[%i], 1);
      %curID = GetCommaWord(%result.Option[%i], 0);
      OptionTool-->ItemList.add( %curName, %curID );
      if ( %firstValidId $= "" )
         %firstValidId = %curID;
   }

   // Select the current item or first in the list if there's no current
   %selectID = (%this.curItemID > 0) ? %this.curItemID : %firstValidId;
   OptionTool-->ItemList.setSelected(%selectID, %result.flag);

   if ( %this.pendingCommand !$= "" )
      eval(%this.pendingCommand);
}

function OptionTool::setMode(%this, %newMode)
{
   %this.mode = %newMode;
   OptionTool-->ItemList.SetActive(%this.mode $= "existing");
   OptionTool-->ItemList.SetVisible(%this.mode $= "existing");
   OptionTool-->ItemNameEdit.SetActive(%this.mode !$= "existing");
   OptionTool-->ItemNameEdit.SetVisible(%this.mode !$= "existing");
   
   OptionTool-->CategoryList.SetActive(true);
   OptionTool-->CategoryList.SetVisible(true);
   OptionTool-->UpdateButton.SetText((%this.mode $= "existing") ? "Update DB" : "Add To DB");
}

function OptionTool::UpdateState(%this)
{
   OptionTool-->UpdateButton.SetActive(%this.localChanges);
}

function OptionTool::onLocalChange(%this)
{
   %this.localChanges = true;
   OptionTool-->UpdateButton.SetActive(%this.localChanges);
}

function OptionTool::FillFixedLists(%this)
{  // Fill in all drop menus that contain fixed lists of options

   // Category list. 
   OptionTool-->CategoryList.Clear();
   OptionTool-->CategoryList.add( "Face", 0 );
   OptionTool-->CategoryList.add( "SkinTone", 1 );
   OptionTool-->CategoryList.add( "HairStyle", 2 );
   OptionTool-->CategoryList.add( "EyeColor", 3 );
   OptionTool-->CategoryList.add( "FacialHair", 4 );
   OptionTool-->CategoryList.add( "Head", 5 );
   OptionTool-->CategoryList.add( "Shirt", 6 );
   OptionTool-->CategoryList.add( "Pant", 7 );
   OptionTool-->CategoryList.add( "Glove", 8 );
   OptionTool-->CategoryList.add( "Feet", 9 );
   OptionTool-->CategoryList.add( "Misc", 10 );
   OptionTool-->CategoryList.add( "Makeup", 11 );
   OptionTool-->CategoryList.add( "Shin", 12 );
   OptionTool-->CategoryList.add( "Thigh", 13 );
   OptionTool-->CategoryList.add( "ForeArm", 14 );
   OptionTool-->CategoryList.add( "Arm", 15 );
   OptionTool-->CategoryList.add( "Cape", 16 );
   OptionTool-->CategoryList.setSelected(0);

   // Model List (Currently only one for each gender)
   OptToolGenPage-->ModelList.Clear();
   OptToolGenPage-->ModelList.add( "Base", 0 );
   OptToolGenPage-->ModelList.setSelected(0);

   // Gender 
   OptToolGenPage-->GenderList.Clear();
   OptToolGenPage-->GenderList.add( "Male", 0 );
   OptToolGenPage-->GenderList.add( "Female", 1 );
   OptToolGenPage-->GenderList.add( "Unisex", 2 );
   OptToolGenPage-->GenderList.setSelected(0);

   // Homeland (Should be filled from DB...) 
   OptToolGenPage-->homeWorldList.Clear();
   OptToolGenPage-->homeWorldList.add( "All", 0 );
   OptToolGenPage-->homeWorldList.add( "Kardia", 1 );
   OptToolGenPage-->homeWorldList.add( "Free Jack", 2 );
   OptToolGenPage-->homeWorldList.add( "Mythriel", 3 );
   OptToolGenPage-->homeWorldList.add( "Valhalla", 4 );
   OptToolGenPage-->homeWorldList.add( "Tokara", 5 );
   OptToolGenPage-->homeWorldList.setSelected(0);
}

function OptionTool::onItemSelChange(%this)
{
   if ( %this.localChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "OptionTool.onItemSelChange();";
      %this.askSaveChange();
      return;
   }

   if ( isObject(%this.curItem) )
      %this.curItem.delete();

   // The current item selection has changed. Get the data for the new option
   // from the database.
   %itemID = OptionTool-->ItemList.getSelected();
   %this.SendDBCommand("GetOptData", "OID="@%itemID, %itemID);
}

function OptionTool::makeCurItem(%this, %result)
{
   if ( isObject(%this.curItem) )
      %this.curItem.delete();
   %this.curItem = new ScriptObject() {};

   %this.curItem.ID = GetCommaWord(%result.OptionData, 0);
   %this.curItem.Category = GetCommaWord(%result.OptionData, 1);
   %this.curItem.model = GetCommaWord(%result.OptionData, 2);
   %this.curItem.gender = GetCommaWord(%result.OptionData, 3);
   %this.curItem.dispName = GetCommaWord(%result.OptionData, 4);
   %this.curItem.showMesh = GetCommaWord(%result.OptionData, 5);
   %this.curItem.hideMesh = GetCommaWord(%result.OptionData, 6);

   // 7 - 24
   for (%i = 1; %i < 7; %i++)
   {
      %this.curItem.reskin[%i] = GetCommaWord(%result.OptionData, 7 + ((%i-1) * 3));
      %this.curItem.skin[%i] = GetCommaWord(%result.OptionData, 8 + ((%i-1) * 3));
      %this.curItem.mat[%i] = GetCommaWord(%result.OptionData, 9 + ((%i-1) * 3));
   }

   // 25 - 54
   for (%i = 1; %i < 6; %i++)
   {
      %this.curItem.mount[%i] = GetCommaWord(%result.OptionData, 25 + ((%i-1) * 6));
      %this.curItem.node[%i] = GetCommaWord(%result.OptionData, 26 + ((%i-1) * 6));
      %this.curItem.shape[%i] = GetCommaWord(%result.OptionData, 27 + ((%i-1) * 6));
      %this.curItem.reskinMt[%i] = GetCommaWord(%result.OptionData, 28 + ((%i-1) * 6));
      %this.curItem.mtSkin[%i] = GetCommaWord(%result.OptionData, 29 + ((%i-1) * 6));
      %this.curItem.mtMat[%i] = GetCommaWord(%result.OptionData, 30 + ((%i-1) * 6));
   }

   %this.curItem.worldSet = GetCommaWord(%result.OptionData, 55);
   %this.curItemID = %this.curItem.ID;
}

function OptionTool::onOptDataRead(%this, %result)
{
   %this.makeCurItem(%result);
   %this.initAllFields(%this.curItem);
   %this.localChanges = false;
   %this.UpdateState();
}

function OptionTool::onIconEdit(%this)
{
   %path = OptToolGenPage-->IconNameEdit.getText();
   if ( isFile(%path) )
      OptToolGenPage-->IconBmpCtrl.setBitmap(%path);
   %this.lastIconFile = %path;
   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onIconSelect(%this, %path)
{
   if ( %path $= "" )
      return;

   %path = makeRelativePath( %path, getMainDotCSDir() );

   if ( %path $= %this.lastIconFile )
      return;  // Nothings changed

   %this.lastIconFile = %path;
   
   OptToolGenPage-->IconBmpCtrl.setBitmap(%path);
   OptToolGenPage-->IconNameEdit.setText(%path);

   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onIconBrowsebtn(%this)
{  // Bring up the load dialog to let the user select a new icon image
   getLoadFilename( "Image Files|*.png;*.jpg|JPG Files|*.jpg|PNG Files|*.png", %this @ ".onIconSelect", %this.lastIconFile);
}

function OptionTool::onTextureSelect(%this, %path)
{
   if ( %path $= "" )
      return;

   %path = makeRelativePath( %path, getMainDotCSDir() );

   if ( %path $= %this.lastTextureFile )
      return;  // Nothings changed

   %this.lastTextureFile = %path;

   if ( %this.curPage $= "Mesh" )
      %fieldName = "Reskin" @ %this.curCtrlIdx @ "TexEdit";
   else
      %fieldName = "Mountskin" @ %this.curCtrlIdx @ "TexEdit";
   %editCtrl = %this.findObjectByInternalName(%fieldName, true);

   %editCtrl.setText(%path);

   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onTextureBrowsebtn(%this, %tabPage, %ctrlIdx)
{  // Bring up the load dialog to let the user select a texture file
   %this.curPage = %tabPage;
   %this.curCtrlIdx = %ctrlIdx;

   if ( %this.curPage $= "Mesh" )
      %fieldName = "Reskin" @ %this.curCtrlIdx @ "TexEdit";
   else
      %fieldName = "Mountskin" @ %this.curCtrlIdx @ "TexEdit";
   %editCtrl = %this.findObjectByInternalName(%fieldName, true);
   %curPath = %editCtrl.getText();
   if ( %curPath !$= "" )
      %this.lastTextureFile = %curPath;

   getLoadFilename( "Image Files|*.png;*.jpg|JPG Files|*.jpg|PNG Files|*.png", %this @ ".onTextureSelect", %this.lastTextureFile);
}

function OptionTool::onShapeEdit(%this)
{
   %path = OptToolGenPage-->ShapeNameEdit.getText();
   if ( !isFile(%path) )
      %path = "art/shapes/rocks/rock1.dts";
   %this.lastShapeFile = %path;
   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onShapeSelect(%this, %path)
{
   if ( (%path $= "") || (%path $= %this.lastShapeFile) )
      return;  // Nothings changed

   %path = makeRelativePath( %path, getMainDotCSDir() );
   %this.lastShapeFile = %path;
   OptToolGenPage-->ShapeNameEdit.setText(%path);
   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onShapeBrowsebtn(%this)
{  // Bring up the load dialog to let the user select a new world shape
   getLoadFilename( "Shape Files|*.dts;*.dae|DTS Files|*.dts|COLLADA Files|*.dae", %this @ ".onShapeSelect", %this.lastShapeFile);
}

function OptionTool::onReskinCheck(%this, %skinIdx)
{
   %fieldName = "Reskin" @ %skinIdx @ "Check";
   %checkCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Reskin" @ %skinIdx @ "NameEdit";
   %editCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Reskin" @ %skinIdx @ "TexEdit";
   %matCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Reskin" @ %skinIdx @ "TexBrowse";
   %browseCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);

   %doReskin = %checkCtrl.getValue();
   %editCtrl.setActive(%doReskin);
   %matCtrl.setActive(%doReskin);
   %browseCtrl.setActive(%doReskin);
   
   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onMountCheck(%this, %mountIdx)
{
   %fieldName = "Mount" @ %mountIdx @ "Check";
   %checkCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mount" @ %mountIdx @ "NodeEdit";
   %nodeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mount" @ %mountIdx @ "ShapeEdit";
   %shapeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mount" @ %mountIdx @ "Browse";
   %shapeBrowse = OptToolMountPage.findObjectByInternalName(%fieldName, true);

   %fieldName = "Mountskin" @ %mountIdx @ "Check";
   %skinCheckCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mountskin" @ %mountIdx @ "NameEdit";
   %skinEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mountskin" @ %mountIdx @ "TexEdit";
   %matCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mountskin" @ %mountIdx @ "TexBrowse";
   %matBrowse = OptToolMountPage.findObjectByInternalName(%fieldName, true);

   %mountMesh = %checkCtrl.getValue();
   %nodeEdit.setActive(%mountMesh);
   %shapeEdit.setActive(%mountMesh);
   %shapeBrowse.setActive(%mountMesh);
   
   %skinCheckCtrl.setActive(%mountMesh);
   %doReskin = %skinCheckCtrl.getValue();
   %skinEdit.setActive(%mountMesh && %doReskin);
   %matCtrl.setActive(%mountMesh && %doReskin);
   %matBrowse.setActive(%mountMesh && %doReskin);

   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onMountskinCheck(%this, %mountIdx)
{
   %fieldName = "Mountskin" @ %mountIdx @ "Check";
   %skinCheckCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mountskin" @ %mountIdx @ "NameEdit";
   %skinEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mountskin" @ %mountIdx @ "TexEdit";
   %matCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %fieldName = "Mountskin" @ %mountIdx @ "TexBrowse";
   %matBrowse = OptToolMountPage.findObjectByInternalName(%fieldName, true);

   %doReskin = %skinCheckCtrl.getValue();
   %skinEdit.setActive(%doReskin);
   %matCtrl.setActive(%doReskin);
   %matBrowse.setActive(%doReskin);

   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::onMountBrowsebtn(%this, %mountIdx)
{
   %this.mountIdx = %mountIdx;
   %fieldName = "Mount" @ %mountIdx @ "ShapeEdit";
   %shapeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %this.lastMountShape = %shapeEdit.getText();
   if ( %this.lastMountShape $= "" )
      %this.lastMountShape = "art/shapes/rocks/rock1.dts";

   getLoadFilename( "Shape Files|*.dts;*.dae|DTS Files|*.dts|COLLADA Files|*.dae", %this @ ".onMountShapeSelect", %this.lastMountShape);
}

function OptionTool::onMountShapeSelect(%this, %path)
{
   if ( %path $= "" )
      return;  // Cancel pressed

   %path = makeRelativePath( %path, getMainDotCSDir() );
   if ( %path $= %this.lastMountShape )
      return;  // Same shape name

   %fieldName = "Mount" @ %this.mountIdx @ "ShapeEdit";
   %shapeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
   %shapeEdit.setText(%path);

   %this.localChanges = true;
   %this.UpdateState();
}

function OptionTool::initAllFields(%this, %itemDB)
{  // Put the data from the database into all screen controls
   //OptionTool-->CategoryText.setText(" " @ %itemDB.Category);
   OptionTool-->CategoryList.setText(%itemDB.Category);
   
   %this.initGeneralTab(%itemDB);
   %this.initMeshTab(%itemDB);
   %this.initMountsTab(%itemDB);
   %this.initDescriptionTab(%itemDB);
}

function OptionTool::initGeneralTab(%this, %itemDB)
{
   OptToolGenPage-->ModelList.setSelected(%itemDB.model, false);
   OptToolGenPage-->GenderList.setSelected(%itemDB.gender, false);
   OptToolGenPage-->DispNameEdit.setText(%itemDB.dispName);

   OptToolGenPage-->IconNameEdit.setText(%itemDB.icon);
   OptToolGenPage-->IconBmpCtrl.setBitmap(%itemDB.icon);
   %this.lastIconFile = %itemDB.icon;

   OptToolGenPage-->ShapeNameEdit.setText(%itemDB.shape);

   // Fill the holeworld box
   OptToolGenPage-->homeWorldList.setSelected(%itemDB.worldSet, false);
}

function OptionTool::initMeshTab(%this, %itemDB)
{
   OptToolMeshPage-->ShowMeshEdit.setText(%itemDB.showMesh);
   OptToolMeshPage-->HideMeshEdit.setText(%itemDB.hideMesh);
   
   for ( %i = 1; %i < 7; %i++ )
   {
      %fieldName = "Reskin" @ %i @ "Check";
      %checkCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Reskin" @ %i @ "NameEdit";
      %editCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Reskin" @ %i @ "TexEdit";
      %matCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Reskin" @ %i @ "TexBrowse";
      %matBrowse = OptToolMeshPage.findObjectByInternalName(%fieldName, true);

      %checkCtrl.setValue(%itemDB.reskin[%i]);
      %editCtrl.setActive(%itemDB.reskin[%i]);     
      %matCtrl.setActive(%itemDB.reskin[%i]);
      %matBrowse.setActive(%itemDB.reskin[%i]);
      if ( %itemDB.reskin[%i] )
      {   
         %editCtrl.setText(%itemDB.skin[%i]);
         %texFile = %itemDB.mat[%i];
         if ( "/" $= getSubStr(%texFile, 0, 1) )
            %texFile = "art/players/" @ $AlterVerse::AvSet @ %texFile;
         %matCtrl.setText(%texFile);
      }
      else
      {
         %editCtrl.setText("");
         %matCtrl.setText("");
      }
   }
}

function OptionTool::initMountsTab(%this, %itemDB)
{
   for ( %i = 1; %i < 6; %i++ )
   {
      %fieldName = "Mount" @ %i @ "Check";
      %checkCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mount" @ %i @ "NodeEdit";
      %nodeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mount" @ %i @ "ShapeEdit";
      %shapeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mount" @ %i @ "Browse";
      %shapeBrowse = OptToolMountPage.findObjectByInternalName(%fieldName, true);

      %fieldName = "Mountskin" @ %i @ "Check";
      %skinCheckCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mountskin" @ %i @ "NameEdit";
      %skinEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mountskin" @ %i @ "TexEdit";
      %matCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mountskin" @ %i @ "TexBrowse";
      %matBrowse = OptToolMountPage.findObjectByInternalName(%fieldName, true);

      %checkCtrl.setValue(%itemDB.mount[%i]);
      %nodeEdit.setActive(%itemDB.mount[%i]);
      %shapeEdit.setActive(%itemDB.mount[%i]);
      %shapeBrowse.setActive(%itemDB.mount[%i]);
      %nodeEdit.setText((%itemDB.mount[%i] ? %itemDB.node[%i] : ""));
      %shapeEdit.setText((%itemDB.mount[%i] ? %itemDB.shape[%i] : ""));

      %skinCheckCtrl.setActive(%itemDB.mount[%i]);
      %skinCheckCtrl.setValue(%itemDB.reskinMt[%i]);
      %skinEdit.setActive(%itemDB.mount[%i] && %itemDB.reskinMt[%i]);
      %matCtrl.setActive(%itemDB.mount[%i] && %itemDB.reskinMt[%i]);
      if ( %itemDB.mount[%i] && %itemDB.reskinMt[%i] )
      {
         %skinEdit.setText(%itemDB.mtSkin[%i]);
         %texFile = %itemDB.mtMat[%i];
         if ( "/" $= getSubStr(%texFile, 0, 1) )
            %texFile = "art/players/" @ $AlterVerse::AvSet @ %texFile;
         %matCtrl.setText(%texFile);
      }
      else
      {
         %skinEdit.setText("");
         %matCtrl.setText("");
      }
   }
}

function OptionTool::initDescriptionTab(%this, %itemDB)
{
   %this.lastDescription = "";
   if ( %this.curItemID > 0 )
   {  // Load the description and fill in the text
      %file = new FileObject();      
      if( isObject(%file) )
      {
         %fileName = "art/gui/itemData/item" @ %this.curItemID @ ".dat";
         if ( %file.openForRead(%fileName) )
         {
            while ( !%file.isEOF() )
            {
               %line = %file.readLine();
               %this.lastDescription = %this.lastDescription @ %line @ "\n";
            }
            %file.close();
         }
         %file.delete();
      }
   }
   
   OptToolDescPage-->DescEdit.setText(%this.lastDescription);
}

function OptionTool::saveDescriptionTab(%this, %itemDB)
{
   %newDesc = OptToolDescPage-->DescEdit.getText(%this.lastDescription);

   if ( (%this.curItemID > 0) && (%newDesc !$= %this.lastDescription) )
   {  // Save the description contents to disk
      %file = new FileObject();      
      if( isObject(%file) )
      {
         %fileName = "art/gui/itemData/item" @ %this.curItemID @ ".dat";
         if ( %file.openForWrite(%fileName) )
         {
            %file.writeLine(%newDesc);
            %this.lastDescription = %newDesc;
            %file.close();
         }
         %file.delete();
      }
   }   
}

function OptionTool::saveChanges(%this)
{  // Save all changed fields to the database
   if ( %this.mode !$= "existing" )
   {  // New item so get the name and category.
      %itemName = OptionTool-->ItemNameEdit.getText();
      %category = OptionTool-->CategoryList.getText();
      if ( %itemName $= "" )
      {
         MessageBoxOK("No Item Name...", "You must enter a unique item name and select a category before the item can be added.");
         %this.pendingCommand = "";
         return;
      }
      
      // Insert a new record in the database
      %this.SendDBCommand("NewOption", "OName="@%itemName@"&OCat="@%category, "");
   }
   else
      %this.doUpdateQuery(false);
}

function OptionTool::recordAdded(%this, %result)
{
   // A new record has been added, read it int curItem
   %this.makeCurItem(%result);

   %this.dbChanges = true;
   %this.addedItems = true;
   %this.setMode("existing");
   %this.doUpdateQuery(true);
}

function OptionTool::doUpdateQuery(%this, %newOpt)
{
   // Build the update query for the item
   %queryStr = %this.makeUpdateQS(%this.curItem);

   if ( %queryStr $= "" )
      return;
   
   // If the query begins with a comma, strip it off.
   if ( "," $= getSubStr(%queryStr, 0, 1) )
      %queryStr = getSubStr(%queryStr, 1);
   %fullQuery = "Update AV" @ $AlterVerse::AvSet @ "Options Set " @ %queryStr @ " Where ID='" @ %this.curItemID @ "'";

   // Send the query to the database
   %this.SendDBCommand("RunOptUpdate", "OID="@%this.curItemID@"&IQY="@%fullQuery, %newOpt);
}

function OptionTool::updateApplied(%this, %result)
{
   %this.dbChanges = true;
   %this.localChanges = false;
   %this.UpdateState();
   %this.makeCurItem(%result);

   if ( %result.flag )
      %this.getItemList(false);   
   else if ( %this.pendingCommand !$= "" )
      eval(%this.pendingCommand);
}

function OptionTool::makeUpdateQS(%this, %itemDB)
{
   %queryStr = "";

   // Add in the category if it has changed
   %testVal = %this-->CategoryList.getText();
   if ( %itemDB.Category !$= %testVal )
      %queryStr = %queryStr @ ",Category='" @ %testVal @ "'";
   
   %queryStr = %this.makeQSGeneralTab(%itemDB, %queryStr);
   %queryStr = %this.makeQSMeshTab(%itemDB, %queryStr);
   %queryStr = %this.makeQSMountsTab(%itemDB, %queryStr);
   %this.saveDescriptionTab(%itemDB);
   
   return %queryStr;
}

function OptionTool::makeQSGeneralTab(%this, %itemDB, %queryStr)
{
   %testVal = OptToolGenPage-->ModelList.getSelected();
   if ( %itemDB.model !$= %testVal )
      %queryStr = %queryStr @ ",model='" @ %testVal @ "'";

   %testVal = OptToolGenPage-->GenderList.getSelected();
   if ( %itemDB.gender != %testVal )
      %queryStr = %queryStr @ ",gender='" @ %testVal @ "'";

   %testVal = OptToolGenPage-->DispNameEdit.getText();
   if ( %itemDB.dispName !$= %testVal )
      %queryStr = %queryStr @ ",dispName='" @ %testVal @ "'";

   %testVal = OptToolGenPage-->IconNameEdit.getText();
   if ( %itemDB.icon !$= %testVal )
   {
      %testVal = strreplace(%testVal, "art/gui/icons", "");
      %queryStr = %queryStr @ ",icon='" @ %testVal @ "'";
   }

   %testVal = OptToolGenPage-->ShapeNameEdit.getText();
   %testVal = strreplace(%testVal, "art/players/" @ $AlterVerse::AvSet, "");
   if ( %itemDB.shape !$= %testVal )
      %queryStr = %queryStr @ ",shape='" @ %testVal @ "'";

   %testVal = OptToolGenPage-->homeWorldList.getSelected();
   if ( %itemDB.worldSet != %testVal )
      %queryStr = %queryStr @ ",worldSet='" @ %testVal @ "'";

   return %queryStr;
}

function OptionTool::makeQSMeshTab(%this, %itemDB, %queryStr)
{
   %testVal = OptToolMeshPage-->ShowMeshEdit.getText();
   if ( %itemDB.showMesh !$= %testVal )
      %queryStr = %queryStr @ ",showMesh='" @ %testVal @ "'";

   %testVal = OptToolMeshPage-->HideMeshEdit.getText();
   if ( %itemDB.hideMesh !$= %testVal )
      %queryStr = %queryStr @ ",hideMesh='" @ %testVal @ "'";
   
   for ( %i = 1; %i < 7; %i++ )
   {
      %fieldName = "Reskin" @ %i @ "Check";
      %checkCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Reskin" @ %i @ "NameEdit";
      %editCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Reskin" @ %i @ "TexEdit";
      %matCtrl = OptToolMeshPage.findObjectByInternalName(%fieldName, true);
      
      %doReskin = %checkCtrl.getValue();
      if ( %doReskin != %itemDB.reskin[%i] )
         %queryStr = %queryStr @ ",reskin" @ %i @ "=b'" @ %doReskin @ "'";

      %testVal = ( %doReskin ? %editCtrl.getText() : "" );
      if ( %itemDB.skin[%i] !$= %testVal )
         %queryStr = %queryStr @ ",skin" @ %i @ "='" @ %testVal @ "'";

      %testVal = ( %doReskin ? %matCtrl.getText() : "" );
      %testVal = strreplace(%testVal, "art/players/" @ $AlterVerse::AvSet, "");
      if ( %itemDB.mat[%i] !$= %testVal )
         %queryStr = %queryStr @ ",mat" @ %i @ "='" @ %testVal @ "'";
   }

   return %queryStr;
}

function OptionTool::makeQSMountsTab(%this, %itemDB, %queryStr)
{
   for ( %i = 1; %i < 6; %i++ )
   {
      %fieldName = "Mount" @ %i @ "Check";
      %checkCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mount" @ %i @ "NodeEdit";
      %nodeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mount" @ %i @ "ShapeEdit";
      %shapeEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);

      %fieldName = "Mountskin" @ %i @ "Check";
      %skinCheckCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mountskin" @ %i @ "NameEdit";
      %skinEdit = OptToolMountPage.findObjectByInternalName(%fieldName, true);
      %fieldName = "Mountskin" @ %i @ "TexEdit";
      %matCtrl = OptToolMountPage.findObjectByInternalName(%fieldName, true);

      %useMount = %checkCtrl.getValue();
      if ( %useMount != %itemDB.mount[%i] )
         %queryStr = %queryStr @ ",mount" @ %i @ "=b'" @ %useMount @ "'";

      %testVal = ( %useMount ? %nodeEdit.getText() : "" );
      if ( %itemDB.node[%i] !$= %testVal )
         %queryStr = %queryStr @ ",node" @ %i @ "='" @ %testVal @ "'";

      %testVal = ( %useMount ? %shapeEdit.getText() : "" );
      %testVal = strreplace(%testVal, "art/players/" @ $AlterVerse::AvSet, "");
      if ( %itemDB.shape[%i] !$= %testVal )
         %queryStr = %queryStr @ ",shape" @ %i @ "='" @ %testVal @ "'";

      %doReskin = (%skinCheckCtrl.getValue() && %useMount);
      if ( %doReskin != %itemDB.reskinMt[%i] )
         %queryStr = %queryStr @ ",reskinMt" @ %i @ "=b'" @ %doReskin @ "'";

      %testVal = ( %doReskin ? %skinEdit.getText() : "" );
      if ( %itemDB.mtSkin[%i] !$= %testVal )
         %queryStr = %queryStr @ ",mtSkin" @ %i @ "='" @ %testVal @ "'";

      %testVal = ( %doReskin ? %matCtrl.getText() : "" );
      %testVal = strreplace(%testVal, "art/players/" @ $AlterVerse::AvSet, "");
      if ( %itemDB.mtMat[%i] !$= %testVal )
         %queryStr = %queryStr @ ",mtMat" @ %i @ "='" @ %testVal @ "'";
   }

   return %queryStr;
}

function OptionTool::getCSData(%this)
{
   %this.SendDBCommand("GetOptList", "", "");
}

function OptionTool::writeCSFile(%this, %result)
{  // Generate an updated avOptions.cs file
   if ( %result.NumOptions < 1 )
      return;

   %this.startCSFile();
   
   for ( %i = 0; %i < %result.NumOptions; %i++ )
   {
      %this.writeOptionData( %result.Option[%i] );
   }

   %this.endCSFile();
   
   %message = "Remember to commit the changed file.";
   if ( %this.addedItems !$= "" )
      %message = %message @ "\nAlso add any new description files in art/gui/itemData to the svn.";
   MessageBoxOK("avOptions.cs has been written...", %message, %this.pendingCommand);
}

function OptionTool::saveDeclined(%this)
{  // The database update has been declined, so resume the pending command
   if ( %this.pendingCommand !$= "" )
      eval(%this.pendingCommand);
}

function OptionTool::askSaveChange(%this)
{  // Bring up a dialog to check if the user wants to save the field changes
   %this.localChanges = false;
   MessageBoxYesNo("Save Fields?", "Would you like to save your changed fields to the database?",
         "OptionTool.saveChanges();", "OptionTool.saveDeclined();");
}

function OptionTool::askCSWrite(%this)
{  // Bring up a dialog to check if the user wants to regenerate the
   // avOptions.cs file
   %this.dbChanges = false;
   MessageBoxYesNo("Generate options file?", "The changes to the database will not be available in-game until the options file has been updated. Would you like to generate the avOptions.cs file now?",
         "OptionTool.getCSData();", "OptionTool.saveDeclined();");
}

function OptionTool::onNewbtn(%this)
{
   if ( %this.localChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "OptionTool.onNewbtn();";
      %this.askSaveChange();
      return;
   }

   %this.curItemID = 0;
   %this.initAllFields("");
   %this.setMode("new");
   %this.UpdateState();
}

function OptionTool::onUpdatebtn(%this)
{
   if ( %this.localChanges )
   {
      %this.pendingCommand = "OptionTool.onUpdatebtn();";
      %this.localChanges = false;
      %this.saveChanges();
      return;
   }
   
   %this.setMode("existing");
   %this.UpdateState();
}

function OptionTool::onClosebtn(%this)
{
   if ( %this.localChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "OptionTool.onClosebtn();";
      %this.askSaveChange();
      return;
   }
   
   if ( %this.dbChanges )
   {  // See if the user wants to save the changes first
      %this.pendingCommand = "OptionTool.onClosebtn();";
      %this.askCSWrite();
      return;
   }
   
   Canvas.popDialog(%this);
}

// Open and put the header lines into avOptions.cs
function OptionTool::startCSFile(%this)
{
   %filename = "art/players/" @ $AlterVerse::AvSet @ "/avOptions.cs";
   %fo = new FileObject();
   
   if ( isObject(%fo) && %fo.openForWrite( %filename ) )
   {
      %fo.writeLine("// Automatically generated avatar options script");
      %fo.writeLine("// File: art/players/" @ $AlterVerse::AvSet @ "/avOptions.cs");
      %fo.writeLine("// Do not edit this file directly. Update the database");
      %fo.writeLine("// and use the options tool (ctrl-F7) to regenerate.\n");

      %fo.writeLine("if( isObject( AvatarOptions ) )");
      %fo.writeLine("   AvatarOptions.delete();");
      %fo.writeLine("new ArrayObject(AvatarOptions);\n");
      
      %this.dbicsFile = %fo;
   }
}

// Close the file
function OptionTool::endCSFile(%this)
{
   %this.dbicsFile.close();
   %this.dbicsFile.delete();
}

// Write the datablock to define this item
function OptionTool::writeOptionData(%this, %dataLine)
{
   %optID = GetCommaWord(%dataLine, 0);

   %this.dbicsFile.writeLine("AvatarOptions.add(" @ %optID @ ",\"" @ %dataLine @"\");");
}

function OptionTool::texFromMat(%this, %matName)
{
   %texFile = %matName.diffuseMap[0];
   %texFile = strreplace(%texFile, "art/players/" @ $AlterVerse::AvSet, "");
   return %texFile;
}

function OptionTool::handleDBResult(%this, %result)
{
   switch$( %result.command )
   {
      case "GetOptNames":
         %this.fillItemList(%result);
      case "GetOptData":
         %this.onOptDataRead(%result);
      case "NewOption":
         %this.recordAdded(%result);
      case "RunOptUpdate":
         %this.updateApplied(%result);
      case "GetOptList":
         %this.writeCSFile(%result);
      default:
         echo("Valid command with no handler??? (" @ %result.command @ ")");
   }
}

function OptionTool::SendDBCommand(%this, %command, %params, %flag)
{
   %request = new HTTPObject() {
      class = "getOptionData";
      status = "failure";
      message = "";
      command = %command;
      sender = %this;
      flag = %flag;  // Any generic flag data needed by the response processor
   };

   switch$(%command)
   {
      case "GetOptNames":
         %message = "Filling option list...Please Wait.";
      case "GetOptList":
         %message = "Loading option data...Please Wait.";
      case "GetOptData":
         %message = "Loading option data...Please Wait.";
      case "NewOption":
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

function getOptionData::process( %this )
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
