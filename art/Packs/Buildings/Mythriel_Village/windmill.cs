singleton TSShapeConstructor(WindmillDts)
{
   baseShape = "./windmill.dts";
};

function WindmillDts::onLoad(%this)
{
   %this.setNodeTransform("Scene_Root", "-25.9399 -2.9386 2.44411 1 0 0 0", "1");
   %this.addSequence("art/Packs/Buildings/Mythriel_Village/WindmillAnimation.dsq", "ambient", "0", "-1");
   %this.setSequenceCyclic("ambient", "1");
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
