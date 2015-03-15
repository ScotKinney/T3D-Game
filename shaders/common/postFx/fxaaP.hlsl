#include "postFx.hlsl"  
#include "shadergen:/autogenConditioners.h"  

uniform sampler2D backBuffer : register(S0);
uniform float2 targetSize;

float4 fxaa(sampler2D s, float2 texCoord, float2 offset)
{
	float maxSpan = 8.0;
	float reduceMul = 1.0 / 8.0;
	float reduceMin = (1.0 / 128.0);

	float3 rgbNW = tex2D(s, texCoord.xy + (float2(-1.0, -1.0) * offset)).xyz;
	float3 rgbNE = tex2D(s, texCoord.xy + (float2(+1.0, -1.0) * offset)).xyz;
	float3 rgbSW = tex2D(s, texCoord.xy + (float2(-1.0, +1.0) * offset)).xyz;
	float3 rgbSE = tex2D(s, texCoord.xy + (float2(+1.0, +1.0) * offset)).xyz;
	float3 rgbM  = tex2D(s, texCoord.xy).xyz;

	float3 luma  = float3(0.299, 0.587, 0.114);
	float lumaNW = dot(rgbNW, luma);
	float lumaNE = dot(rgbNE, luma);
	float lumaSW = dot(rgbSW, luma);
	float lumaSE = dot(rgbSE, luma);
	float lumaM  = dot( rgbM, luma);

	float lumaMin = min(lumaM, min(min(lumaNW, lumaNE), min(lumaSW, lumaSE)));
	float lumaMax = max(lumaM, max(max(lumaNW, lumaNE), max(lumaSW, lumaSE)));

	float2 dir;
	dir.x = -((lumaNW + lumaNE) - (lumaSW + lumaSE));
	dir.y =  ((lumaNW + lumaSW) - (lumaNE + lumaSE));

	float dirReduce = max((lumaNW + lumaNE + lumaSW + lumaSE) * (0.25 * reduceMul), reduceMin);

	float rcpDirMin = rcp(min(abs(dir.x), abs(dir.y)) + dirReduce);

	dir = min(float2(maxSpan,  maxSpan), max(float2(-maxSpan, -maxSpan), dir * rcpDirMin)) * offset;

	float3 rgbA = (1.0 / 2.0) * (tex2D(s, texCoord.xy + dir * (1.0 / 3.0 - 0.5)).xyz + tex2D(s, texCoord.xy + dir * (2.0 / 3.0 - 0.5)).xyz);
	float3 rgbB = rgbA * (1.0 / 2.0) + (1.0 / 4.0) * (tex2D(s, texCoord.xy + dir * (0.0 / 3.0 - 0.5)).xyz + tex2D(s, texCoord.xy + dir * (3.0 / 3.0 - 0.5)).xyz);
	float lumaB = dot(rgbB, luma);

	float4 color;

	int lumCond = int((lumaB < lumaMin) || (lumaB > lumaMax));
	color.xyz = (rgbA * lumCond) + (rgbB * (1 - lumCond));
	color.a = 1.0;
	return color;
}

float4 main( PFXVertToPix IN ) : COLOR0
{	
	float2 offset = rcp(targetSize);
	float4 backColor = fxaa(backBuffer, IN.uv0, offset);
	return backColor;
}
