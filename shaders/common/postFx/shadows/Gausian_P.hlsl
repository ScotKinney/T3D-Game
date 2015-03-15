//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

#include "shadergen:/autogenConditioners.h"
#include "./../postFx.hlsl"

uniform sampler2D diffuseMap : register(S0);
uniform sampler2D normalMap : register(S1);

#define MAX_DEPTH_DIV 100 // 1 over 0.01


struct VertToPix
{
   float4 hpos       : POSITION;
   float2 uv		 : TEXCOORD0;
   float2 blurdir	 : TEXCOORD1;
};

static float kernel[5] =
{ 
	0.21269,
	0.18269,
	0.14423,
	0.10576,
	0.067305,
}; 

float2 transformCoord(float2 uv, float2 blurdir, float num)
{
	uv.x = mad(blurdir.x, num, uv.x);
	uv.y = mad(blurdir.y, num, uv.y);
	return uv;
}

float4 main( VertToPix IN ) : COLOR
{
   float depth = prepassUncondition( normalMap, float4( IN.uv, 0, 0 ) ).w;
   float depthQ = saturate( 1 - depth * MAX_DEPTH_DIV)*0.65 + 0.25;
   IN.blurdir *= depthQ;
   
   //return float4(depthQ, 1-depthQ, 0, 1); //for debug
   
   float4 OUT = tex2D( diffuseMap, IN.uv ) * kernel[0];
   OUT += tex2D( diffuseMap, transformCoord(IN.uv,IN.blurdir,0.5f) ) * kernel[1];
   OUT += tex2D( diffuseMap, transformCoord(IN.uv,IN.blurdir,1.0f) ) * kernel[2];
   //OUT += tex2D( diffuseMap, IN.uv + IN.blurdir*1.5f ) * kernel[3];
   //OUT += tex2D( diffuseMap, IN.uv + IN.blurdir*2.0f ) * kernel[4];

   OUT += tex2D( diffuseMap, transformCoord(IN.uv,IN.blurdir,-0.5f) ) * kernel[1];
   OUT += tex2D( diffuseMap, transformCoord(IN.uv,IN.blurdir,-1.0f) ) * kernel[2];
   //OUT += tex2D( diffuseMap, IN.uv - IN.blurdir*1.5f ) * kernel[3];
   //OUT += tex2D( diffuseMap, IN.uv - IN.blurdir*2.0f ) * kernel[4];

   return OUT;
}
