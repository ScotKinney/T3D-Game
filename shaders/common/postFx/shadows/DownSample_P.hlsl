//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

#include "shadergen:/autogenConditioners.h"

// These are set by the game engine.  
// The render target size is one-quarter the scene rendering size.  
uniform sampler2D colorSampler : register(S0);  
uniform float2 targetSize;
 
struct Pixel
{  
   float4 position : POSITION;  
   float2 tcColor0 : TEXCOORD0;  
   float2 tcColor1 : TEXCOORD1;  
};  

half4 main( Pixel IN ) : COLOR  
{  
   float2 dofRowDelta = float2( 0, 0.25 / targetSize.y );
   half3 color;    
   float2 rowOfs[4];  
   
   // "rowOfs" reduces how many moves PS2.0 uses to emulate swizzling.  
   rowOfs[0] = 0;  
   rowOfs[1] = dofRowDelta.xy;  
   rowOfs[2] = dofRowDelta.xy * 2;  
   rowOfs[3] = dofRowDelta.xy * 3;  
   
   // Use bilinear filtering to average 4 color samples for free.  
   color = 0;  
   color += tex2D( colorSampler, IN.tcColor0.xy + rowOfs[0] ).rgb;  
   color += tex2D( colorSampler, IN.tcColor1.xy + rowOfs[0] ).rgb;  
   color += tex2D( colorSampler, IN.tcColor0.xy + rowOfs[2] ).rgb;  
   color += tex2D( colorSampler, IN.tcColor1.xy + rowOfs[2] ).rgb;  
   color /= 4;  
   
   return half4(color, 1);
}  