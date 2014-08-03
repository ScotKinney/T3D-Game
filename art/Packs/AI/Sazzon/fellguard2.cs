
singleton TSShapeConstructor(fellguard2Dts)
{
   baseShape = "./fellguard2.dts";
};

function fellguard2Dts::onLoad(%this)
{
   %this.addSequence("art/packs/AI/Sazzon/fellguard_idle01.dsq", "root", "0", "-1");
   %this.addSequence("art/packs/AI/Sazzon/fellguard_walk.dsq", "walk", "0", "-1");
   %this.addSequence("art/packs/AI/Sazzon/fellguard_walk.dsq", "back", "0", "-1");
   %this.addSequence("art/packs/AI/Sazzon/fellguard_strafeleft.dsq", "side", "0", "-1");
   %this.addSequence("art/packs/AI/Sazzon/fellguard_fall.dsq", "death1", "0", "-1");
   %this.addSequence("art/packs/AI/Sazzon/fellguard_death02.dsq", "death2", "0", "-1");
   %this.addSequence("art/packs/AI/Sazzon/fellguard_attack02.dsq", "attack1", "0", "-1");
   %this.addSequence("art/packs/AI/Sazzon/fellguard_gethit.dsq", "damage1", "0", "-1");
   %this.addTrigger("walk", "9", "1");
   %this.addTrigger("walk", "19", "2");
   %this.addTrigger("attack1", "13", "3");
   %this.setNodeTransform("Mount0", "0.926164 0.403483 2.76223 -0.109355 -0.0403267 0.993184 2.78322", "1");
}

