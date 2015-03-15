// SMAA edge detection

#include "shadergen:/autogenConditioners.h"

uniform sampler2D colorMap  : register(S0);

uniform float2 targetSize;

#include "smaaCommon.hlsl"

float4 main(
	float2 texcoord  : TEXCOORD0,
	float4 offset[3] : TEXCOORD1
) : COLOR0
{
	//return tex2D(colorMap, texcoord);
    return float4(SMAALumaEdgeDetectionPS(texcoord, offset, colorMap), 0.0, 0.0);
}