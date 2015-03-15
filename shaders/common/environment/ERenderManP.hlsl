//-----------------------------------------------------------------------------
// Copyright (C) DedicatedLogic
//-----------------------------------------------------------------------------


struct ConnectData
{
   float4 hpos     : POSITION;
   float2 texCoord : TEXCOORD0;
};

float4 main(   ConnectData IN,
               uniform sampler2D textureMap : register(S0)
           ) : COLOR
{
   return tex2D( textureMap, IN.texCoord );
}
