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
              uniform float2    squareCount
)
{
   Fragout OUT;

float3 colorTable[8] = {float3(0.0,   1.0,   0.0),
                        float3(0.0,   1.0,   1.0),
                        float3(1.0,   0.6,   0.0),
                        float3(0.22,  0.463, 0.114),
                        float3(0.067, 0.334, 0.8),
                        float3(0.96,  0.7,   0.42),
                        float3(1.0,   0.0,   0.0),
                        float3(1.0,   1.0,   1.0)};

float4 chanelMask[4] = {float4(1.0, 0.0, 0.0, 0.0),
                        float4(0.0, 1.0, 0.0, 0.0),
                        float4(0.0, 0.0, 1.0, 0.0),
                        float4(0.0, 0.0, 0.0, 1.0)};

float2x2 texRotate[4] = { float2x2( 1,  0,  0,  1),
                          float2x2( 0,  1, -1,  0),
                          float2x2(-1,  0,  0, -1),
                          float2x2( 0, -1,  1,  0) };

   float claim = tex2D(highlightMap, IN.texCoord.xy).x * 255 -1;          // reserve value "0" for no highlight square
   clip(claim);

#ifdef LOG_Z
   OUT.depth = (log(IN.texCoord.z) - LOG_Z_NEAR) * LOG_Z_FARNEARI;
#endif

	float  colorType = floor(claim/16);
   float3 color     = colorTable[colorType];

	claim -= colorType*16;
	float chanel     = clamp(floor(claim/4), 0, 4);

	claim -= chanel*4;
	float rotation   = clamp(claim, 0, 4);

#if 1
   float2 coord = (mul(texRotate[rotation], IN.texCoord.xy) * squareCount);
   float  alpha = dot(tex2D( atlasMap, float2(coord.x, coord.y) ), chanelMask[chanel]);
#else
   float2 coord = (IN.texCoord.xy * squareCount);
   float  alpha = 0;
   switch(rotation)
   {
   case 0:
      alpha = dot(tex2D( atlasMap, float2( coord.x,  coord.y) ), chanelMask[chanel]);
      break;
   case 1:
      alpha = dot(tex2D( atlasMap, float2( coord.y, -coord.x) ), chanelMask[chanel]);
      break;
   case 2:
      alpha = dot(tex2D( atlasMap, float2(-coord.x, -coord.y) ), chanelMask[chanel]);
      break;
   case 3:
      alpha = dot(tex2D( atlasMap, float2(-coord.y, coord.x) ), chanelMask[chanel]);
      break;
   }
#endif
 
   OUT.col = float4(color, alpha);

// HDR Output
   OUT.col = hdrEncode( OUT.col );

   return OUT;
}
