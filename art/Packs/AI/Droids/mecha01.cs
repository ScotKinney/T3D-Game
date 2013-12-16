singleton TSShapeConstructor(Mecha01Dts)
{
      baseShape = "./mecha01.dts";
};

function Mecha01Dts::onLoad(%this)
{
   %this.addSequence("art/Worlds/Magellan/AI/Droids/idle.dsq", "idle", "0", "-1");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/shoot01.dsq", "root", "0", "15");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/walk.dsq", "run", "0", "104");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/death1.dsq", "death1", "0", "10");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/death2.dsq", "death2", "0", "10");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/death.dsq", "death3", "0", "10");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/straferight.dsq", "side", "0", "29");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/shoot01.dsq", "attack", "0", "-1");
   //%this.setSequenceCyclic("attack", "0");
   %this.addTrigger("run", "15", "1");
   %this.addTrigger("run", "29", "2");
   %this.addTrigger("side", "24", "1");
   %this.addTrigger("side", "10", "2");
   %this.addTrigger("attack", "1", "3");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/backward.dsq", "back", "0", "10");
   %this.setSequenceCyclic("back", "0");
   %this.addSequence("art/Worlds/Magellan/AI/Droids/jump.dsq", "jump", "0", "29");
   %this.setSequenceCyclic("jump", "1");
}
