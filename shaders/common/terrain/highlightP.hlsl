//*****************************************************************************
// TerrainBlock highlight shader
//*****************************************************************************

#include "shaders/common/torque.hlsl"

struct ConnectData
{
#ifndef LOG_Z
   float2 texCoord : TEXCOORD0;
#else
   float3 texCoord : TEXCOORD0;
#endif
};


struct Fragout
{
   float4 col      : COLOR0;
#ifdef LOG_Z
   float  depth    : DEPTH;
#endif // LOG_Z
};


//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
Fragout main( ConnectData IN,
              uniform sampler2D highlightMap    : register(S0),
              uniform sampler2D atlasMap        : register(S1),
              uniform float4    atlasSize,
              uniform float2    squareCount
)
{
   Fragout OUT;

   float highlight = tex2D(highlightMap, IN.texCoord).x * 255 - 1;          // reserve value "0" for no highlight square
   clip(highlight);

#ifdef LOG_Z
   OUT.depth = (log(IN.texCoord.z) - LOG_Z_NEAR) * LOG_Z_FARNEARI;
#endif

   
   float2 slot;
   slot.x =       highlight % atlasSize.x;
   slot.y = floor(highlight / atlasSize.x);
  

   float2 coord = ((IN.texCoord.xy * squareCount) % 1.0 + slot) * atlasSize.zw;

   OUT.col = tex2D( atlasMap, coord );
         
   // HDR Output
   OUT.col = hdrEncode( OUT.col );

   return OUT;
}
