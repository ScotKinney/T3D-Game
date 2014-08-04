
singleton TSShapeConstructor(FallowDeer_AllAnimsDts)
{
   baseShape = "./fallowDeer_AllAnims.dts";
};

function FallowDeer_AllAnimsDts::onLoad(%this)
{
   %this.renameSequence("run", "run2");
   %this.addNode("eye", "Quadruped_Skeleton_Spine6", "0 0 0 0 0 1 0", "0");
   %this.setDetailLevelSize("0", "64");
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addTrigger("walk", "9", "1");
   %this.addTrigger("walk", "13", "2");
   %this.addTrigger("walk", "20", "1");
   %this.addTrigger("walk", "24", "2");
   %this.addTrigger("run2", "0", "1");
   %this.addTrigger("run2", "1", "2");
   %this.addTrigger("run2", "8", "1");
   %this.addTrigger("run2", "9", "2");
   %this.setSequenceCyclic("Attack", "0");
}
