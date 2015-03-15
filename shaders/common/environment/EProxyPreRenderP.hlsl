//-----------------------------------------------------------------------------
// Copyright (C) DedicatedLogic
//-----------------------------------------------------------------------------

#include "./../torque.hlsl"

struct ConnectData
{
   float3 normal          : TEXCOORD0;
   float4 texCoord        : TEXCOORD1;
   float4 wpos            : TEXCOORD2;
};


struct Fragout
{
   float4 col : COLOR0;
};


//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
Fragout main( ConnectData IN,
              uniform sampler2D baseTexMap,
              uniform sampler2D skyTexMap,
              uniform sampler2D clipMap,
              uniform float     baseScale,
              uniform float4    envDataFogData,    // x = envDistance, y = envExponent, z = fogDensity, w = fogDensityOffset
              uniform float4    fogColor,
              uniform float4    sunParam,
              uniform float4    sunColor,
              uniform float4    ambientColor
             )
{
   Fragout OUT;

   float clipVal = tex2D( clipMap, IN.texCoord.xy * baseScale * float2(1.01f, 1.01f) - float2(0.005f, 0.005f)).x;

   clip(-clipVal);
   clip(IN.wpos.z - 1000);


   float norLength   = IN.wpos.w * envDataFogData.x;   
   float fogFactor   = saturate(computeSceneFogAW( IN.wpos.w, // distance
                                                   IN.wpos.z, // height
                                                   1.0f,
                                                   envDataFogData.z,           // fogDensity
                                                   envDataFogData.w,           // fogDensityOffset
                                                   0.0f));     // fogHeightFalloff


   float4 baseColor  = tex2D( baseTexMap, IN.texCoord.xy * baseScale);
   float4 skyColor   = hdrDecode(tex2D( skyTexMap,  IN.texCoord.zw ));
  
	float dotNL = saturate(dot(normalize(IN.normal), normalize(sunParam.xyz)));
	float normalLight = dotNL * sunParam.w;
	float4 lightMod = saturate(normalLight*sunColor + ambientColor);
	baseColor *= lightMod;  
	//baseColor *= saturate(dotNL)*0.65+0.35; //SHADOWTERM
	
	//------------------------------
	// old math
	
	//OUT.col = lerp(fogColor, baseColor, fogFactor);
	//OUT.col = lerp(OUT.col, skyColor, saturate(pow(abs(norLength), envDataFogData.y)));
	
	//-----------------------------------
	//math from fogP.hlsl
	
	float gf     = saturate( pow(norLength , envDataFogData.y)  );
	float iff    = 1 - fogFactor;
	float iffigf = 1 - (fogFactor * (1 - gf));

	OUT.col.rgb = lerp(fogColor.rgb * iff, skyColor.rgb, gf) + (1-iffigf)*baseColor;
	
	
	OUT.col.a = 1.0f;
	       
	//OUT.col = lerp(lerp(fogColor, baseColor, fogFactor),
	//skyColor, saturate(pow(abs(norLength), envDataFogData.y)));
	
   
   // show base color only
   //OUT.col = baseColor;

   // show normal
   //OUT.col = float4(normalize(IN.normal.xyz) * 0.5 + 0.5, 1.0f);   
   
   // show light
   //float d = dot(normalize(IN.normal), normalize(IN.sunlight)); 
   //OUT.col = float4(d, d, d, 1.0f);
   
   //OUT.col = hdrEncode(OUT.col);

   return OUT;
}
