
uniform sampler2D edgesMap  : register(S0);
uniform sampler2D areaMap   : register(S1);
uniform sampler2D searchMap : register(S2);

uniform float2 targetSize;

#include "smaaCommon.hlsl"

float4 main(
    float2 texcoord  : TEXCOORD0,
    float2 pixcoord  : TEXCOORD1,
    float4 offset[3] : TEXCOORD2
) : COLOR0
{
    //return tex2D(edgesMap, texcoord);
    return SMAABlendingWeightCalculationPS(texcoord, pixcoord, offset, edgesMap, areaMap, searchMap, float4(0.0, 0.0, 0.0, 0.0));
}