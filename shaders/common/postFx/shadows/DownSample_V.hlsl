//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

#include "./../postFx.hlsl"
#include "./../../torque.hlsl"

struct Vert
{
   float4 pos        : POSITION;
   float2 tc         : TEXCOORD0;
   float3 wsEyeRay   : TEXCOORD1;
};

struct Pixel
{  
   float4 position : POSITION;  
   float2 tcColor0 : TEXCOORD0;  
   float2 tcColor1 : TEXCOORD1;  
};  

uniform float4    rtParams0;
uniform float2    oneOverTargetSize;  

Pixel main( Vert IN )  
{  
   Pixel OUT; 
   OUT.position = IN.pos;
   
   float2 uv = viewportCoordToRenderTarget( IN.tc, rtParams0 ); 
   OUT.tcColor1 = uv + float2( +1.0, -0.0 ) * oneOverTargetSize;  
   OUT.tcColor0 = uv + float2( -1.0, -0.0 ) * oneOverTargetSize;     
   return OUT;
}  