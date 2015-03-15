//*****************************************************************************
// TerrainBlock highlight shader
//*****************************************************************************

struct VertData
{
   float3 position        : POSITION;
   float3 normal          : NORMAL;
   float  tcTangentZ      : TEXCOORD0;
   float  tcEmpty         : TEXCOORD1;
};


struct ConnectData
{
   float4 hpos            : POSITION;
#ifndef LOG_Z
   float2 texCoord        : TEXCOORD0;
#else // LOG_Z
   float3 texCoord        : TEXCOORD0;
#endif // LOG_Z
};


//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
ConnectData main( VertData IN,
                  uniform float4x4 modelview  : register(C0),
                  uniform float    coordScale : register(C4)
)
{
   ConnectData OUT;

   OUT.hpos        = mul(modelview, float4(IN.position.xyz,1));
   OUT.texCoord.xy = IN.position.xy * float2(coordScale, coordScale);

#ifdef LOG_Z
   OUT.texCoord.z = OUT.hpos.w;
#endif // LOG_Z
   
   return OUT;
}
