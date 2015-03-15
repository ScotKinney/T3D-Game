// SMAA blend weight calculation

// SMAA edge detection

uniform float2 targetSize;

#include "smaaCommon.hlsl"

void main(
	inout float4 position : POSITION0,
	inout float2 texcoord : TEXCOORD0, 
	out float2 pixcoord   : TEXCOORD1,
	out float4 offset[3]  : TEXCOORD2
)
{
    SMAABlendingWeightCalculationVS(texcoord, pixcoord, offset);
}
