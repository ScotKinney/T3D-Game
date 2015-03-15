//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------


uniform float4 moonColor;
uniform sampler2D diffuseMap : register(S0);

struct PixIn
{
	float2 texCoord : TEXCOORD0;
};

float4 main( PixIn IN ) : COLOR0
{
   float4 resColor = tex2D(diffuseMap, IN.texCoord);
   resColor.a *= moonColor.a;
   return resColor;
}