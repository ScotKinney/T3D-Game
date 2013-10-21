//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

singleton TSShapeConstructor(horseDts)
{
   baseshape = "./horse.dts";
}; 

function horseDts::onLoad(%this)
{
   %this.addSequence("./horse_root.dsq", "root", "0", "-1", "1", "0");
   %this.addSequence("./horse_walk.dsq", "run", "0", "-1", "1", "0");
   %this.addSequence("./horse_trot.dsq", "run2", "0", "-1", "1", "0");
   %this.addSequence("./horse_gallop.dsq", "run3", "0", "-1", "1", "0");
   %this.addSequence("./horse_jump.dsq", "jump", "0", "-1", "1", "0");
   %this.addSequence("./horse_rearing.dsq", "standjump", "0", "-1", "1", "0");
   %this.addSequence("./horse_jump.dsq", "JumpFull", "0", "-1", "1", "0");
   %this.addSequence("./horse_rearing.dsq", "StandJumpFull", "0", "-1", "1", "0");
   %this.addSequence("./horse_fall.dsq", "fall", "0", "-1", "1", "0");
   %this.addSequence("./horse_land.dsq", "land", "0", "-1", "1", "0");
   %this.addSequence("./horse_fall.dsq", "FallFull", "0", "-1", "1", "0");
   %this.addSequence("./horse_land.dsq", "LandFull", "0", "-1", "1", "0");
   %this.addSequence("./horse_rearing.dsq", "rearing", "0", "-1", "1", "0");
   %this.addSequence("./horse_rearing.dsq", "rejectmount", "0", "-1", "1", "0");
   %this.addSequence("./horse_head.dsq", "head", "1", "-1", "1", "0");
   %this.addSequence("./death1.dsq", "Death1", "0", "-1", "1", "0");
   %this.setSequenceBlend("head", "1", "root", "0");
   %this.addSequence("./horse_headside.dsq", "headside", "1", "-1", "1", "0");
   %this.setSequenceBlend("headside", "1", "root", "0");
   %this.addTrigger("run", "15", "2");
   %this.addTrigger("run", "22", "2");
   %this.addSequence("./horse_rearing.dsq", "Damage1", "0", "-1", "1", "0");
   %this.addSequence("./horse_walk.dsq", "runfull_forward", "0", "-1", "1", "0");
   %this.addSequence("./horse_trot.dsq", "run2full", "0", "-1", "1", "0");
   %this.addSequence("./horse_gallop.dsq", "run3full", "0", "-1", "1", "0");
   %this.addTrigger("runfull_forward", "15", "2");
   %this.addTrigger("runfull_forward", "22", "2");
   %this.addSequence("./horse_trot.dsq", "swim_forward", "0", "-1", "1", "0");
   %this.addSequence("./horse_trot.dsq", "swim_backward", "0", "-1", "1", "0");
   %this.setNodeTransform("Cam", "-3.98133e-005 -0.70775 3.67172 -0.577339 0.577339 0.577374 2.09465", "1");
   %this.addNode("eye", "Horse_SpineC", "-0.00407214 0.30305 3.36044 0.503078 0.690165 -0.520178 1.96443", "1");
   %this.addSequence("./swimfull_root.dsq", "swim_root", "0", "19", "1", "0");
   %this.addSequence("./swimfull_root.dsq", "SwimFull_Root", "0", "19", "1", "0");
}
