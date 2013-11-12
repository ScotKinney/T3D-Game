
singleton TSShapeConstructor(SprucePine001DAE)
{
   baseShape = "./SprucePine001.DAE";
};

function SprucePine001DAE::onLoad(%this)
{
   %this.addImposter("128", "4", "0", "0", "256", "1", "0");
}
