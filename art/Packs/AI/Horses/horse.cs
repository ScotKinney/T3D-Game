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
   %this.addSequence("./Anims/h_head.dsq", "head", "1", "-1", "1", "0");
   %this.setSequenceBlend("head", "1", "root", "0");
   %this.addSequence("./Anims/h_headside.dsq", "headside", "2", "24", "1", "0");
   %this.setSequencePriority("headside", "5");
   %this.addSequence("./Anims/h_Idle.dsq", "Root", "0", "559", "1", "0");
   %this.setSequencePriority("Root", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./Anims/h_Rear.dsq", "Stand_Jump", "0", "85", "1", "0");
   %this.setSequencePriority("Stand_Jump", "0");
   %this.addSequence("./Anims/h_Jump.dsq", "Move_Jump", "0", "35", "1", "0");
   %this.setSequencePriority("Move_Jump", "0");
   %this.addSequence("./Anims/h_Rear.dsq", "rejectmount", "0", "85", "1", "0");
   %this.setSequencePriority("rejectmount", "0");
   %this.addTrigger("rejectmount", "74", "1");
   %this.addSequence("./Anims/h_Rear.dsq", "rearing", "0", "85", "1", "0");
   %this.setSequencePriority("rejectmount", "0");
   %this.addTrigger("rejectmount", "74", "1");
   %this.addSequence("./Anims/h_Death.dsq", "Death1", "0", "26", "1", "0");
   %this.addSequence("./Anims/h_Rear.dsq", "Damage1", "0", "85", "1", "0");
   %this.setSequencePriority("Damage1", "0");
   %this.addTrigger("Damage1", "74", "1");
   %this.addSequence("./Anims/h_Walk.dsq", "Walk", "0", "34", "1", "0");
   %this.setSequencePriority("Walk", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addTrigger("Walk", "7", "1");
   %this.addTrigger("Walk", "16", "1");
   %this.addTrigger("Walk", "24", "2");
   %this.addTrigger("Walk", "33", "2");
   %this.addSequence("./Anims/h_Trot.dsq", "Run2", "0", "24", "1", "0");
   %this.setSequencePriority("Run2", "0");
   %this.setSequenceCyclic("Run2", "1");
   %this.addTrigger("Run2", "10", "1");
   %this.addTrigger("Run2", "11", "2");
   %this.addTrigger("Run2", "20", "1");
   %this.addTrigger("Run2", "21", "2");
   %this.addSequence("./Anims/h_Gallop.dsq", "Run3", "0", "15", "1", "0");
   %this.setSequencePriority("Run3", "0");
   %this.setSequenceCyclic("Run3", "1");
   %this.addTrigger("Run3", "6", "1");
   %this.addTrigger("Run3", "7", "2");
   %this.addTrigger("Run3", "10", "1");
   %this.addTrigger("Run3", "12", "2");
   %this.addSequence("./Anims/h_Trot.dsq", "Swim_Forward", "0", "24", "1", "0");
   %this.setSequencePriority("Swim_Forward", "0");
   %this.setSequenceCyclic("Swim_Forward", "1");
   %this.addSequence("./Anims/h_Walk.dsq", "Swim_Root", "0", "34", "1", "0");
   %this.setSequencePriority("Swim_Root", "0");
   %this.setSequenceCyclic("Swim_Root", "1");
   %this.addSequence("./Anims/h_Idle.dsq", "tp", "0", "559", "1", "0");
   %this.setSequencePriority("tp", "0");
   %this.setSequenceCyclic("tp", "1");
   %this.setSequenceGroundSpeed("Walk", "0 4 0", "0 0 0");
   %this.setSequenceGroundSpeed("run2", "0 8 0", "0 0 0");
   %this.setSequenceGroundSpeed("run3", "0 18 0", "0 0 0");
   %this.addNode("mount0", "horse_Spine1", "-1.79152e-007 -0.0739806 1.70716 0.385066 -0.184227 -0.904315 0.00910878", "1");
}
