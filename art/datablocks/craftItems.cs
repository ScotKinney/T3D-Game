


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
//BasicCraftingElements	
datablock ItemData(		Axe:baseofCraftAbleObjects){ category="BasicCraftingElements";	Twig=1;  FlintStone=1;  Rope=1; 	 hitNumber=100  ;	 constructionTime =6  ;	};
datablock ItemData(		PickAxe:baseofCraftAbleObjects){category="BasicCraftingElements";	Twig=2;  Stone=2;  Rope=1; 	 hitNumber= 100 ;	constructionTime =6  ;	};
datablock ItemData(		SkinningKnife:baseofCraftAbleObjects){category="BasicCraftingElements";	Wood=1; IronBar=1;  Rope=1; 	 skins=100;	constructionTime = 6 ;	};
datablock ItemData(		Shovel:baseofCraftAbleObjects){category="BasicCraftingElements";	Twig=2;   FlintStone =1; Rope=2;	hitNumber= 100 ; constructionTime =6  ;	};
datablock ItemData(		Torch:baseofCraftAbleObjects){	category="BasicCraftingElements";Twig=2;  Rope=1; Grass =1; 	 hitNumber= 60 ;	 constructionTime =3  ;	};
datablock ItemData(		FishingPole:baseofCraftAbleObjects){category="BasicCraftingElements";	Twig=2;  Stone=2;  Rope=1; casts= 	50;	constructionTime =6  ;	};
datablock ItemData(		Rope:baseofCraftAbleObjects){category="BasicCraftingElements";	Grass=5; 		constructionTime = 3 ;	};
datablock ItemData(		CampFire:baseofCraftAbleObjects){category="BasicCraftingElements";	Wood=5; FlintStone=1;  Grass=3; 		 constructionTime =8  ;	};
	


datablock ItemData(		CraftingBench:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	 Wood=10; RefinedIronBar=2;  RefinedCopperBar=2; 		 constructionTime = 15 ;	};
datablock ItemData(		SilverAxe:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	 	Twig=1; RefinedSilverBar =3;  StrongRope=1; 	 hitNumber=250  ;	 constructionTime = 10 ;};	
datablock ItemData(		SilverPickAxe:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	 	RefinedSilverBar=2;  StrongRope=3; Twig =1; 	 hitNumber=250  ;	 constructionTime =10  ;};	
datablock ItemData(		SilverShovel:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	 	Twig=2;  FlintStone=2;  RefinedSilverBar=3;  StrongRope=1; 	 hitNumber=250  ;	 constructionTime =10	  ;	};
datablock ItemData(		LongLastingTorch:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	Twig 	=2;  StrongRope=2;  Grass=3; 	 constructionTime =120  ;	constructionTime =5  ;	};
datablock ItemData(		ArtisanFPole:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	 	Twig=5;  Stone=5;  StrongRope=1; 	 casts=100;	 constructionTime =10  ;	    };
datablock ItemData(		StrongRope:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	 	Grass=10;   constructionTime = 6 ;	    };
datablock ItemData(		LargeCampFire:baseofCraftAbleObjects){ category="AdvancedCraftingElements";	 	Wood=10; FlintStone=2;  Stone=2;  Grass=5; 		constructionTime =6  ;	    };


datablock ItemData(		TokaraMushroomSoup:baseofCraftAbleObjects){   category="food";	TokaraMushroom=5;  Lemon=2;  Lime=1; 		constructionTime = 5  ;	    };
datablock ItemData(		LoafofBread:baseofCraftAbleObjects){   category="food";	Grass=2;  Salt=1; 		constructionTime =5  ;	    };
datablock ItemData(		BananaBread:baseofCraftAbleObjects){   category="food";	Grass=3;  Salt=1;  Banana=2;  constructionTime = 5 ;	    };
datablock ItemData(		KebabStick:baseofCraftAbleObjects){   category="food";	Twig=1;  VenisonChop=1; 		 constructionTime = 15 ;	    };
datablock ItemData(		GameMeal:baseofCraftAbleObjects){   category="food";	VenisonChop=3;  BoarSteak=1; 		 constructionTime = 15 ;	    };
datablock ItemData(		SurfnTurf:baseofCraftAbleObjects){   category="food";	SharkSteak=1;  OrangeSeaBass=1; 		 constructionTime =  15;	    };
datablock ItemData(		RainbowSushi:baseofCraftAbleObjects){   category="food";	RainbowTrout=3; 		 constructionTime =15  ;	    };
datablock ItemData(		HamSandwich:baseofCraftAbleObjects){   category="food";  	LoafofBread=1;  Ham=1; 		 constructionTime =10  ;	    };


datablock ItemData(		Twig:baseofCraftAbleObjects){   category="BasicCraftingMaterials"; obtainMethod="Harvest";			constructionTime = 2 ;	    };
datablock ItemData(		Grass:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="Harvest";		constructionTime = 2 ;	    };
datablock ItemData(		Wood:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="Axe"; hitNumber=  3;	    };
datablock ItemData(		Stone:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="Harvest";		constructionTime = 2 ;	    };
datablock ItemData(		FlintStone:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="Harvest";		constructionTime = 2 ;	 };
datablock ItemData(		IronOre:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="PickAxe";		hitNumber=3  ;	    };
datablock ItemData(		CopperOre:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="PickAxe"; hitNumber= 3 ;	    };
datablock ItemData(		SilverOre:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="PickAxe"; hitNumber= 3 ;	    };
datablock ItemData(		GoldOre:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="PickAxe"; hitNumber= 3 ;	    };
datablock ItemData(		RefinedIronBar:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	IronOre=3; constructionTime =3  ;	    };
datablock ItemData(		RefinedCopperBar:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	CopperOre=3; constructionTime = 3 ;	    };
datablock ItemData(		RefinedSilverBar:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	SilverOre=3; constructionTime =3  ;	    };
datablock ItemData(		RefinedGoldBar	:baseofCraftAbleObjects){   category="BasicCraftingMaterials";GoldOre=3; constructionTime = 3 ;	    };
datablock ItemData(		RefinedWood	:baseofCraftAbleObjects){   category="BasicCraftingMaterials";Wood=3; constructionTime =3  ;	    };
datablock ItemData(		BlacksmithsAnvil:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	IronOre=3;   Steel=3;		 constructionTime =15  ;	    };
datablock ItemData(		Steel:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	RefinedIronBar=5; constructionTime = 5 ;	    };
datablock ItemData(		Ruby :baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="PickAxe"; constructionTime =3  ;	    };
datablock ItemData(		Sapphire:baseofCraftAbleObjects){   category="BasicCraftingMaterials";	obtainMethod="PickAxe"; constructionTime = 3 ;	    };

datablock ItemData(	Avenger:baseofCraftAbleObjects){   category="Swords";	RefinedWood=1;  Iron=3;  FlintStone=2; 		    };	
datablock ItemData(	AvengerOffHand:baseofCraftAbleObjects){   category="Swords";	RefinedWood=1;  Iron=3;  FlintStone=2; 		    };	
datablock ItemData(	DeathDealer:baseofCraftAbleObjects){   category="Swords";	RefinedWood=1;  Iron=3;  SilverOre=1; 	    };		
datablock ItemData(	DeathDealerOffHand:baseofCraftAbleObjects){   category="Swords";	RefinedWood=1; Iron =3;  SilverOre=1; 	    };		
datablock ItemData(	Decimator:baseofCraftAbleObjects){   category="Swords";	RefinedWood=2;  Steel=3;  SilverOre=2; 			    };
datablock ItemData(	SoulReaver:baseofCraftAbleObjects){   category="Swords";	RefinedWood=1;  Steel=2;  FlintStone=3; 		    };	
datablock ItemData(	SoulReaverOffHand:baseofCraftAbleObjects){   category="Swords";	RefinedWood=1;  Steel=2;  FlintStone=3; 	    };		
datablock ItemData(	SkullSplitter:baseofCraftAbleObjects){   category="Swords";	RefinedWood=3;  Steel=2;  SilverOre=1; 		    };	
datablock ItemData(	BoneCrusher:baseofCraftAbleObjects){   category="Swords";	RefinedWood=3;  Steel=5;  SilverOre=3; 		    };	
datablock ItemData(	WidowMaker:baseofCraftAbleObjects){   category="Swords";	RefinedWood=5;  Steel=5;  SilverOre=5; 		    };	
datablock ItemData(	WidowMakerOffHand:baseofCraftAbleObjects){   category="Swords";	RefinedWood=5;  Steel=5;  SilverOre=5; 	    };		
datablock ItemData(	Annihilator:baseofCraftAbleObjects){   category="Swords";	IronOre=5;  Steel=5;  SilverOre=3;  GoldBar=1; 	    };		
datablock ItemData(	AnnihilatorOffHand:baseofCraftAbleObjects){   category="Swords";	IronOre=5;  Steel=5;  SilverOre=3;  GoldBar=1; 	    };		



datablock ItemData(	Crossbow:baseofCraftAbleObjects){   category="BowsCrossbows";	RefinedWood=3;  Twig=3;  IronOre=1;  Stone=1; 		    };
datablock ItemData(	ElvenBow:baseofCraftAbleObjects){   category="BowsCrossbows";	RefinedWood=10;  Twig=5;  Ruby=1;  ExpertRope=1; 	    };

datablock ItemData(	StoneSpear:baseofCraftAbleObjects){   category="Spears";	Stone=5;  Flint=2;  Rope=1;};		
datablock ItemData(	StonePike:baseofCraftAbleObjects){   category="Spears";	Stone=20; Flint=5;  Rope=1;};		
datablock ItemData(	IronSpear :baseofCraftAbleObjects){   category="Spears";	  IronOre=5;  Steel=1;  RefinedWood=1;  };		
datablock ItemData(	IronPike:baseofCraftAbleObjects){   category="Spears";	  IronOre=10;  Steel=2;  RefinedWood=2; 	    };		
datablock ItemData(	SteelSpear:baseofCraftAbleObjects){   category="Spears";	  Steel=10;  StrongRope=1;	    };	


datablock ItemData(	Paralyzer:baseofCraftAbleObjects){   category="Axes";	RefinedWood=1;  Steel=3;  IronOre=2; 	    };		
datablock ItemData(	Equalizer:baseofCraftAbleObjects){   category="Axes";	RefinedWood=1;  Steel=3;  IronOre=2; 	    };		
datablock ItemData(	Liberator:baseofCraftAbleObjects){   category="Axes";	RefinedWood=2;  GoldBar=2;  SilverBar=2; 	    };		
datablock ItemData(	Slaver:baseofCraftAbleObjects){   category="Axes";	RefinedWood=2;  GoldBar=2;  SilverBar=2; 		    };	
datablock ItemData(	Reaver:baseofCraftAbleObjects){   category="Axes";	RefinedWood=5;  Steel=10;  FlintStone=1; 		    };	
				

datablock ItemData(	RubyRing:baseofCraftAbleObjects){   category="RingsAmulet";	  Ruby=1;  GoldOre=3; };
datablock ItemData(	SapphireRing:baseofCraftAbleObjects){   category="RingsAmulet";	 Sapphire =1;  SilverOre=1;  IronOre=1; };	
datablock ItemData(	SilverRing:baseofCraftAbleObjects){   category="RingsAmulet";	SilverBar=5; 		    };
datablock ItemData(	GoldRing:baseofCraftAbleObjects){   category="RingsAmulet";	  GoldBar=5;  FlintStone=1; };
datablock ItemData(	GoldDiamondRing:baseofCraftAbleObjects){   category="RingsAmulet";	  GoldOre=2;  Diamond=1;  FlintStone=2; 	    };	
datablock ItemData(	WhiteGoldRing:baseofCraftAbleObjects){   category="RingsAmulet";	  SilverBar=2;  GoldBar=2;  FlintStone=1; 	    };	
				

datablock ItemData(	ChaosBlade:baseofCraftAbleObjects){   category="ThrownWeapons";	  IronOre=3;  Steel=1;  Rope=1; 	    };	
datablock ItemData(	HeatNail:baseofCraftAbleObjects){   category="ThrownWeapons";	  SilverBar=5;  Rope=1;  RefinedWood=1; 	    };	
datablock ItemData(	QuickSilver	:baseofCraftAbleObjects){   category="ThrownWeapons";  Steel=5;  SilverBar=1;  GoldBar=1; 	    };	
datablock ItemData(	Thumper:baseofCraftAbleObjects){   category="ThrownWeapons";	RefinedWood=1;  Stone=2; FlintStone =1; 	    };	


datablock ItemData(	BasicBuckler:baseofCraftAbleObjects){   category="Shields";	  IronOre=3;  Steel=1; 	    };	
datablock ItemData(	IronBuckler:baseofCraftAbleObjects){   category="Shields";	  IronOre=5;  Steel=1;  FlintStone=1;     };		
datablock ItemData(	SteelBuckler:baseofCraftAbleObjects){   category="Shields";	  Steel=10;  Flint=1;  Rope=1; 	    };	
datablock ItemData(	WoodenRoundShield:baseofCraftAbleObjects){   category="Shields";	  RefinedWood=2;  Rope=1;  IronOre=2;     };		
datablock ItemData(	ReinforcedWoodenShield:baseofCraftAbleObjects){   category="Shields";	  RefinedWood=2; StrongRope =1;  Steel=1;     };		
datablock ItemData(	WickedRoundShield:baseofCraftAbleObjects){   category="Shields";	 RefinedWood =5;  StrongRope=1;  SilverBar=1;     };		
datablock ItemData(	PerfectRoundShield	:baseofCraftAbleObjects){   category="Shields"; RefinedWood =5;  Flint=1; SilverBar=1; 	    };	
datablock ItemData(	CherryRoundShield:baseofCraftAbleObjects){   category="Shields";	  Ruby=1;  Steel=3;  IronOre=2; 		    };
datablock ItemData(	SerpantsRoundShield	:baseofCraftAbleObjects){   category="Shields";  SharkSteak=1;  Steel =3; IronOre =2; 		    };
datablock ItemData(	RoundShieldofEarth:baseofCraftAbleObjects){   category="Shields";	  Grass=3;  Wood=3; RefinedWood=3; 	    };	
datablock ItemData(	ExquisiteRoundShield:baseofCraftAbleObjects){   category="Shields";	  Steel=1;  SilverBar=3;  GoldBar=1; 		    };
datablock ItemData(	BolsteredRoundShield:baseofCraftAbleObjects){   category="Shields";	  Steel=3;  Sapphire=1; Flint=1; GoldBar=1; 	    };	
datablock ItemData(	WoodenSquare:baseofCraftAbleObjects){   category="Shields";    RefinedWood=3;  Rope=1; 		    };
datablock ItemData(	TriadsWooden:baseofCraftAbleObjects){   category="Shields";    RefinedWood=3;  Sapphire=1; Rope=1; 		    };
datablock ItemData(	BolsteredWooden:baseofCraftAbleObjects){   category="Shields";    IronOre=3;  Steel=1;  Flint=1; Ruby=1; 	    };	
datablock ItemData(	BeeStingSquare:baseofCraftAbleObjects){   category="Shields";   SilverBar =1;  IronOre=2;  Stone=1;  FlintStone=1; 	    };	
datablock ItemData(	Jade:baseofCraftAbleObjects){   category="Shields";    Ruby=1;  Sapphire=1; Steel=2;  GoldBar=1; 		    };
datablock ItemData(	RenownedSquare:baseofCraftAbleObjects){   category="Shields";   RefinedWood =5;  Steel=3;  Sapphire=1; 	    };
datablock ItemData(	CherrySquare:baseofCraftAbleObjects){   category="Shields";    Ruby=1; Steel =3;  IronOre=2; 		    };
datablock ItemData(	ReinforcedSquare:baseofCraftAbleObjects){   category="Shields";    RefinedWood=2; Steel =3; 		    };
datablock ItemData(BlackProtector:baseofCraftAbleObjects){   category="Shields";	  Steel=3;  StrongRope=1;  Ruby=2; 		    };
datablock ItemData(	Golden:baseofCraftAbleObjects){   category="Shields";    GoldBar=10;  Steel=3;  StrongRope=1; 		    };
datablock ItemData(	Heater:baseofCraftAbleObjects){   category="Shields";    Steel=10;  Flint=1; StrongRope=1; 		    };
datablock ItemData(	SteelHeater:baseofCraftAbleObjects){   category="Shields";    Steel=10;  SilverOre=1;  Ruby=1;  StrongRope=1; 	    };	
datablock ItemData(	ReinfocedHeaterShield:baseofCraftAbleObjects){   category="Shields";	Steel=5; SilverBar =5;  RefinedWood=1;     };		
datablock ItemData(	Targe:baseofCraftAbleObjects){   category="Shields";    RefinedWood=5;  Steel=1;  ExpertRope=1; 		    };
datablock ItemData(	BolsteredTarge:baseofCraftAbleObjects){   category="Shields";    RefinedWood=5;  Steel=3;  ExpertRope=1; 	    };	
datablock ItemData(	RoyalTarge:baseofCraftAbleObjects){   category="Shields";    RefinedWood=3; Steel =1;  SilverBar=3; 	    };