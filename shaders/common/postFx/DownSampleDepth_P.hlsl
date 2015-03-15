//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

#include "shadergen:/autogenConditioners.h"




// These are set by the game engine.  
// The render target size is one-quarter the scene rendering size.  
uniform sampler2D colorSampler : register(S0);  
uniform float2 targetSize;

#define OOP  0.003921568627450980392156862745
#define OOP2 1.5378700499807766243752402921953e-5
#define OOP3 6.227372259080481780654823761473e-9

//255/256
#define A1 0.996093809371817670572857294849
//255/(256*256)
#define A2 0.0038909914428586627756752238080039
//255/(256*256*256)
#define A3 1.5199185323666651467481343000015e-5

//over values
#define OA1 0.00390625
#define OA2 0.0000152587890625
#define OA3 0.000000059604644775390625


inline float3 encodeFloatToRGBA ( float v ) 
{
    float3 enc = float3 ( 1.0, 255.0, 65025.0) * v;
    enc  = frac( enc );
    enc -= enc.yzz * float3 (1.0/255.0, 1.0/255.0, 0.0 );
    return enc;
}
inline float decodeFloatFromRGBA ( float3 rgb )
{
  return dot ( rgb, float3( 1.0, 1/255.0, 1/65025.0 ) );
}



float GetDepth(float2 uv)
{
	return dot(tex2D(colorSampler, uv).arg, float3(A1, A2, A3));
}

 
struct Pixel
{  
   float4 position : POSITION;  
   float2 tcColor0 : TEXCOORD0;  
   float2 tcColor1 : TEXCOORD1;  
};  

half4 main( Pixel IN ) : COLOR  
{  
   float2 dofRowDelta = float2( 0, 0.25 / targetSize.y );
   float depth;    
   float2 rowOfs[4];  
   
   // "rowOfs" reduces how many moves PS2.0 uses to emulate swizzling.  
   rowOfs[0] = 0;  
   rowOfs[1] = dofRowDelta.xy;  
   rowOfs[2] = dofRowDelta.xy * 2;  
   rowOfs[3] = dofRowDelta.xy * 3;  
   
   // Use bilinear filtering to average 4 color samples for free.
	depth = 0; //2 pow 24
	depth = max( depth, GetDepth( IN.tcColor0.xy + rowOfs[0] ) );
	depth = max( depth, GetDepth( IN.tcColor1.xy + rowOfs[0] ) );  
	depth = max( depth, GetDepth( IN.tcColor0.xy + rowOfs[2] ) );  
	depth = max( depth, GetDepth( IN.tcColor1.xy + rowOfs[2] ) );
   
   //encode depth into rgb
   return float4(depth, 0,0,0);
   //result.rgb = encodeFloatToRGBA( depth );
   //result.a = 1;
   
   //test
   //result.rgb = decodeFloatFromRGBA( result.rgb ).rrr;
   //result.rgb = depth.rrr; 
   //return result;
}  

