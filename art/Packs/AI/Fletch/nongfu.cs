singleton TSShapeConstructor(NongfuDts)
{
   baseShape = "./nongfu.dts";
};

function NongfuDts::onLoad(%this)
{
   %this.addSequence("art/packs/ai/fletch/nongfu_idle-2.dsq", "root", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_walk.dsq", "run", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_walk-back.dsq", "back", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_strafe-left.dsq", "side", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-1.dsq", "death1", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-2.dsq", "death2", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-3.dsq", "death3", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-4.dsq", "death4", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-1.dsq", "death5", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-2.dsq", "death6", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-3.dsq", "death7", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-4.dsq", "death8", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-2.dsq", "death9", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-3.dsq", "death10", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_death-4.dsq", "death11", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_hummer.dsq", "hammer", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_attack-1.dsq", "attack1", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_attack-2.dsq", "attack2", "0", "4");
   %this.setSequenceCyclic("attack1", "0");
   %this.setSequenceCyclic("attack2", "0");
   %this.addSequence("art/packs/ai/fletch/nongfu_jump.dsq", "jump", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_run.dsq", "sprint", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_talk-1.dsq", "talk1", "0", "4");
   %this.setSequenceCyclic("talk1", "0");
   %this.addSequence("art/packs/ai/fletch/nongfu_talk-2.dsq", "talk2", "0", "4");
   %this.setSequenceCyclic("talk2", "0");
   %this.addSequence("art/packs/ai/fletch/nongfu_talk-3.dsq", "talk3", "0", "4");
   %this.setSequenceCyclic("talk3", "0");
   %this.addSequence("art/packs/ai/fletch/nongfu_talk-3.dsq", "talk4", "0", "4");
   %this.setSequenceCyclic("talk4", "1");
   %this.addSequence("art/packs/ai/fletch/nongfu_idle-1.dsq", "idle", "0", "4");
   %this.addSequence("art/packs/ai/fletch/nongfu_hit-1.dsq", "damage1", "0", "4");
   %this.setSequenceCyclic("damage1", "0");
   %this.addSequence("art/packs/ai/fletch/nongfu_hit-2.dsq", "damage2", "0", "4");
   %this.setSequenceCyclic("damage2", "0");
   %this.addNode("mount0", "Bip01 R Hand", "0.566266 0.0684379 1.02198 0.667436 0.54568 0.506717 0.670966", "1");
   %this.addTrigger("Run", "1", "1");
   %this.addTrigger("Run", "3", "2");
   %this.addNode("eye", "Bip01 Ponytail2", "-0.00220091 0.218117 1.73913 0.565541 0.597755 -0.568201 2.06039", "1");
}
