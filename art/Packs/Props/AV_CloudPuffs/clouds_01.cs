//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton TSShapeConstructor(Clouds_01DAE)
{
   baseShape = "./clouds_01.DAE";
   loadLights = "0";
};

function Clouds_01DAE::onLoad(%this)
{
   %this.setMeshType("poofgrouptwo 400", "billboard");
   %this.setObjectNode("poofgrouptwo", "poofgrouptwo400");
   %this.setMeshType("poofgroupthree 400", "billboard");
   %this.setObjectNode("poofgroupthree", "poofgroupthree400");
   %this.setMeshType("poofgroupten 400", "billboard");
   %this.setObjectNode("poofgroupten", "poofgroupten400");
   %this.setMeshType("poofgroupsix 400", "billboard");
   %this.setObjectNode("poofgroupsix", "poofgroupsix400");
   %this.setMeshType("poofgroupseven 400", "billboard");
   %this.setObjectNode("poofgroupseven", "poofgroupseven400");
   %this.setMeshType("poofgroupone 400", "billboard");
   %this.setObjectNode("poofgroupone", "poofgroupone400");
   %this.setMeshType("poofgroupnine 400", "billboard");
   %this.setObjectNode("poofgroupnine", "poofgroupnine400");
   %this.setMeshType("poofgroupfour 400", "billboard");
   %this.setObjectNode("poofgroupfour", "poofgroupfour400");
   %this.setMeshType("poofgroupfive 400", "billboard");
   %this.setObjectNode("poofgroupfive", "poofgroupfive400");
   %this.setMeshType("poofgroupeight 400", "billboard");
   %this.setObjectNode("poofgroupeight", "poofgroupeight400");
}
