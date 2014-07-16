datablock TriggerData(DamageTrigger : DefaultTrigger)
{
   tickPeriodMS = 100;  
};

function DamageTrigger::onEnterTrigger( %this, %trigger, %obj )
{  
   
   // check that the object entering the trigger is a player, or AI if enabled
   if( (%obj.getClassName()$="Player" || %obj.getClassName()$="aiPlayer") && (%obj.team !$= %trigger.team) )
   {
      
      // add a var to the trigger "DamageType" and give it one of the following values. 
      switch$(%trigger.DamageType)
      {
         case "Water": //Water
            %obj.setDamageDt($DamageWater, "Water");
         case "OceanWater": //Ocean Water
         case "RiverWater": //River Water
         case "BogWater": //Bog Water
            %obj.setDamageDt($DamageWater, "BogWater");
         case "Lava": //Lava
            %obj.setDamageDt($DamageLava, "Lava");
         case "HotLava": //Hot Lava
            %obj.setDamageDt($DamageHotLava, "Lava");
         case "CrustyLava": //Crusty Lava
            %obj.setDamageDt($DamageCrustyLava, "Lava");
         case "QuickSand": //Quick Sand
         default: //default
            %obj.setDamageDt($DamageWater, "Water");
      }
      if (%obj.getDamageLevel() != 0 && %obj.getState() !$= "Dead")
      {
      // Update the Health GUI while repairing
      
         if (%obj.client)
            messageClient(%obj.client, 'MsgLavaRock','\c2You feel a little warmer than usual...');
            serverPlay3D(HealthUseSound, %obj.getTransform());
      } 
   }
   else
   {
      return true; // Don't turn on for teammates.
   }
}

function DamageTrigger::onLeaveTrigger( %this, %trigger, %obj )
{  
   if( %obj.getClassName()$="Player" || %obj.getClassName()$="aiPlayer" )
      %obj.clearDamageDt();
}