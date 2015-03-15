#include "postFx.hlsl"  
#include "shadergen:/autogenConditioners.h"  

uniform sampler2D backBuffer : register(S0);
uniform sampler2D bloodDrops : register(S1);
uniform float2 targetSize;

uniform float factor;
uniform float sine;
uniform float cosine;

float4 main( PFXVertToPix IN ) : COLOR0
{	
	float4 backColor = tex2D(backBuffer, IN.uv0);

	float4 blood = float4(0, 0, 0, 0);
	
	float2x2 rotMatrix = float2x2(cosine, -sine, sine, cosine);
	float2 uv = mul(rotMatrix, IN.uv0);
	blood += tex2D(bloodDrops, uv) * factor * 2;

	return lerp(backColor, blood, blood.a);
}
