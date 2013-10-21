
singleton TSShapeConstructor(Orc01Dts)
{
   baseShape = "./orc01.dts";
};

function Orc01Dts::onLoad(%this)
{
   %this.addSequence("./orc_idle.dsq", "root", "0", "-1", "1", "0");
   %this.addSequence("./orc_walk.dsq", "run", "0", "-1", "1", "0");
   %this.addSequence("./orc_walk.dsq", "back", "0", "-1", "1", "0");
   %this.addSequence("./orc_strafeleft.dsq", "side", "0", "-1", "1", "0");
   %this.addSequence("./orc_death01.dsq", "death1", "0", "-1", "1", "0");
   %this.addSequence("./orc_death02.dsq", "death2", "0", "-1", "1", "0");
   %this.addTrigger("run", "0", "1");
   %this.addTrigger("run", "10", "2");
   %this.addSequence("./orc_attack01.dsq", "attack", "0", "-1", "1", "0");
   %this.setSequenceCyclic("attack", "0");
   %this.addTrigger("attack", "33", "3");
}
