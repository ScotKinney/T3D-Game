datablock TriggerData(craftingShopTrigger )
{
  
};


function craftingShopTrigger::onEnterTrigger(%this,%trigger,%obj)
{
   clientCmdcenterPrint( "Press E to enter in crafting Mode", 2, 4 );
   $isCraftingGuionTop=0;
    
    if ( isObject( craftingMap ) )
         craftingMap.delete();
      new ActionMap(craftingMap);
    
     craftingMap.bind( keyboard, e, toggleCraftingGui );
     
      craftingMap.push();
   
}

function craftingShopTrigger::onLeaveTrigger(%this,%trigger,%obj)
{
  popCraftingGui();
  craftingMap.pop();
}

function craftingShopTrigger::onTickTrigger(%this,%trigger)
{
   // This method is called every tickPerioMS, as long as any
   // objects intersect the trigger.

   // You can iterate through the objects in the list by using these
   // methods:
   //    %trigger.getNumObjects();
   //    %trigger.getObject(n);
}
