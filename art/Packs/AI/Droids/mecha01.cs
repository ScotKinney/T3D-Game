singleton TSShapeConstructor(Mecha01Dts)
{
      baseShape = "./mecha01.dts";
};

function Mecha01Dts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Droids/idle.dsq", "idle", "0", "-1");
   %this.addSequence("art/Packs/AI/Droids/shoot01.dsq", "root", "0", "15");
   %this.addSequence("art/Packs/AI/Droids/walk.dsq", "Walk", "0", "104");
   %this.addSequence("art/Packs/AI/Droids/death1.dsq", "death1", "0", "10");
   %this.addSequence("art/Packs/AI/Droids/death2.dsq", "death2", "0", "10");
   %this.addSequence("art/Packs/AI/Droids/death.dsq", "death3", "0", "10");
   %this.addSequence("art/Packs/AI/Droids/straferight.dsq", "Strafe_Left", "0", "29");
   %this.addSequence("art/Packs/AI/Droids/shoot01.dsq", "attack", "0", "-1");
   //%this.setSequenceCyclic("attack", "0");
   %this.addTrigger("Walk", "21", "1");
   %this.addTrigger("Walk", "6", "2");
   %this.addTrigger("Strafe_Left", "24", "1");
   %this.addTrigger("Strafe_Left", "10", "2");
   %this.addTrigger("attack", "1", "3");
   %this.addSequence("art/Packs/AI/Droids/backward.dsq", "Walk_Back", "0", "10");
   %this.setSequenceCyclic("Walk_Back", "0");
   %this.addSequence("art/Packs/AI/Droids/jump.dsq", "Stand_Jump", "0", "29");
   %this.setSequenceCyclic("Stand_Jump", "1");
}
