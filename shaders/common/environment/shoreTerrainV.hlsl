//-----------------------------------------------------------------------------
// Copyright (C) DedicatedLogic
//-----------------------------------------------------------------------------

struct VertData
{
   float3 position        : POSITION;
   float3 normal          : NORMAL;
   float  tcTangentZ      : TEXCOORD0;
   float  isEmpty         : TEXCOORD1;
};


struct ConnectData
{
   float4 hpos            : POSITION;
   float  height          : TEXCOORD0;
};


//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
ConnectData main( VertData IN,
                  uniform float4x4 modelview,
                  uniform float height )
{
   ConnectData OUT;
   OUT.hpos   = mul(modelview, float4(IN.position.xyz, 1.0f));
   OUT.height = IN.position.z + height;
  
   return OUT;
}
