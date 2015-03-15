//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

#include "./postFx.hlsl"
#include "./../torque.hlsl"


uniform float4 rtParams0;
uniform float4 rtParams1;
uniform float4 rtParams2;
uniform float4 rtParams3;
    
uniform float4 wsEyeRay[4];
	
	
PFXVertToPix main( PFXVert IN )
{
   PFXVertToPix OUT;
   
   OUT.hpos = IN.pos;
   OUT.uv0 = viewportCoordToRenderTarget( IN.uv, rtParams0 ); 
   OUT.uv1 = viewportCoordToRenderTarget( IN.uv, rtParams1 ); 
   OUT.uv2 = viewportCoordToRenderTarget( IN.uv, rtParams2 ); 
   OUT.uv3 = viewportCoordToRenderTarget( IN.uv, rtParams3 ); 

   int index = IN.corner.x;
   OUT.wsEyeRay = wsEyeRay[index].xyz;
   
   return OUT;
}
