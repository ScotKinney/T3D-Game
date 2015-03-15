
uniform sampler2D blendMap  : register(S0);
uniform sampler2D colorMap  : register(S1);

uniform float2 targetSize;

#include "smaaCommon.hlsl"

float4 main(
   float2 texcoord : TEXCOORD0,
   float4 offset   : TEXCOORD1
) : COLOR0 
{
   //return tex2D(blendMap, texcoord);
   return SMAANeighborhoodBlendingPS(texcoord, offset, colorMap, blendMap);
}