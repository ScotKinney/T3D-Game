
uniform float2 targetSize;

#include "smaaCommon.hlsl"

void main(
	inout float4 position : POSITION0,
	inout float2 texcoord : TEXCOORD0,
	out float4 offset     : TEXCOORD1
)
{
    SMAANeighborhoodBlendingVS(texcoord, offset);
}