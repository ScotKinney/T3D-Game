#include "postFx.hlsl"
#include "../torque.hlsl"
#include "shadergen:/autogenConditioners.h"  

uniform sampler2D backBuffer : register(S0);

uniform sampler2D ramp0 : register(S1);
uniform sampler2D ramp1 : register(S2);
uniform sampler2D ramp2 : register(S3);
uniform sampler2D ramp3 : register(S4);
uniform sampler2D ramp4 : register(S5);

uniform float rampFactor0;
uniform float rampFactor1;
uniform float rampFactor2;
uniform float rampWeight;

uniform float2 targetSize;

float3 applyColorGrading(float3 color, in sampler2D ramp)
{
	// 3d texture unwrapped to 256x16
	float2 offset = float2(0.5f / 256.0f, 0.5f / 16.0f);
	float scale = 15.0f / 16.0f; 

	// even and fractional parts of blue component
	float blueInt = floor(color.b * 15.0) / 16.0f;
	float blueFract = color.b * 15.0f - blueInt * 16.0f;

	// UV
	float2 uv = float2(
		blueInt + color.r * scale / 16.0f,
		color.g * scale
	);

	// uv offsets
	float2 duv0 = float2(0, 0);
	float2 duv1 = float2(1.0 / 16.0, 0.0);

	// LUT samples
	float3 lut0 = tex2D(ramp, offset + uv + duv0).rgb;
	float3 lut1 = tex2D(ramp, offset + uv + duv1).rgb;

	return lerp(lut0, lut1, blueFract);
}

float4 main( PFXVertToPix IN ) : COLOR0
{
	float4 color = hdrDecode(tex2D(backBuffer, IN.uv0.xy));

	float3 rgb0 = applyColorGrading(color.rgb, ramp0);
	float3 rgb1 = applyColorGrading(color.rgb, ramp1);
	float3 rgb2 = applyColorGrading(color.rgb, ramp2);
	float3 rgb3 = applyColorGrading(color.rgb, ramp3);
	float3 rgb4 = applyColorGrading(color.rgb, ramp4);
	
	float3 color0 = lerp(rgb0, rgb1, rampFactor0);
	float3 color1 = lerp(rgb2, rgb3, rampFactor1);
	color.rgb = lerp(color0, color1, rampWeight);
	
	color.rgb = lerp(color.rgb, rgb4, rampFactor2);

	return hdrEncode(color);
}
