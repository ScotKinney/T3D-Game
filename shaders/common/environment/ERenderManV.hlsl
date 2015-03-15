//-----------------------------------------------------------------------------
// Copyright (C) DedicatedLogic
//-----------------------------------------------------------------------------

struct VertData
{
   float3 position : POSITION;
   float2 texCoord : TEXCOORD0;
};

struct ConnectData
{
   float4 hpos : POSITION;
   float2 texCoord : TEXCOORD0;
};

ConnectData main( VertData IN )
{
   ConnectData OUT;

   OUT.hpos     = float4( IN.position.xyz, 1 );
   OUT.texCoord = IN.texCoord;

   return OUT;
}
