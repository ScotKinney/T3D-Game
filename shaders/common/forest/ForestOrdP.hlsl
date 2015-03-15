/*
==============================================

(c) dw
==============================================
*/


struct ConnectData
{
	float4 screenspacePosW : TEXCOORD0;
	float4 texCoord : TEXCOORD1;
	float3x3 viewToTangent : TEXCOORD2;
	float4 wsEyeVec : TEXCOORD5;
};


struct Fragout
{
	float4 col : COLOR0;
	float4 col1 : COLOR1;
	//float depth : DEPTH;
};


uniform float4 varData : register(C0); //xyz - eyeVector, w - alphaTestValue
uniform sampler2D baseTex : register(S0);
uniform sampler2D bumpTex : register(S1);




//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
Fragout main( ConnectData IN )
{
	Fragout OUT;
	
	// main color
	OUT.col1 = tex2D(baseTex, IN.texCoord);
	clip( OUT.col1.a - varData.w );
	OUT.col1.a = 0;
	
	// logz depth
	//OUT.depth = (log(IN.screenspacePosW.w) - -6.907755375) * 0.048254941;
   
   
    //------------------------------------------------------
	// Bumpmap [Deferred]
	
	float4 bumpNormal = tex2D(bumpTex, IN.texCoord);	
	bumpNormal.xyz = bumpNormal.xyz * 2.0 - 1.0;
	float3 gbNormal = (float3)mul( bumpNormal.xyz, IN.viewToTangent );
   
	float eyeSpaceDepth = dot(varData.xyz, IN.wsEyeVec.xyz);
	
	float4 normal_depth = float4(normalize(gbNormal), eyeSpaceDepth);

	float4 _gbConditionedOutput =
		float4(
			sqrt(half(2.0/(1.0 - normal_depth.y))) * half2(normal_depth.xz),
			0.0,
			normal_depth.a
			);

	// Encode depth into hi/lo
	float2 _tempDepth = frac(normal_depth.a * float2(1.0, 65535.0));
	_gbConditionedOutput.zw = _tempDepth.xy - _tempDepth.yy * float2(1.0/65535.0, 0.0);
	
	// normal output
	// (normal + depth, packed)
	OUT.col = _gbConditionedOutput;
   
	return OUT;
}
