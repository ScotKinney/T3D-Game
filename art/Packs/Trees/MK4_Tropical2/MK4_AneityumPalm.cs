
singleton TSShapeConstructor(MK4_AneityumPalmDAE)
{
   baseShape = "./MK4_AneityumPalm.DAE";
   unit = "0.254";
   loadLights = "0";
   lodType = "TrailingNumber";
};


function MK4_AneityumPalmDAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
