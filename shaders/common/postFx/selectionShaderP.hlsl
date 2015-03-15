#include "postFx.hlsl"  

#include "shadergen:/autogenConditioners.h"

#include "../torque.hlsl"
#include "../lighting.hlsl"

uniform float saturationMultiplier;
uniform float saturationOffset;
uniform float luminanceMultiplier;
uniform float luminanceOffset;

float3 HUEtoRGB(in float H)
{
   float R = abs(H * 6 - 3) - 1;
   float G = 2 - abs(H * 6 - 2);
   float B = 2 - abs(H * 6 - 4);
   return saturate(float3(R,G,B));
}


float RGBCVtoHUE(in float3 RGB, in float C, in float V)
{
   float3 Delta = (V - RGB) / C;
   Delta.rgb -= Delta.brg;
   Delta.rgb += float3(2,4,6);
   // NOTE 1
   Delta.brg = step(V, RGB) * Delta.brg;
   float H = max(Delta.r, max(Delta.g, Delta.b));
   return frac(H / 6);
}

float3 HSLtoRGB(in float3 HSL)
{
   float3 RGB = HUEtoRGB(HSL.x);
   float C = (1 - abs(2 * HSL.z - 1)) * HSL.y;
   return (RGB - 0.5) * C + HSL.z;
}


float3 RGBtoHSL(in float3 RGB)
{
   float3 HSL = 0;
   float U, V;
   U = -min(RGB.r, min(RGB.g, RGB.b));
   V = max(RGB.r, max(RGB.g, RGB.b));
   HSL.z = (V - U) * 0.5;
   float C = V + U;
   if (C != 0)
   {
      HSL.x = RGBCVtoHUE(RGB, C, V);
      HSL.y = C / (1 - abs(2 * HSL.z - 1));
   }
   return HSL;
}

float4 uncompress(float4 col)
{
	//lamberth-azimuthal
	// g-buffer unconditioner: float4(normal.X, normal.Y, depth Hi, depth Lo)
    float2 _inpXY = mad(col.xy, 2.0f, -1.0f);
    float _xySQ = dot(_inpXY, _inpXY);
    float4 res = float4(
		sqrt(half(1.0 - (_xySQ / 4.0))) * _inpXY, -1.0 + (_xySQ / 2.0),
		col.a).xzyw;
	
	// Decode depth
    res.w = dot( col.zw, float2(1.0, 1.0/65535.0));
	
	return res;
}

float4 main( PFXVertToPix IN,   
             uniform sampler2D selectionBuffer :register(S0), 
				 uniform sampler2D backBuffer : register(S1),
				 uniform float2 targetSize : register(C0) ) : COLOR0  
{  
   float4 bb = tex2D(backBuffer, IN.uv0);

   float3 selectionColor = RGBtoHSL(bb.xyz)
      * float3(1.0f, saturationMultiplier, luminanceMultiplier)
      + float3(0.0f, saturationOffset, luminanceOffset);

   selectionColor = HSLtoRGB(saturate(selectionColor));

   float4 prepassSample = tex2D(selectionBuffer, IN.uv0);
   float selectionMask = prepassSample.r < 1.0f || prepassSample.g < 1.0f;

   return float4(lerp(bb.xyz, selectionColor, selectionMask), 1.0f);
}  