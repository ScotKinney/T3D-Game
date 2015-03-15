#include "postFx.hlsl"  
#include "shadergen:/autogenConditioners.h"  

uniform sampler2D backBuffer : register(S0);
uniform float2 targetSize;

uniform float jitter;
uniform float amount;

float4 main( PFXVertToPix IN ) : COLOR0
{	
	float4 backColor = tex2D(backBuffer, IN.uv0);

	float x = (IN.uv0.x + 4.0) * (IN.uv0.y + 4.0) * jitter;
	float g = (fmod((fmod(x, 13.0) + 1.0) * (fmod(x, 123.0) + 1.0), 0.01) - 0.005) * amount;
	float4 filmGrain = float4(g, g, g, g);

	return backColor + filmGrain;
}
