//-----------------------------------------------------------------------------
// Torque 3D
// Copyright DeeLogic
//-----------------------------------------------------------------------------

struct VertData
{
   float3 position : POSITION;
   float2 texCoord : TEXCOORD0;

#ifdef _water
   float2 globalCoord : TEXCOORD1;
#endif
};

struct ConnectData
{
   float4 hpos     : POSITION;
   float2 texCoord : TEXCOORD0;

#ifdef _water
   float4 rippleTexCoord01 : TEXCOORD1;
   float2 rippleTexCoord2  : TEXCOORD2;
   float3 viewVec          : TEXCOORD3;
#endif
};

ConnectData main( VertData IN
#ifdef _water
                  ,
                  uniform float4   waterRippleMat[3],
                  uniform float2   waterRippleDir[3],
                  uniform float2   waterRippleTexScale[3],
                  uniform float3   waterRippleSpeed,
                  uniform float    elapsedTime
#endif
                )
{
   ConnectData OUT;

   OUT.hpos     = float4( IN.position.xyz, 1 );
   OUT.texCoord = IN.texCoord;

#ifdef _water
   float2x2 texMat;

   // set up tex coordinates for the 3 interacting normal maps
   texMat[0][0] = waterRippleMat[0].x;
   texMat[0][1] = waterRippleMat[0].y;
   texMat[1][0] = waterRippleMat[0].z;
   texMat[1][1] = waterRippleMat[0].w;
   OUT.rippleTexCoord01.xy = IN.globalCoord * waterRippleTexScale[0];
   OUT.rippleTexCoord01.xy += waterRippleDir[0] * elapsedTime * waterRippleSpeed.x;
   OUT.rippleTexCoord01.xy = mul( texMat, OUT.rippleTexCoord01.xy );

   texMat[0][0] = waterRippleMat[1].x;
   texMat[0][1] = waterRippleMat[1].y;
   texMat[1][0] = waterRippleMat[1].z;
   texMat[1][1] = waterRippleMat[1].w;
   OUT.rippleTexCoord01.zw = IN.globalCoord * waterRippleTexScale[1];
   OUT.rippleTexCoord01.zw += waterRippleDir[1] * elapsedTime * waterRippleSpeed.y;
   OUT.rippleTexCoord01.zw = mul( texMat, OUT.rippleTexCoord01.zw );

   texMat[0][0] = waterRippleMat[2].x;
   texMat[0][1] = waterRippleMat[2].y;
   texMat[1][0] = waterRippleMat[2].z;
   texMat[1][1] = waterRippleMat[2].w;
   OUT.rippleTexCoord2.xy = IN.globalCoord * waterRippleTexScale[2];
   OUT.rippleTexCoord2.xy += waterRippleDir[2] * elapsedTime * waterRippleSpeed.z;
   OUT.rippleTexCoord2.xy = mul( texMat, OUT.rippleTexCoord2.xy );

   OUT.viewVec = normalize(IN.position.xyz - float3(0.0f, 0.4f, -30.0f));
#endif

   return OUT;
}
