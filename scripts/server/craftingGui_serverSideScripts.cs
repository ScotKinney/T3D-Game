if( !isObject(CraftAbleItemsArray) )//"ItemData"  datablock marked  as( craftFlag = "craftAbleItems"; )
   new ArrayObject(CraftAbleItemsArray);
   

if( !isObject(CraftItemsMaterialsArray) )//"ItemData" marked as ( craftFlag = "craftAbleItems"; ) 's raw material needed to build them
   new ArrayObject(CraftItemsMaterialsArray);

if( !isObject(rawMaterialListArray) )//list of all kind of raw materials
{
   new ArrayObject(rawMaterialListArray);  
   rawMaterialListArray.empty();

      // //food
      rawMaterialListArray.add(rawMaterialListArray.count(),"Salt");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Lime");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Grass");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Mushroom");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Lemon");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Banana");
      rawMaterialListArray.add(rawMaterialListArray.count(),"VenisonChop");
      rawMaterialListArray.add(rawMaterialListArray.count(),"BoarSteak");
      rawMaterialListArray.add(rawMaterialListArray.count(),"OrangeSeaBass");
      rawMaterialListArray.add(rawMaterialListArray.count(),"RainbowTrout");
      rawMaterialListArray.add(rawMaterialListArray.count(),"LoafOfBread");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Ham");	  
      
      //BasicCraftingElements
      rawMaterialListArray.add(rawMaterialListArray.count(),"Axe");
      rawMaterialListArray.add(rawMaterialListArray.count(),"PickAxe");
      rawMaterialListArray.add(rawMaterialListArray.count(),"SkinningKnife");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Shovel");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Torch");
      rawMaterialListArray.add(rawMaterialListArray.count(),"FishingPole");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Rope");
      rawMaterialListArray.add(rawMaterialListArray.count(),"CampFire");
         

      //AdvancedCraftingElements
      rawMaterialListArray.add(rawMaterialListArray.count(),"CraftingBench");
      rawMaterialListArray.add(rawMaterialListArray.count(),"SilverAxe");
      rawMaterialListArray.add(rawMaterialListArray.count(),"SilverPickAxe");
      rawMaterialListArray.add(rawMaterialListArray.count(),"SilverShovel");
      rawMaterialListArray.add(rawMaterialListArray.count(),"LongLastingTorch");
      rawMaterialListArray.add(rawMaterialListArray.count(),"ArtisanFPole");
      rawMaterialListArray.add(rawMaterialListArray.count(),"StrongRope");
      rawMaterialListArray.add(rawMaterialListArray.count(),"LargeCampFire");

      //BasicCraftingMaterials
      rawMaterialListArray.add(rawMaterialListArray.count(),"Twig");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Grass");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Wood");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Stone");
      rawMaterialListArray.add(rawMaterialListArray.count(),"FlintStone");
      rawMaterialListArray.add(rawMaterialListArray.count(),"IronOre");
      rawMaterialListArray.add(rawMaterialListArray.count(),"CopperOre");
      rawMaterialListArray.add(rawMaterialListArray.count(),"SilverOre");
      rawMaterialListArray.add(rawMaterialListArray.count(),"GoldOre");
      rawMaterialListArray.add(rawMaterialListArray.count(),"RefinedIronBar");
      rawMaterialListArray.add(rawMaterialListArray.count(),"RefinedCopperBar");
      rawMaterialListArray.add(rawMaterialListArray.count(),"RefinedSilverBar");
      rawMaterialListArray.add(rawMaterialListArray.count(),"RefinedGoldBar	");
      rawMaterialListArray.add(rawMaterialListArray.count(),"RefinedWood	");
      rawMaterialListArray.add(rawMaterialListArray.count(),"BlacksmithsAnvil");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Steel");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Ruby ");
      rawMaterialListArray.add(rawMaterialListArray.count(),"Sapphire");

   /*    
    //rawMaterialListArray.add(rawMaterialListArray.count(),"hitNumber");
    //rawMaterialListArray.add(rawMaterialListArray.count(),"constructionTime");
    rawMaterialListArray.add(rawMaterialListArray.count(),"");
    rawMaterialListArray.add(rawMaterialListArray.count(),"");
    rawMaterialListArray.add(rawMaterialListArray.count(),"");
    */
   
}


if( !isObject(ServerSideCraftItemInfoHolder) )//raw material that added from bag pack to cooking stack.it will be minus once crafting started
   new ArrayObject(ServerSideCraftItemInfoHolder);

function fillServerSideCraftItemInfoHolder(  )// %itemDbID  TAB %name  TAB  %hitNumber  TAB  %constructionTime  TAB  %rawMaterialList
{
   ServerSideCraftItemInfoHolder.empty();
   %count=DataBlockGroup.getcount();
   for(%i=0;%i<%count;%i++)
   {
       %itemDbID = DataBlockGroup.getObject(%i);
       %class=%itemDbID.getClassname();
       
       if(%class $= "ItemData" )
       {
          if(%itemDbID.craftFlag $= "craftAbleItems")
          {
             %name=%itemDbID.getname();
            
              %category=%itemDbID.getFieldValue("category");        
              %hitNumber=0;
               if(%itemDbID.isField("hitNumber"))  
               {     
                %hitNumber=%itemDbID.getFieldValue("hitNumber");                   
               }  
               
               %constructionTime=0;
               if(%itemDbID.isField("constructionTime"))  
               {     
                 %constructionTime=%itemDbID.getFieldValue("constructionTime");                   
               } 
             
             
               %rawMaterialList="";
               %count2=rawMaterialListArray.count();
                for(%j=0;%j<%count2;%j++)
                {
                   %field=rawMaterialListArray.getvalue(%j);
                   if(%itemDbID.isField(%field))  
                   {     
                      %amount=%itemDbID.getFieldValue(%field);    
                      if(%rawMaterialList $="")                            
                        %rawMaterialList=%field TAB %amount;
                      else
                        %rawMaterialList=%rawMaterialList TAB %field TAB %amount;
                                
                   }
                   
                } 
       
           
           %text=%itemDbID  TAB %name TAB   "category" TAB   %category TAB "hitNumber"   TAB   %hitNumber  TAB "constructionTime"   TAB  %constructionTime  TAB  %rawMaterialList;
           ServerSideCraftItemInfoHolder.add(ServerSideCraftItemInfoHolder.count(),%text);
            // echo(%text);
          }
          
       }
        
      
   }
 } 

 
 
function serverCmdSendPlayersRawCraftMaterialsInfo(%client)// commandToServer('SendCraftItemsInfo');
{
    if(!isObject(%client.player))
        return;

   %player=%client.player;
  // %db=%player.getDatablock();    
     
     %rawMaterialList="";
      %count2=rawMaterialListArray.count();
       for(%j=0;%j<%count2;%j++)
       {
          %field=rawMaterialListArray.getvalue(%j);
          if(%player.isField(%field))  
          {    
             %amount=%player.getFieldValue(%field);
             if(%amount>0)
             {
                  if(%rawMaterialList $="")                            
                     %rawMaterialList=%field TAB %amount;
                  else
                     %rawMaterialList=%rawMaterialList TAB %field TAB %amount;
             }
    
          }
       }
 
   commandToClient( %client,'TakePlayersRawCraftMaterialsInfo',%rawMaterialList );

}   


function serverCmdSendCraftItemsInfo(%client)// commandToServer('SendCraftItemsInfo');
{
   %count=ServerSideCraftItemInfoHolder.count();
   for(%i=0;%i<%count;%i++)
   {
       %itemInfo = ServerSideCraftItemInfoHolder.getvalue(%i); 
      commandToClient( %client,'TakeCraftItemsInfo',%itemInfo );
   }
}


function serverCmdVerifyCraftItemBuilding(%client,%itemCrating)
{
	   %count=ServerSideCraftItemInfoHolder.count();
	   for(%i=0;%i<%count;%i++)
	   {
		   %itemInfo = ServerSideCraftItemInfoHolder.getvalue(%i);
			%name=getWord(%itemInfo,1);
			
			if(%itemCrating $= %name )
			{
				if(!isObject(%client.player))
				{
					commandToClient( %client,'VerifificationResultOfCraftItemBuilding',0,"player does not exist");
					return ;
				}

				   %player=%client.player;
				   //%db=%player.getDatablock(); 
				   %shouldPermit=false;
				   
			if(isObject(tempArray) )//raw material that added from bag pack to cooking stack.it will be minus once crafting started
				tempArray.empty();
			else	
				new ArrayObject(tempArray);
   
   
					%rawMaterialListFromItemInfo=getWords(%itemInfo,8); 
					%count3=getWordCount(%rawMaterialListFromItemInfo); if(%count3>0)%shouldPermit=true;
					for(%k=0;%k<%count3;%k=%k+2)
					{
						
					    %field=getWord(%rawMaterialListFromItemInfo,%k);
					   
						 if(%player.isField(%field))  
						  {     
						   %requiredAmount=getWord(%rawMaterialListFromItemInfo,%k+1);
							%amountFound=%player.getFieldValue(%field);
							
						        if(%amountFound >=%requiredAmount)
								{
									tempArray.add(tempArray.count(),%field TAB %requiredAmount );
									continue;
								}
								else
								{
									commandToClient( %client,'VerifificationResultOfCraftItemBuilding',0,"does not have enough"@%field);
									return;
								}
								
						  }  
						  else
						  {
							commandToClient( %client,'VerifificationResultOfCraftItemBuilding',0,"does not have any "@%field);
							return ;
						  }	
					}	  
					
					if(%shouldPermit)
					{
						%player=%client.player;
						//%db=%player.getDatablock(); 
				   
						%count2=tempArray.count();
						 for(%j=0;%j<%count2;%j++)
						 {     
							%itemInfo=tempArray.getvalue(%j);
							%itemName=getWord(%itemInfo,0); 
							%requiredAmount=getWord(%itemInfo,1);

								 if(%player.isField(%itemName))
								 { 
									%amountOnPlayer= %player.getFieldValue(%itemName);
									%t=%amountOnPlayer-%requiredAmount;
									if(%t<0)
									 %t=0;
									 
									%player.setFieldValue(%itemName,%t);
								 }

						 } 
					  
					  
					  %player.inv[%itemCrating] = 1;
					  %itemCrating.onInventory(%player, 1);
					  %player.getDataBlock().onInventory(%itemCrating, 1);
					  
					     /*%obj = new Item()
                        {
                           dataBlock =  %itemCrating;
                           static = true;
                           rotate = true;
                        };
                        MissionGroup.add(%obj);
                        %obj.position=vectorAdd(LocalClientConnection.player.getPosition(),getRandom(-1,-4)@" 0 0");
                        
                        */ 
					  
					  commandToClient( %client,'VerifificationResultOfCraftItemBuilding',1,"");
					  return;
					
					}

			}
		 
	   }   
}
 
 
function serverCmdsetOrbitObjectCameraMode(%client,%sourceClient,%obj)
{

    %sourceClient.camera.setOrbitObject(%obj, "1.0 0 0.7", 3, 5, 100, false, "0 0 0", true); 	
   // %sourceClient.camera.setTrackObject(%obj,VectorSub(%obj.getTransform(),("-10 -5 -5 -1")));//%obj.getTransform(),("0 5 500 1"))
    %sourceClient.camera.setVelocity("1000 1000 1000");//????????????
    %sourceClient.setControlObject(%sourceClient.camera);//
    //clientCmdSyncEditorGui();//?????????????????????????
    schedule($changeCameraToPlayer, 0, "ControlChangeToPlayer",%sourceClient);
    
    //commandToClient(%sourceClient, 'TrackObjectCameraMode',%sourceClient,%obj);//to save network data have to replace with proper client side function(see   function clientCmdTrackObjectCameraMode(%sourceClient,%obj))----vvvvvvvvvv	
}

function ControlChangeToPlayer(%client)
{
   %client.setControlObject(%client.player);
}

function GameCore::changecamera(%game, %client,%obj)
{
    %Client.camera.setOrbitObject(%obj, //GameBase  orbitObject,  
    ".91  8 1.9",// VectorF  rotation,  
     3, //float  minDistance,  
     7, //float  maxDistance,   
     1000, // float  initDistance,  
     false, // bool  ownClientObject = false,  
     "0 0 0", // Point3F  offset = Point3F(0.0f, 0.0f, 0.0f),  
     true// bool  locked = false   
     ); //"1.0 0 0.7"--->top-left
     
    //%client.camera.setTrackObject(%obj,VectorSub(%obj.getTransform(),("-10 -5 -5 -1")));//%obj.getTransform(),("0 5 500 1"))
    
    %client.camera.setVelocity("1000 1000 1000");//?????????
    %client.setControlObject(%client.camera);
    //clientCmdSyncEditorGui();//?????????????????????????
    //schedule(400, 0, "ControlChangeToPlayer",%client);
 
 //commandToClient(%client, 'changecamera',%client,%obj);//????????????
 
 
}