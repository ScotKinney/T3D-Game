if( !isObject(CraftItemsStackArray) )//raw material that added from bag pack to cooking stack.it will be minus once crafting started
   new ArrayObject(CraftItemsStackArray);
   

if( !isObject(ClientSideCraftItemInfoHolder) )//raw material that added from bag pack to cooking stack.it will be minus once crafting started
   new ArrayObject(ClientSideCraftItemInfoHolder);

if( !isObject(ClientSidePlayersRawCraftMaterialsInfoHolder) )//raw material that added from bag pack to cooking stack.it will be minus once crafting started
   new ArrayObject(ClientSidePlayersRawCraftMaterialsInfoHolder);


function clientCmdTakePlayersRawCraftMaterialsInfo(%rawMaterialList)
{
   ClientSidePlayersRawCraftMaterialsInfoHolder.empty();
       %count3=getWordCount(%rawMaterialList); 
          for(%k=0;%k<%count3;%k=%k+2)
          {
              %name=getWord(%rawMaterialList,%k);
              %amount=getWord(%rawMaterialList,%k+1);//%itemDbID.getFieldValue(%field); 
               %info=%name TAB %amount;
             ClientSidePlayersRawCraftMaterialsInfoHolder.add(ClientSidePlayersRawCraftMaterialsInfoHolder.count(),%info);
          }
          
           %count=ClientSidePlayersRawCraftMaterialsInfoHolder.count();
   for(%i=0;%i<%count;%i++)
   {
       %itemInfo = ClientSidePlayersRawCraftMaterialsInfoHolder.getvalue(%i); 
      %name=getword(%itemInfo,0);
      %amount=getword(%itemInfo,1);
             if(%amount>0)
               backPackItemList.add(%name, backPackItemList.getCount());
    
   }
   
}


function clientCmdTakeCraftItemsInfo(%itemInfo)
{
  ClientSideCraftItemInfoHolder.add(ClientSideCraftItemInfoHolder.count(),%itemInfo);
}   


function clientCmdVerifificationResultOfCraftItemBuilding(%result,%msg)
{
	 if(%result ==1)
	 {
		craftingGui.verficationResult=%result;
		craftProgressStatusInfo.text="Sever verification Done. ";
		
	 }
	 else
	 {	 
		craftingGui.verficationResult=%result;
		craftProgressStatusInfo.text="Verification Failed: "@%msg;
	 }
	 
	  
	 if(craftingGui.Building $="")
		{
		    onCraftingDone();
		}
}
 
 
 //camera
function clientCmdchangecamera(%client,%obj)//???????????????
{
    %client.camera.setTrackObject(%obj,VectorSub(%obj.getTransform(),("-10 -5 -5 -1")));//%obj.getTransform(),("0 5 500 1"))
    //%client.camera.setVelocity("1000 1000 1000");////////////
    %client.setControlObject(%client.camera);/////////////
    //clientCmdSyncEditorGui();//?????????????????????????
    //schedule(400, 0, "ControlChangeToPlayer",%client);
}

function clientCmdTrackObjectCameraMode(%sourceClient,%obj)//???????????????
{
    %sourceClient.camera.setTrackObject(%obj,VectorSub(%obj.getTransform(),("-10 -5 -5 -1")));
    //%client.camera.setVelocity("1000 1000 1000");////////////
    //%client.setControlObject(%client.camera);/////////////
    //clientCmdSyncEditorGui();//?????????????????????????
    //schedule(400, 0, "ControlChangeToPlayer",%client);
}

function manageCraftItemsMaterialsArray(%itemDbID)  
{
  
   CraftItemsStackArray.empty(); 
    rawMaterialAmountInStack.Text=0;    
    CraftItemsMaterialsArray.empty(); 
    
    
    
   %count= ClientSideCraftItemInfoHolder .count();

      for(%i=0;%i<%count;%i++)
       {
           %info= ClientSideCraftItemInfoHolder.getvalue(%i);
           %name=getWord(%info,1);
           if( %itemDbID $=%name )
           {
            %itemDbIDInfo=%info;
            break;
           }
          
       }
    
   
      %count2=rawMaterialListArray.count();
       for(%j=0;%j<%count2;%j++)
       {
          %field=rawMaterialListArray.getvalue(%j);
           %rawMaterialListFromItemInfo=getWords(%itemDbIDInfo,8);  
           %n1=isField(%rawMaterialListFromItemInfo,%field) ;
          
          if( %n1 >=0
          //%itemDbID.isField(%field)
          )  
          {     
             %amount=getWord(%rawMaterialListFromItemInfo,%n1+1);//%itemDbID.getFieldValue(%field);          
             CraftItemsMaterialsArray.add(CraftItemsMaterialsArray.count(),%field TAB %amount);
             //echo(  CraftAbleItemsArray.getvalue($currentSelectedWeapon).getField("Twig"));                    
          }
          
       } 
      for(%j=0;%j<CraftItemsMaterialsArray.count();%j++)
       {
          echo(CraftItemsMaterialsArray.getvalue(%j)); 
       }
       
       
       return;
       $currentSelectedRawMaterial  =-1;
       if(CraftItemsMaterialsArray.count() >0)
       {
         craftingGui.nextRawMaterial();
       }
       else
       {
          $currentSelectedRawMaterial=-1;
          rawMaterialLabel.text="Not Buidable";
          rawMaterialAmount.text="Not Buidable";
        
         %t="art/gui/craftingGui/unchoosen.png";
			 if(isFile(%t)) 
			 {
            rawMaterialImagePreview.bitmap=%t;
			 }
			 else
			  rawMaterialImagePreview.bitmap="";
           	    
           	    
       }
   
   
}