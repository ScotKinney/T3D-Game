
singleton TSShapeConstructor(A3D_PirateDts)
{
   baseShape = "./A3D_Pirate.dts";
};

function A3D_PirateDts::onLoad(%this)
{
   %this.addSequence("./Root.dsq", "Root", "0", "185", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./walk.dsq", "Walk", "0", "337", "1", "0");
   %this.addSequence("./Back.dsq", "back", "0", "51", "1", "0");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("./Death1.dsq", "death1", "0", "33", "1", "0");
   %this.addSequence("./Death2.dsq", "death2", "0", "33", "1", "0");
   %this.addSequence("./Death3.dsq", "death3", "0", "33", "1", "0");
   %this.addSequence("./Explain.dsq", "GotAnyGems", "0", "33", "1", "0");
   %this.addSequence("./LetMeThink.dsq", "TakeYourTime", "0", "33", "1", "0");
   %this.addSequence("./ListenToMe.dsq", "BetterNotBe", "0", "33", "1", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("./Attack1.dsq", "Attack1", "0", "51", "1", "0");
   %this.setBounds("-0.491928 -0.124259 0.0112931 0.434437 0.415134 1.98001");
   %this.addTrigger("Walk", "25", "1");
   %this.addTrigger("Walk", "4", "2");
}
