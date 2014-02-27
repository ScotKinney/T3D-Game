singleton TSShapeConstructor(GargoyleDts)
{
   baseShape = "./gargoyle.dts";
};

function GargoyleDts::onLoad(%this)
{
   %this.addSequence("./gargoyle_4legs_walk.dsq", "Walk_Back", "0", "-1", "1", "0");
   %this.addSequence("./gargoyle_4legs_walk.dsq", "Strafe_Left", "0", "-1", "1", "0");
   %this.addSequence("./gargoyle_flying_take_off.dsq", "Stand_Jump", "0", "-1", "1", "0");
   %this.addSequence("./gargoyle_flying_take_off.dsq", "Move_Jump", "0", "-1", "1", "0");
   %this.addSequence("./gargoyle_landing.dsq", "land", "0", "-1", "1", "0");
   %this.addSequence("./gargoyle_death_1.dsq", "death1", "0", "-1", "1", "0");
   %this.addSequence("./gargoyle_death_2.dsq", "death2", "0", "-1", "1", "0");
   %this.addSequence("./gargoyle_air_death.dsq", "death3", "0", "-1", "1", "0");
   %this.addNode("mount0", "Bip01 Head", "-0.00786907 0.389877 2.04795 -5.58326e-005 1 -0.000116866 1.57068", "1");
   %this.addNode("mount1", "Bip01 Spine1", "-0.00784296 -0.0701372 1.4566 -0.999975 0.0057605 0.00408802 1.40282", "1");
   %this.addNode("cam", "Bip01 Spine1", "-0.00784296 -0.575505 1.28831 -0.571157 0.589576 0.571121 2.07591", "1");
   %this.addNode("eye", "Bip01 Spine1", "-0.00984748 -0.241592 1.59101 -0.565551 0.60029 0.565512 2.06008", "1");
   %this.addSequence("./idle.dsq", "root", "0", "119", "1", "0");
   %this.addSequence("./flying.dsq", "Swim_Root", "0", "36", "1", "0");
   %this.addSequence("./flying.dsq", "Swim_Forward", "0", "36", "1", "0");
   %this.addSequence("./walking.dsq", "Walk", "0", "14", "1", "0");
   %this.addSequence("./gargrun.dsq", "run2", "0", "18", "1", "0");
   %this.setSequencePriority("run2", "0");
   %this.addSequence("./attack.dsq", "spit_fire", "0", "24", "1", "0");
   %this.setSequencePriority("spit_fire", "0");
   %this.addTrigger("spit_fire", "3", "3");
   %this.setSequenceBlend("spit_fire", "1", "Walk", "0");
   %this.addTrigger("Swim_Root", "18", "1");
   %this.addTrigger("Swim_Forward", "18", "1");
   %this.setSequenceGroundSpeed("Swim_Forward", "0 7 0");
   %this.setSequenceGroundSpeed("Walk", "0 10 0");
   %this.setSequenceGroundSpeed("run2", "0 14 0");
}
