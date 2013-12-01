// Fish bait script. This script assigns the luck value and fish preference
// for each type of bait. If an affinity value is not defined for a given
// fish/bait combination it is assumed to be 1.0.

// all of the fish ItemData names are listed here for easy copy/paste...
// Barracuda, Blue_Striped_Perch, Brook_Trout, Green_Gill, Mudfish,
// Orange_Sea_Bass, Pike, Rainbow_Trout, Red_Devil, Red_Head,
// Swordfish

// Boglin toes.
Boglin_Toes.fishLuck = 2.0; // Fish bite twice as fast
// Large salt water fish love boglin toes, they'd eat the whole boglin.
Boglin_Toes.affinity[Swordfish.ItemID] = 5.0;
Boglin_Toes.affinity[Orange_Sea_Bass.ItemID] = 3.0;
// Smarter fresh water fish know to flee when they see bogin toes
Boglin_Toes.affinity[Red_Devil.ItemID] = 0.0;
Boglin_Toes.affinity[Rainbow_Trout.ItemID] = 0.5;
Boglin_Toes.affinity[Pike.ItemID] = 0.5;
Boglin_Toes.affinity[Brook_Trout.ItemID] = 0.5;
// Mudfish love boglin toes. They latch on as soon as they see one (why every boglin has a mudfish)
Boglin_Toes.affinity[Mudfish.ItemID] = 2.5;

// Minnows.
Minnow.fishLuck = 2.0; // Fish bite twice as fast
// Large salt water fish don't care for minnows.
Minnow.affinity[Swordfish.ItemID] = 0.0;
Minnow.affinity[Orange_Sea_Bass.ItemID] = 0.75;
// Fresh water fish prefer them
Minnow.affinity[Red_Devil.ItemID] = 4.0;
Minnow.affinity[Rainbow_Trout.ItemID] = 2.5;
Minnow.affinity[Pike.ItemID] = 2.5;
Minnow.affinity[Brook_Trout.ItemID] = 2.5;

// Grasshoppers.
Grasshopper.fishLuck = 1.5; // Fish bite 1.5 times as fast
// Large fish double in count.
Grasshopper.affinity[Swordfish.ItemID] = 2.0;
Grasshopper.affinity[Orange_Sea_Bass.ItemID] = 2.0;
Grasshopper.affinity[Red_Devil.ItemID] = 2.0;
Grasshopper.affinity[Pike.ItemID] = 2.0;
// Cheap fish will be less frequent
Grasshopper.affinity[Mudfish.ItemID] = 0.75;
Grasshopper.affinity[Blue_Striped_Perch.ItemID] = 0.75;
Grasshopper.affinity[Red_Head.ItemID] = 0.75;
Grasshopper.affinity[Green_Gill.ItemID] = 0.75;

// Nightcrawlers
Nightcrawler.fishLuck = 1.0; // Neutral luck (twice as good as no bait)
Nightcrawler.affinity[Swordfish.ItemID] = 0.0;
Nightcrawler.affinity[Red_Devil.ItemID] = 0.0;
Nightcrawler.affinity[Mudfish.ItemID] = 1.25;
Nightcrawler.affinity[Blue_Striped_Perch.ItemID] = 1.5;
Nightcrawler.affinity[Red_Head.ItemID] = 1.25;

// "NoBait" is a special case. Since it has no ItemData, we create a script
// object so we can apply all needed properties of a bait
if (!isObject(NoBait))
{
  new ScriptObject(NoBait)
  {
     fishLuck = 0.4; // Double the time required to catch a fish.
     
     affinity[Barracuda.ItemID] = 0.75;
     affinity[Blue_Striped_Perch.ItemID] = 1.0; // striped perch don't care if you have bait or not
     affinity[Brook_Trout.ItemID] = 0.7;
     affinity[Green_Gill.ItemID] = 0.8;
     affinity[Mudfish.ItemID] = 1.0;// Mud fish don't care if you have bait or not
     affinity[Orange_Sea_Bass.ItemID] = 0.0;// Orange sea bass never bite with no bait
     affinity[Pike.ItemID] = 0.5;
     affinity[Rainbow_Trout.ItemID] = 0.2;
     affinity[Red_Devil.ItemID] = 0.0;// Red devils never bite with no bait
     affinity[Red_Head.ItemID] = 0.8;
     affinity[Swordfish.ItemID] = 0.0;// Swordfish never bite with no bait
     affinity[0] = 2.0; // Twice as likely to catch junk with nothing on your hook
  };
}
