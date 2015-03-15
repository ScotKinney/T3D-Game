#include "postFx.hlsl"  
#include "shadergen:/autogenConditioners.h"  

//common
uniform sampler2D backBuffer : register(S0);

//brightness
uniform float brightness;

//vignette
uniform float2 targetSize;
uniform float radius;
uniform float4 color;

//blooddrops
uniform sampler2D bloodDrops : register(S1);
uniform float factor;
uniform float sine;
uniform float cosine;


float4 main( PFXVertToPix IN ) : COLOR0
{ 
	float4 output;

	//--------------------
	// brightness
	float4 backColor = tex2D(backBuffer, IN.uv0);
	output = backColor * brightness;
	
	//--------------------
	// vignette
	
	float2 coord = IN.uv0 * 2 - 1;
	output = lerp(color, output, saturate(1 - dot(coord, coord) * radius));
	
	//--------------------
	// blood drops
	
	float4 blood = float4(0, 0, 0, 0);
	
	float2x2 rotMatrix = float2x2(cosine, -sine, sine, cosine);
	float2 uv = mul(rotMatrix, IN.uv0);
	blood += tex2D(bloodDrops, uv) * factor * 2;
	
	output = lerp(output, blood, blood.a);
	
	//--------------------
	
	return output;
}
