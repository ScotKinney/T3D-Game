
singleton TSShapeConstructor(MK4_MacArthurPalmDAE)
{
   baseShape = "./MK4_MacArthurPalm.DAE";
   unit = "0.1";
   loadLights = "0";
   lodType = "TrailingNumber";
};

function MK4_MacArthurPalmDAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
