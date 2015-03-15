#include "postFx.hlsl"  
#include "shadergen:/autogenConditioners.h"  

uniform sampler2D backBuffer : register(S0);
uniform float brightness;

float4 main( PFXVertToPix IN ) : COLOR0
{ 
 float4 backColor = tex2D(backBuffer, IN.uv0);

 return backColor * brightness;
}
