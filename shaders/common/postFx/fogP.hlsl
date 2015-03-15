//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

#include "shadergen:/autogenConditioners.h"
#include "./postFx.hlsl"
#include "./../torque.hlsl"

uniform sampler2D prepassTex : register(S0);
uniform sampler2D skyTex     : register(S1);

uniform float3    eyePosWorld;
uniform float4    fogColor;
uniform float3    fogData;
uniform float4    rtParams0;

uniform float2    envData; // x = 1 / visibility, y = fog exponent

float4 main( PFXVertToPix IN ) : COLOR
{   
   float2 prepassCoord = ( IN.uv0.xy * rtParams0.zw ) + rtParams0.xy;
   float  depth        = prepassUncondition( prepassTex, IN.uv0 ).w;

   float4 skyColor     = hdrDecode(tex2D( skyTex,  prepassCoord ));
   float  norlength    = length( IN.wsEyeRay * depth ) * envData.x;
   
   // Skip fogging the extreme far plane so that 
   // the canvas clear color always appears.
   clip( 0.9999 - depth );
    
   float3 tmp = IN.wsEyeRay * depth;
   float  h   = eyePosWorld.z + tmp.z;
   
   float factor = saturate( computeSceneFogAW( length(tmp),        // distance
                                               h,                  // height
                                               1.0f,               // viewerHeightScale
                                               fogData.x,          // fogDensity
                                               fogData.y,          // fogDensityOffset
                                               0.0f ) );           // fogHeightFalloff

   // BC = BaseColor
   // FC = FogColor
   // SC = SkyColor
   // FF = FogFactor
   // GF = GlobalFogFactor
   // IFF = 1 - FF
   // IGF = 1 - GF
   // 
   // Epoxy res color == 
   // lerp(lerp(BC, FC, IFF), SC, GF) == 
   // (BC*FF + FC*IFF)*IGF + SC*GF == 
   // (BC * FF*IGF) + (FC*IFF*IGF + SC*GF)
   // ==>
   // PostFX res color
   // (BC * FF*IGF) + (FC*IFF*IGF + SC*GF)
   
   // LERP(FC*IFF; SC; GF) / (1 - FF * IGF)
   
   float gf     = saturate( pow(norlength , envData.y)  );
   float iff    = 1 - factor;
   float iffigf = 1 - (factor * (1 - gf));
  
   return hdrEncode( float4( lerp(fogColor.rgb * iff, skyColor.rgb, gf) / iffigf, iffigf ) );
}
