function isPlayerHasTheItem(%client,%Item)//should returns true or false whether %Item already available to %client
{
	
	return %client.player.hasInventory( %Item);
	
	//return %client.player.isField(%Item);//here only checking if stock t3d player whether have the Item or not
}


function getItemAmountFromPlayerInventory(%client,%Item)//should returns 0 or greater then 0
{
	
	return %client.player.getInventory(%Item);//%client.player.getFieldValue(%Item);
}

function setItemAmountInPlayerInventory(%client,%Item,%amount)//replace item amount with new amount
{
	
	  %client.player.setInventory(%item, %amount, false);//%client.player.setFieldValue(%item,%amount);
}


function addInPlayerInventory(%client,%item,%amount)//increase or decrease items in inventory
{
//be carefull-->first check if item exist in player context.
//if player already have some of this %item  then update amount  with given %amount
//if player does not have then add this new item

 %client.player.setInventory(%item, %amount, false);
		
					  
}