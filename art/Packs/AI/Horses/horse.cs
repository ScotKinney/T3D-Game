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
   %this.addSequence("./horse_head.dsq", "head", "1", "-1", "1", "0");
   %this.setSequenceBlend("head", "1", "root", "0");
   %this.addSequence("./horse_headside.dsq", "headside", "1", "24", "1", "0");
   %this.setSequencePriority("headside", "5");
   %this.setNodeTransform("mount0", "1.60779e-005 -0.0816334 1.93761 0.420394 -0.70303 -0.5736 0.0842344", "1");
   %this.addTrigger("run", "11", "1");
   %this.addTrigger("run", "21", "2");
   %this.addTrigger("run2", "1", "1");
   %this.addSequence("./Anims/h_Walk.dsq", "run", "0", "34", "1", "0");
   %this.setSequencePriority("run", "0");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("./Anims/h_Trot.dsq", "run2", "0", "24", "1", "0");
   %this.setSequencePriority("run2", "0");
   %this.setSequenceCyclic("run2", "1");
   %this.addSequence("./Anims/h_Gallop.dsq", "run3", "0", "15", "1", "0");
   %this.setSequencePriority("run3", "0");
   %this.setSequenceCyclic("run3", "1");
   %this.addSequence("./Anims/h_Jump.dsq", "Jump", "0", "35", "1", "0");
   %this.setSequencePriority("Jump", "0");
   %this.addSequence("./Anims/h_Idle.dsq", "Root", "0", "559", "1", "0");
   %this.setSequencePriority("Root", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./Anims/h_Rear.dsq", "standjump", "0", "85", "1", "0");
   %this.setSequencePriority("standjump", "0");
   %this.addSequence("./Anims/h_Jump.dsq", "JumpFull", "0", "35", "1", "0");
   %this.setSequencePriority("JumpFull", "0");
   %this.addSequence("./Anims/h_Rear.dsq", "StandJumpFull", "0", "85", "1", "0");
   %this.setSequencePriority("StandJumpFull", "0");
   %this.addSequence("./Anims/h_Rear.dsq", "rearing", "0", "85", "1", "0");
   %this.setSequencePriority("rearing", "0");
   %this.addSequence("./Anims/h_Rear.dsq", "rejectmount", "0", "85", "1", "0");
   %this.setSequencePriority("rejectmount", "0");
   %this.addSequence("./Anims/h_Death.dsq", "Death1", "0", "26", "1", "0");
   %this.addSequence("./Anims/h_Rear.dsq", "Damage1", "0", "85", "1", "0");
   %this.setSequencePriority("Damage1", "0");
   %this.addSequence("./Anims/h_Walk.dsq", "RunFull_Forward", "0", "34", "1", "0");
   %this.setSequencePriority("RunFull_Forward", "0");
   %this.setSequenceCyclic("RunFull_Forward", "1");
   %this.addSequence("./Anims/h_Trot.dsq", "run2full", "0", "24", "1", "0");
   %this.setSequencePriority("run2full", "0");
   %this.setSequenceCyclic("run2full", "1");
   %this.addSequence("./Anims/h_Gallop.dsq", "run3full", "0", "15", "1", "0");
   %this.setSequencePriority("run3full", "0");
   %this.setSequenceCyclic("run3full", "1");
   %this.addSequence("./Anims/h_Trot.dsq", "swim_forward", "0", "24", "1", "0");
   %this.setSequencePriority("swim_forward", "0");
   %this.setSequenceCyclic("swim_forward", "1");
   %this.addSequence("./Anims/h_Trot.dsq", "swim_backward", "0", "24", "1", "0");
   %this.setSequencePriority("swim_backward", "0");
   %this.setSequenceCyclic("swim_backward", "1");
   %this.addSequence("./Anims/h_Walk.dsq", "swim_root", "0", "34", "1", "0");
   %this.setSequencePriority("swim_root", "0");
   %this.setSequenceCyclic("swim_root", "1");
   %this.addSequence("./Anims/h_Walk.dsq", "SwimFull_Root", "0", "34", "1", "0");
   %this.setSequencePriority("SwimFull_Root", "0");
   %this.setSequenceCyclic("SwimFull_Root", "1");
   %this.addSequence("./Anims/h_Idle.dsq", "tp", "0", "559", "1", "0");
   %this.setSequencePriority("tp", "0");
   %this.setSequenceCyclic("tp", "1");
}
