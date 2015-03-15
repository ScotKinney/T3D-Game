//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

struct VertIn
{
	float4 position   : POSITION;
	float2 texCoord   : TEXCOORD0;
	float2 corner	  : TEXCOORD1;
};
struct VertOut
{
   float4 position    : POSITION;
   float2 texCoord	  : TEXCOORD0;
};

uniform float4x4 modelview : register(C0);
uniform float4 points[4];

VertOut main( VertIn IN )
{
   VertOut Out;
   
   int index = IN.corner;
   float4 pos = points[index];
   Out.position = mul( modelview, pos );
   
   Out.texCoord = IN.texCoord;
   
   return Out;
}