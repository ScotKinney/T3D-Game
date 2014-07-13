
singleton TSShapeConstructor(Mesh_LOD_FinalDts)
{
   baseShape = "./Mesh_LOD_Final.dts";
};

function Mesh_LOD_FinalDts::onLoad(%this)
{
   %this.addSequence("art/packs/ai/Razorbacks/mesh_Final_Idle_03.dsq", "root", "0", "60");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/packs/ai/Razorbacks/mesh_Final_Run.dsq", "walk", "0", "28");
   %this.setSequenceCyclic("walk", "1");
   %this.addSequence("art/packs/ai/Razorbacks/mesh_Final_Walk.dsq", "back", "0", "10");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/packs/ai/Razorbacks/mesh_Final_Attack.dsq", "attack1", "0", "0");
   %this.addSequence("art/packs/ai/Razorbacks/mesh_Final_Death.dsq", "death1", "0", "0");
   %this.addSequence("art/packs/ai/Razorbacks/mesh_Final_Walk.dsq", "side", "0", "0");
   %this.setSequenceCyclic("side", "1");
   %this.addTrigger("run", "6", "1");
   %this.addNode("mount0", "Tounge_Start", "-1.35851e-005 1.02187 0.480397 1 5.84737e-005 3.18235e-005 0.486429", "1");
   %this.setMeshSize("Eyes 32", "1500");
   %this.setMeshSize("Eyes 1500", "32");
   %this.setDetailLevelSize("32", "500");
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
}
