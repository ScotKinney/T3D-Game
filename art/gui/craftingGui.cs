

craftingGui.verficationResult="";

// name, width, minWidth, maxWidth, flags
$craftItemMaterialListHeader::Columns[0]		= "Names"	TAB "210 25 300"	TAB "show center"	TAB "D";
$craftItemMaterialListHeader::Columns[1]		= "Quantity"				TAB "150 150 365"		TAB "show center"	TAB "D";//TAB "show numeric"	TAB "D";
$craftItemMaterialListHeader::ColumnCount	= 2;
$craftItemMaterialListHeader::BitmapPath		= "core/art/gui/images/shll_icon_";
function craftingGui::onWake(%this)
{
   if( craftingGui.Building !$="")
    return;
   BuildBtn.active=0;
   
   %obj = craftMaterialListModern;
   %obj.clearColumns();
   %obj.clearRows();

	for(%i=0; %i<$craftItemMaterialListHeader::ColumnCount; %i++)
	{
		%col	= $craftItemMaterialListHeader::Columns[%i];
		%name	= getField(%col, 0);
		%size	= getField(%col, 1);
		%flags	= getField(%col, 2);
		//addColumn(key, name, width, minWidth, maxWidth, flags);
		%obj.addColumn(%i +1, %name, getWord(%size, 0),getWord(%size, 1), getWord(%size, 2), %flags);
	}
// to speedup adding of rows disable automatic control resizing//????????????
	//%obj.resizeOnChange = false;//true;????????
   	
	// set a couple of sort orders for a few columns.
	// first set is most significant, last is least significant:
/*	%obj.setColumnSortOrder(1, 1);  // Hidden online column, Descending
	%obj.setColumnSortOrder(7, 1);	// Players count, Descending
	%obj.setColumnSortOrder(5, 0);	// Ping, Ascending
	%obj.setColumnSortOrder(2, 0);	// Server Name, Ascending
	%obj.sortColumns();*/
	
	// re-enable automatic resizing of control upon change of content
	%obj.resizeOnChange = true;
	%obj.updateSize();
   
   return;
   // countDownContainer.visible=0;
if(  ($currentSelectedWeapon != -1) && ( CraftAbleItemsArray.count() != 0) )
{
   %itemDbID=CraftAbleItemsArray.getvalue(0);
   %sh=%itemDbID.shapeFile;
   if(%sh !$="")
      weaponShapeCratftPreview.setModel(%sh);
         
}
      else
      {
       weaponShapeCratftPreview.shapeFile=""; 
       //weaponShapeCratftPreview.mountedShapeFile =""; 
       
      }
}

function craftingGui::onSleep(%this)
{
 
}



function countDownOnProgressBar(%startingValue,%endingValue)
{
   craftingGui.countDownOnProgressBar(%startingValue,%endingValue);
}
   
   $wasCrafting="";
function onCraftingDone()
{
//craftProgressStatusInfo.text="Final Step : Cleaning Up ";

   %t="art/gui/craftingGui/unchoosen.png";
    %previews =
                  new GuiBitmapBorderCtrl() 
                   {
                             // position = "1 1";
                              extent = "58 58";
                              minExtent = "8 2";
                              horizSizing = "relative";//"right";//"windowrelative";//
                              vertSizing = "relative";//"bottom";//
                              profile = "codGuiDefaultProfile";
                              visible = "1";
                              active = "1";
                              tooltipProfile = "GuiToolTipProfile";
                              hovertime = "1000";
                              isContainer = "1";
                              canSave = "1";
                              canSaveDynamicFields = "0";
                              craftMaterialList=$wasCrafting;
                        new GuiBitmapCtrl() {
                                 bitmap = %t;
                                 wrap = "0";
                                 position = "1 1";
                                 extent = "56 52";
                                 minExtent = "8 2";
                                 horizSizing = "right";
                                 vertSizing = "bottom";
                                 profile = "GuiDefaultProfile";
                                 visible = "1";
                                 active = "1";
                                 tooltipProfile = "GuiToolTipProfile";
                                 hovertime = "1000";
                                 isContainer = "0";
                                 canSave = "1";
                                 canSaveDynamicFields = "0";
                                 //associatedDB=%i;
                                 internalName = "previewControl"@%i;
                                 //command = "heroShapePreview.setModel($playerModelList["@%i@"]);avatarConfirmBtn.active=1;";
                                 //command = "stackList.setSelectedItemId($thisControl.getId());stackDecreaseBtn.active=1;";//
                              };
                               new GuiTextCtrl() 
                               {
                                  profile = "astackLabel";//"codGuiDefaultProfile2";//
                                 text = $wasCrafting;
                                  extent="51 10";//"126 26";
                                 horizSizing = "right";//"center";
                                 vertSizing = "bottom";
                                 position = "2 55";
                              };
                     };   
                  
      craftedItemList.add(%previews);
      //echo(%posX @"  "@%posY);
	  %previews.setPosition(craftedItemList.posX,craftedItemList.posY);
	//	craftedItemList.clearUp();
		craftedItemList.x++; 
      if(craftedItemList.x<=5)
		{
		 craftedItemList.posX=craftedItemList.posX+62;
		}
		//else
		if(craftedItemList.x>5)
		{
		 craftedItemList.x=1;
		 craftedItemList.posY=craftedItemList.posY+66;
		 craftedItemList.posX=2;
		}
	   
	   
               
    CraftItemsStackArray.empty();
     backPackItemList.onWake(  );
     stackList.clearUp();
     
    // craftItemList.setselected(0);
    // backPackItemList.setselected(0);
     
   craftMaterialListModern.clearColumns();
   craftMaterialListModern.clearRows();
   
 
      stackIncreaseBtn.active=1; 
    craftItemList.active=1;
      
    if(craftingGui.verficationResult ==1)
	 {
		
		craftProgressStatusInfo.text="Added to your inventory";
		
	 }
	 else
	 {	 
	
		craftProgressStatusInfo.text="Crafting Aborted.Try Again";
	 }
   
    
     schedule(2000,0,"cleanUpCraftGui"); 
  
}
function cleanUpCraftGui()
{

craftingProgressBar.setValue(0);
craftProgressStatusInfo.text="";

}

function craftingGui::countDownOnProgressBar(%this,%startingValue,%endingValue)
{
    %diff=%startingValue-%endingValue;
      %timeDifference = 1000;
       craftingProgressBar.setValue(%startingValue/10);
           
   if($countDownGuiSch)
      cancel($countDownGuiSch);
 
  
  if(%endingValue !$="")
  {
   if( %diff<0 )
      $countDownGuiSch=schedule(%timeDifference,0,"countDownOnProgressBar",%startingValue+1,%endingValue);
   else if( %diff>0 )
      $countDownGuiSch=schedule(%timeDifference,0,"countDownOnProgressBar",%startingValue-1,%endingValue);
  else if( %diff==0 )
  {
      
       cancel($countDownGuiSch);//just for caution
     
        //craftProgressTxt.text="Item Spawining.......";
    
     
      if(craftingGui.verficationResult !$="")
		{
		    
          craftingProgressBar.setValue(1);
          schedule(1000,0,"onCraftingDone");
          
		}
		else
		{
		    craftingGui.Building="";
		   craftProgressStatusInfo.text="Net Lag: Still waiting for server Response ";
		}
 
  }
  
  }
  else
  {
   //countDownTxt.text="Done";
  // Canvas.popDialog(countDownGui);
  }
   
  
}  



function craftingGui::startCrafting(%this)// craftingGui.startCrafting();
{
     StartCraftingBtn.active=0;
   craftProgressStatusInfo.text="Step1 : submited for sever verification";
   %itemDbID=craftItemList.getText();
   $wasCrafting=%itemDbID;
   commandToServer('VerifyCraftItemBuilding',%itemDbID);
    stackIncreaseBtn.active=0;
    craftItemList.active=0;
    
 //clientCmdcenterPrint( "Build  started", 6, 4 );
  
  
   %hitNumber=0;
   %constructionTime=0;

   %count= ClientSideCraftItemInfoHolder .count();
     
    for(%i=0;%i<%count;%i++)
    {
        %info= ClientSideCraftItemInfoHolder.getvalue(%i);
        %name=getWord(%info,1);
        
        if(%itemDbID $= %name )
        {
          %hitNumber=getWord(%info,5);
          %constructionTime=getWord(%info,7);
          break;
        }
       
     }
     
      craftingGui.Building=%itemDbID;
      

     
      countDownOnProgressBar(0,%constructionTime);
       //LoadingProgress.setValue(1);
       
      //commandToClient(LocalClientConnection,'countDownStartInCraftingGui',%constructionTime,0);
      //commandToClient(LocalClientConnection,'countDownStartInCraftingGui',5,1);
       
}


 
function backPackItemList::onBackPackItemSelected( %this )//backPackItemList.onBackPackItemSelected( );
{
    
    /*%player = LocalClientConnection.player;
     if(!isObject(%player))
      return;
      
      %db=%player.getDatablock(); */
      
      %name=backPackItemList.gettext();
      %amountOnBackPack=0;
        %amountOnStack= craftingGui.getAddedOjectAmountInStack(%name);
        
        
         %count=ClientSidePlayersRawCraftMaterialsInfoHolder.count();
         for(%i=0;%i<%count;%i++)
         {
            %itemInfo = ClientSidePlayersRawCraftMaterialsInfoHolder.getvalue(%i); 
            %itemName=getword(%itemInfo,0);
            %amount=getword(%itemInfo,1);
            if(%name $= %itemName)
            {
                 %amountOnBackPack=%amount;
                 break; 
            }
          
         }
   
   if(%amountOnBackPack==0)
   {
      MessageBoxOK("error", "programatical logic error.plz inform developer");
      return;
      
   }
         
         ItemAmountOnBackPack.text=%amountOnBackPack-%amountOnStack;
         %remining=%amountOnBackPack-%amountOnStack;
         if(%remining<=0)
         {
            stackIncreaseBtn.active=0;
             BackPackNotifier.text="All "@%name @ " added on cooking list";
             //MessageBoxOK("Sortage", "All "@%name @ " on cooking list");
             //return;
         }
         else
         {
             stackIncreaseBtn.active=1;
             BackPackNotifier.text="";
         }
   
         
}



function stackList::clearUp(%this)
{
   stackList.clear();
      stackList.posX=2;//224;
      stackList.posY=0;//340;
     stackList.x=1;
 
}



function backPackItemList::onWake( %this )
{
   ItemAmountOnBackPack.text="";
   StartCraftingBtn.active=0;
   stackDecreaseBtn.active=0;
    stackList.clear();
   
   
    backPackItemList.clear();

commandToServer('SendPlayersRawCraftMaterialsInfo');
return;
     %count=ClientSidePlayersRawCraftMaterialsInfoHolder.count();
   for(%i=0;%i<%count;%i++)
   {
       %itemInfo = ClientSidePlayersRawCraftMaterialsInfoHolder.getvalue(%i); 
      %name=getword(%itemInfo,0);
      %amount=getword(%itemInfo,1);
             if(%amount>0)
               backPackItemList.add(%name, backPackItemList.getCount());
    
   }
    
    return;
     %player = LocalClientConnection.player;
     if(!isObject(%player))
      return;
      
      %db=%player.getDatablock();
       
     
      %count2=rawMaterialListArray.count();
       for(%j=0;%j<%count2;%j++)
       {
          %field=rawMaterialListArray.getvalue(%j);
          if(%db.isField(%field))  
          {    
             %t=%db.getFieldValue(%field);
             if(%t>0)
               backPackItemList.add(%field, backPackItemList.getCount());
          }
    
       }
 
      // backPackItemList.setSelected(0);
       
      backPackItemList.onBackPackItemSelected( );
}

function stackList::setSelectedItemId(%this,%itemDbID) 
{
   echo(%itemDbID);
   stackList.SelectedItemId=%itemDbID;
}


function stackList::isBuildAble(%this) 
{
    
       %count=CraftItemsMaterialsArray.count();
      // %gotAnyShortsage=false;
      
       for(%i=0;%i<%count;%i++)
       {  
         %item=CraftItemsMaterialsArray.getvalue(%i);
         %name=getWord(%item,0); 
         %REQUIREDAmount=getWord(%item,1); 
         %amountOnStack= craftingGui.getAddedOjectAmountInStack(%name);
         if(%REQUIREDAmount > %amountOnStack )
          { 
           // %gotAnyShortsage=true;
            return false;
              break;
           }
                   
       }
       
     return true;
       
}
       
   
   
function stackList::decreaseToStack(%this) 
{
   stackDecreaseBtn.active=0;
   %obj=  stackList.SelectedItemId.getParent();
    echo(%obj); 
   %obj.delete();
   stackList.updateStackStatus();
   
   if(!stackList.isBuildAble() )
     StartCraftingBtn.active=0;
    backPackItemList.onBackPackItemSelected( );
      
     
}

function stackList::updateStackStatus(%this) 
{
   CraftItemsStackArray.empty();
   %count=stackList.getcount();
     for(%i=0;%i<%count;%i++)
       {          
          %item=stackList.getObject(%i);
          %mat=%item.craftMaterialList; 
          
          
            %amount=0;
            %found=0;
            %count2=CraftItemsStackArray.count();
             for(%j=0;%j<%count2;%j++)
             {          
                %item=CraftItemsStackArray.getvalue(%j);
                %itemName=getWord(%item,0); 
                %amount=getWord(%item,1); 
              
                if(%mat $= %itemName )
                {
                    %found=1;
                    break;
                } 
             } 
           


              if(%found == 1)
                {
                    %newAmount=%amount+1;   
                    %t=%mat TAB  %newAmount;
                    CraftItemsStackArray.setValue(%t, %j); 
                }
                else
                 {
                     %newAmount=1;  
                      %t=%mat TAB  %newAmount;
                      CraftItemsStackArray.add(CraftItemsMaterialsArray.count(),%t); 
                }
                
                
                 
                  
    
       } 
       
       
       
       
}



function craftingGui::increaseToStack(%this) //craftingGui.increaseToStack();
{
    if(craftItemList.getText() $="")
   {
      MessageBoxOK("error", "plz select a product first");
      return;
      
   }
   
    %name=backPackItemList.gettext();
    
    /*
     %player = LocalClientConnection.player;
     if(!isObject(%player))
      return;
      
      %db=%player.getDatablock(); 
      */
     
        %amountOnStack= craftingGui.getAddedOjectAmountInStack(%name);
        
         %count=ClientSidePlayersRawCraftMaterialsInfoHolder.count();
         for(%i=0;%i<%count;%i++)
         {
            %itemInfo = ClientSidePlayersRawCraftMaterialsInfoHolder.getvalue(%i); 
            %itemName=getword(%itemInfo,0);
            %amount=getword(%itemInfo,1);
            if(%name $= %itemName)
            {
                 %amountOnBackPack=%amount;
                 break; 
            }
          
         }

  if(%amountOnBackPack==0)
   {
      MessageBoxOK("error", "programatical logic error.plz inform developer");
      return;
      
   }
   
         %remining=%amountOnBackPack-%amountOnStack;
   if(%remining<=0)
   {
      stackIncreaseBtn.active=0;
       BackPackNotifier.text="All "@%name @ " added on cooking list";
       //MessageBoxOK("Sortage", "All "@%name @ " on cooking list");
       return;
   }
   else
   {
    stackIncreaseBtn.active=1;
    BackPackNotifier.text="";
   }
    
    
    
 if(%name $="" )
  return;
  
    %t="art/gui/craftingGui/unchoosen.png";
    %previews =
                  new GuiBitmapBorderCtrl() 
                   {
                             // position = "1 1";
                              extent = "58 58";
                              minExtent = "8 2";
                              horizSizing = "relative";//"right";//"windowrelative";//
                              vertSizing = "relative";//"bottom";//
                              profile = "codGuiDefaultProfile";
                              visible = "1";
                              active = "1";
                              tooltipProfile = "GuiToolTipProfile";
                              hovertime = "1000";
                              isContainer = "1";
                              canSave = "1";
                              canSaveDynamicFields = "0";
                              craftMaterialList=%name;
                        new GuiBitmapCtrl() {
                                 bitmap = %t;
                                 wrap = "0";
                                 position = "1 1";
                                 extent = "56 52";
                                 minExtent = "8 2";
                                 horizSizing = "right";
                                 vertSizing = "bottom";
                                 profile = "GuiDefaultProfile";
                                 visible = "1";
                                 active = "1";
                                 tooltipProfile = "GuiToolTipProfile";
                                 hovertime = "1000";
                                 isContainer = "0";
                                 canSave = "1";
                                 canSaveDynamicFields = "0";
                                 //associatedDB=%i;
                                 internalName = "previewControl"@%i;
                                 //command = "heroShapePreview.setModel($playerModelList["@%i@"]);avatarConfirmBtn.active=1;";
                                 command = "stackList.setSelectedItemId($thisControl.getId());stackDecreaseBtn.active=1;";//
                              };
                               new GuiTextCtrl() 
                               {
                                  profile = "astackLabel";//"codGuiDefaultProfile2";//
                                 text = %name;
                                  extent="51 10";//"126 26";
                                 horizSizing = "right";//"center";
                                 vertSizing = "bottom";
                                 position = "2 55";
                              };
                     };   
                  
      stackList.add(%previews);
      //echo(%posX @"  "@%posY);
	  %previews.setPosition(stackList.posX,stackList.posY);
	//	stackList.clearUp();
		stackList.x++; 
      if(stackList.x<=5)
		{
		 stackList.posX=stackList.posX+62;
		}
		//else
		if(stackList.x>5)
		{
		 stackList.x=1;
		 stackList.posY=stackList.posY+66;
		 stackList.posX=2;
		}
	   
	   stackList.updateStackStatus();
	   
      if(stackList.isBuildAble() )
         StartCraftingBtn.active=1;
  
    
      backPackItemList.onBackPackItemSelected( );
   
}





function categorySection::onWake( %this )
{
   cleanUpCraftGui();
  // SmallPreviews.clear();
   
   %i = 0;

   for (%i = 0; %i <SmallPreviews.getCount() ; %i++)
   {
      %preview=SmallPreviews.getObject(%i);
      %preview.Command = "categorySection.onCategorySelected(\""@ %preview.name @ "\");";
      
   } 
if(SmallPreviews.firstVisible $= "")
   SmallPreviews.firstVisible = -1; 
   
if(SmallPreviews.lastVisible $= "")   
   SmallPreviews.lastVisible = -1;

   if (SmallPreviews.getCount() > 0)
   {
      SmallPreviews.firstVisible = 0;

      if (SmallPreviews.getCount() < 6)
         SmallPreviews.lastVisible = SmallPreviews.getCount() - 1;
      else
         SmallPreviews.lastVisible = 4;
   }

   //if (SmallPreviews.getCount() > 0)
    //  SmallPreviews.previewSelected(SmallPreviews.getObject(0));

   // If we have 5 or less previews then hide our next/previous buttons
   // and resize to fill their positions
   if (SmallPreviews.getCount() < 6)
   {
   
   }

  
}

function categorySection::previousPreviews(%this)//categorySection.previousPreviews();
{
   %prevHiddenIdx = SmallPreviews.firstVisible - 1;

   if (%prevHiddenIdx < 0)  
      return;

   %lastVisibleIdx = SmallPreviews.lastVisible;

   if (%lastVisibleIdx >= SmallPreviews.getCount())
      return;

   %prevHiddenObj  = SmallPreviews.getObject(%prevHiddenIdx);
   %lastVisibleObj = SmallPreviews.getObject(%lastVisibleIdx);

   if (isObject(%prevHiddenObj) && isObject(%lastVisibleObj))
   {
      SmallPreviews.firstVisible--;
      SmallPreviews.lastVisible--;

      %prevHiddenObj.setVisible(true);
      %lastVisibleObj.setVisible(false);
   }
}

function categorySection::nextPreviews(%this)//categorySection.nextPreviews();
{
   %firstVisibleIdx = SmallPreviews.firstVisible;

   if (%firstVisibleIdx < 0)
      return;

   %firstHiddenIdx = SmallPreviews.lastVisible + 1;

   if (%firstHiddenIdx >= SmallPreviews.getCount())
      return;

   %firstVisibleObj = SmallPreviews.getObject(%firstVisibleIdx);
   %firstHiddenObj  = SmallPreviews.getObject(%firstHiddenIdx);

   if (isObject(%firstVisibleObj) && isObject(%firstHiddenObj))
   {
      SmallPreviews.firstVisible++;
      SmallPreviews.lastVisible++;

      %firstVisibleObj.setVisible(false);
      %firstHiddenObj.setVisible(true);
   }
}


function categorySection::onCategorySelected(%this,%category)//categorySection.onCategorySelected("$thisControl.name");
{
   //echo(%category);
 %count=
 //CraftAbleItemsArray
 ClientSideCraftItemInfoHolder
 .count();
 
  craftItemList.clear();
  
 for(%i=0;%i<%count;%i++)
 {
     %info=
     ClientSideCraftItemInfoHolder//CraftAbleItemsArray
     .getvalue(%i);
     
     %category2=getWord(%info,3);
     %name=getWord(%info,1);
     if( (
     //%itemDbID.category
     %category2
     @"category") $=%category )
     {
      %text=%name;//%itemDbID.getname();
       craftItemList.add(%text, craftItemList.getCount());
     }
    
 }
 
 // craftItemList.setSelected(0);
 //manageCraftItemsMaterialsArray(%itemDbID);
// %selectedRace = playerRace.getText();
   //%a=playerRace.findText(%g);
	//      if(  %a != -1 )
		//      playerRace.setSelected(%a);
 
}



function categorySection::onCraftItemSelected(%this)
{
    StartCraftingBtn.active=0;
    stackList.clearUp();
   CraftItemsStackArray.empty();
 
 if(craftItemList.getText() $="")
  return;
   manageCraftItemsMaterialsArray(craftItemList.getText());
   %count=CraftItemsMaterialsArray.count();
   //if(%count <=0)
   // return;
    
   %obj = craftMaterialListModern;
   %obj.clearColumns();
   %obj.clearRows();

	for(%i=0; %i<$craftItemMaterialListHeader::ColumnCount; %i++)
	{
		%col	= $craftItemMaterialListHeader::Columns[%i];
		%name	= getField(%col, 0);
		%size	= getField(%col, 1);
		%flags	= getField(%col, 2);
		//addColumn(key, name, width, minWidth, maxWidth, flags);
		%obj.addColumn(%i +1, %name, getWord(%size, 0),getWord(%size, 1), getWord(%size, 2), %flags);
	}

       for(%i=0;%i<%count;%i++)
       {  
         
         %item=CraftItemsMaterialsArray.getvalue(%i);
         
         %name=getWord(%item,0); 
         %REQUIREDAmount=getWord(%item,1);  
        // %name=%i@"sfsfsf";
        // %REQUIREDAmount="adada"@%i;
         
         %text = %name TAB %REQUIREDAmount;
          %obj.addRow(%i, %text);
        // craftMaterialList.addRow(%i, %name SPC "                 " SPC %REQUIREDAmount);           
       }
   return;
  
   //craftMaterialList.clear();
      //craftMaterialList.addRow(0, "         Name        " SPC "       Quantity      ");
//craftMaterialList.addRow(1,"");
//craftMaterialList.addRow(2,"");
//craftMaterialList.addRow(3,"");
//craftMaterialList.addRow(4,"");


 
   craftMaterialListModern.addRow(0, "Name" SPC "score"SPC "kills" SPC "deaths");
    //craftMaterialListModern.scrollVisible(0);

 
   manageCraftItemsMaterialsArray(craftItemList.getText());
      %count=CraftItemsMaterialsArray.count();
       for(%i=0;%i<%count;%i++)
       {  
         %item=CraftItemsMaterialsArray.getvalue(%i);
         %name=getWord(%item,0); 
         %REQUIREDAmount=getWord(%item,1);  
         
        // craftMaterialList.addRow(%i, %name SPC "                 " SPC %REQUIREDAmount);
         craftMaterialListModern.addRow(%i, %name SPC "                 " SPC %REQUIREDAmount);
                   
       }

//%text = PlayerListGuiList.getRowText(%i);
 //           %itemDbID = PlayerListGuiList.getRowId(%i);
	 
}
 
////////
function pushCraftingGui()
{
    $isCraftingGuionTop=1;
   //if(HelpDlg.isAwake())
   Canvas.pushDialog(craftingGui);
    // craftingMap.push();
}

function popCraftingGui() 
{
    $isCraftingGuionTop=0;
   Canvas.popDialog(craftingGui);
    // craftingMap.pop();
    
   ControlChangeToPlayer(LocalClientConnection);
    
    
}

function toggleCraftingGui(%a)
{
   if(!%a)
    return;
   if(!$isCraftingGuionTop)//craftingGui.isAwake())
   {
    pushCraftingGui();
    //commandToServer('SlowMotionToClient',%sourceClient);
								//commandToServer('TrackObjectCameraMode',%sourceClient,%obj);
								  
      game.changecamera(LocalClientConnection,LocalClientConnection.player);
		//game.slow(%sourceClient);
    
   }
   else
      popCraftingGui();
    
} 






function craftingGui::isBuildAble(%this) 
{
    
       %count=CraftItemsMaterialsArray.count();
      // %gotAnyShortsage=false;
      
       for(%i=0;%i<%count;%i++)
       {  
         %item=CraftItemsMaterialsArray.getvalue(%i);
         %name=getWord(%item,0); 
         %REQUIREDAmount=getWord(%item,1); 
         %amountOnStack= craftingGui.getAddedOjectAmountInStack(%name);
         if(%REQUIREDAmount > %amountOnStack )
          { 
           // %gotAnyShortsage=true;
            return false;
              break;
           }
                   
       }
       
     return true;
       
}
       
       
   


function craftingGui::getAddedOjectAmountInStack(%this,%name) 
{
    %amount=0;
    %found=0;
     %count2=CraftItemsStackArray.count();
       for(%j=0;%j<%count2;%j++)
       {          
          %item=CraftItemsStackArray.getvalue(%j);
          %name2=getWord(%item,0); 
        
          if(%name $= %name2 )
          {
             %amount=getWord(%item,1); 
              return %amount;
          } 
       } 
   
   return %amount;
}


function isField(%rawMaterialListFromItemInfo,%raw2Search) 
{
   
          
          %count3=getWordCount(%rawMaterialListFromItemInfo); 
          for(%k=0;%k<%count3;%k=%k+2)
          {
             %rawMaterialName=getWord(%rawMaterialListFromItemInfo,%k); 
             if(%rawMaterialName $= %raw2Search)
               return %k ; 
             
          }
          
       return -1;   
          
}








 



 
 







