struct VertData
{
   float3 position        : POSITION;
   float3 normal          : NORMAL;
   float  tcTangentZ      : TEXCOORD0;
   float  isWater         : TEXCOORD1;
};


struct ConnectData
{
   float4 hpos            : POSITION;
   float3 normal          : TEXCOORD0;
   float4 outTexCoord     : TEXCOORD1;
   float4 wpos            : TEXCOORD2;
};


//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
ConnectData main( VertData IN,
                  uniform float4x4 modelview,
                  uniform float4x4 world,
                  uniform float    oneOverTerrainSize,
                  uniform float3   camPos
)
{
   ConnectData OUT;
   float4 pos         = float4(IN.position.xyz, 1.0f);
   float4 wp          = mul(world, pos);
   
   OUT.hpos           = mul(modelview, pos);
   OUT.wpos           = float4(wp.xyz, length(wp.xyz - camPos.xyz));   
   OUT.normal         = mul(world,     float4(IN.normal, 0.0f)).xyz;    

   OUT.outTexCoord.xy = IN.position.xy * float2( oneOverTerrainSize, oneOverTerrainSize );
   OUT.outTexCoord.zw = float2(OUT.hpos.x, -OUT.hpos.y) / OUT.hpos.w * 0.5f + 0.5f;

   return OUT;
}
