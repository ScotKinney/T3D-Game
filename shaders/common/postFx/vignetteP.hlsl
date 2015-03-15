#include "postFx.hlsl"  
#include "shadergen:/autogenConditioners.h"  

uniform sampler2D backBuffer : register(S0);
uniform float2 targetSize;
uniform float radius;
uniform float4 color;

float4 main( PFXVertToPix IN ) : COLOR0
{	
	float4 backColor = tex2D(backBuffer, IN.uv0);
	float2 coord = IN.uv0 * 2 - 1;


	return lerp(color, backColor, saturate(1 - dot(coord, coord) * radius));
}
