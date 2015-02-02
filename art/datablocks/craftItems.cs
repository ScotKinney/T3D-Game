


datablock ItemData(baseofCraftAbleObjects)
{
   // Mission editor category, this datablock will show up in the
   // specified category under the "shapes" root category.
   craftFlag = "craftAbleItems";
   
   //className = "HealthPatch";
 // Basic Item properties
   shapeFile = "art/Packs/Signs/BoyersBog/SignPointerBoyersBog.dts";

   mass = 2;
   friction = 1;
   elasticity = 0.3;
   emap = true;
   
   /*
    //for craft system
  Twig=0;  
  FlintStoneRope=0;
  Rope=0;  
  
  
  hitNumber=0;
  
  constructionTime=0;//in second*/
   
};
datablock PlayerData(craftingElementHolder  )
	{
	   //weapon
      Twig = 5;
      FlintStoneRope = 5;
      Rope = 5;
      Gras = 5;
      Wood = 5;
      RefinedWood = 5;
      stone=7;
      //food
      Salt = 5;
      Lime = 5;
      Grass = 5;
      Mushroom = 5;
      Lemon = 5;
      Banana = 5;
      VenisonChop = 5;
      BoarSteak = 5;
      OrangeSeaBass = 5;
      RainbowTrout = 5;
      LoafOfBread = 5;
      Ham = 5;
     
	};

datablock ItemData(Axe:baseofCraftAbleObjects)
{
   // Dynamic properties defined by the scripts
   pickupName = "a Axe";
   category = "Weapon";
  //for craft system
  Twig=1;  
  FlintStoneRope=1;
  Rope=1;  
  hitNumber=100;
  
  constructionTime=6;//in second
  
  
};


datablock ItemData(PickAxe:baseofCraftAbleObjects)
{
   // Dynamic properties defined by the scripts
   pickupName = "a PickAxe";
    category = "Weapon";
  //for craft system
  Twig=2;
  
  Stone=2;
  Rope=1;
  
  hitNumber=100;
  
  constructionTime=6;//in second
  
  
};

datablock ItemData(TokaraMushroomSoup:baseofCraftAbleObjects)
{
   // Dynamic properties defined by the scripts
   pickupName = "Tokara Mushroom Soup";
   category="food";
  //for craft system
  Twig=2;
  
  Stone=2;
  Rope=1;
  
  hitNumber=100;
  
  constructionTime=6;//in second
  
  
};
datablock ItemData(LoafOfBread:baseofCraftAbleObjects)
{
   // Dynamic properties defined by the scripts
   pickupName = "Loaf of Bread";
   category="food";
  //for craft system
  Twig=1;
  
  Stone=1;
  Rope=1;
  
  hitNumber=100;
  
  constructionTime=6;//in second
  
  
};


