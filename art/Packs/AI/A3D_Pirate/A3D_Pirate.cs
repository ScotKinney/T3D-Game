
singleton TSShapeConstructor(A3D_PirateDts)
{
   baseShape = "./A3D_Pirate.dts";
};

function A3D_PirateDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/A3D_Pirate/root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/walk.dsq", "walk", "0", "337");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Back.dsq", "back", "0", "51");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/strafe_left.dsq", "left", "0", "-1");
   %this.setSequenceCyclic("left", "1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/strafe_right.dsq", "right", "0", "-1");
   %this.setSequenceCyclic("right", "1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Death1.dsq", "death1", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Death2.dsq", "death2", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Death3.dsq", "death3", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/BoringMe.dsq", "BoringMe", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Explain.dsq", "Explain", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/GoodLuckSalute.dsq", "GoodLuckSalute", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/LetMeThink.dsq", "LetMeThink", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/ListenToMe.dsq", "ListenToMe", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/NoNoNo.dsq", "NoNoNo", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/NotAChance.dsq", "NotAChance", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Shrugs.dsq", "Shrugs", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/WhatDoUWant.dsq", "WhatDoYouWant", "0", "33");
   %this.addSequence("art/Packs/AI/A3D_Pirate/BoringMe.dsq", "BoringMe", "0", "-1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/talking_A.dsq", "Talking", "0", "-1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Disappointed", "Disappointed", "0", "-1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Drinking.dsq", "Drinking", "0", "-1");
   %this.addSequence("art/Packs/AI/A3D_Pirate/Eating.dsq", "Eating", "0", "-1");
}
