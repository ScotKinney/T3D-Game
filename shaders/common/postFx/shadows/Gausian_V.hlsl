//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

#include "./../postFx.hlsl"
#include "./../../torque.hlsl"


uniform float2 texSize0;
uniform float4 rtParams0;
uniform float2 oneOverTargetSize; 

struct VertToPix
{
   float4 hpos       : POSITION;

   float2 uv		 : TEXCOORD0;
   float2 blurdir	 : TEXCOORD1;
};

VertToPix main( PFXVert IN )
{
   VertToPix OUT;
   
   IN.uv = viewportCoordToRenderTarget( IN.uv, rtParams0 );
   
   OUT.hpos = IN.pos;
   OUT.uv = IN.uv;
   OUT.blurdir = BLUR_DIR / texSize0;
   
   /*OUT.uv0 = IN.uv + ( ( BLUR_DIR * 3.5f ) / texSize0 );
   OUT.uv1 = IN.uv + ( ( BLUR_DIR * 2.5f ) / texSize0 );
   OUT.uv2 = IN.uv + ( ( BLUR_DIR * 1.5f ) / texSize0 );
   OUT.uv3 = IN.uv + ( ( BLUR_DIR * 0.5f ) / texSize0 );

   OUT.uv4 = IN.uv - ( ( BLUR_DIR * 3.5f ) / texSize0 );
   OUT.uv5 = IN.uv - ( ( BLUR_DIR * 2.5f ) / texSize0 );
   OUT.uv6 = IN.uv - ( ( BLUR_DIR * 1.5f ) / texSize0 );
   OUT.uv7 = IN.uv - ( ( BLUR_DIR * 0.5f ) / texSize0 ); */  
      
   return OUT;
}
