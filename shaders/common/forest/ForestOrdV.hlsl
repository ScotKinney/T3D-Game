/*
==============================================

(c) dw
==============================================
*/
#include "./../wind.hlsl"
#include "./../torque.hlsl"


struct VertData
{
	float3 position        : POSITION;
	float tangentW        : TEXCOORD3;
	float3 normal          : NORMAL;
	float3 T               : TANGENT;
	float2 texCoord        : TEXCOORD0;
	float2 texCoord2       : TEXCOORD1;
	float4 diffuse         : COLOR;
	float texCoord3       : TEXCOORD2;
};

struct ConnectData
{
	float4 hpos            : POSITION;
	float4 screenspacePosW : TEXCOORD0;
	float4 texCoord : TEXCOORD1;
	float3x3 outViewToTangent : TEXCOORD2;
	float4 wsEyeVec : TEXCOORD5;
};


uniform float4x4 worldTransform;
uniform float4x4 worldViewProjTransform;
uniform float4x4 viewToObj;
uniform float3 eyePosWorld;

//wind stuff
uniform float4   windParams;
uniform float3   windDirAndSpeed;
uniform float    accumTime;

//-----------------------------------------------------------------------------
// Main
//-----------------------------------------------------------------------------
ConnectData main( VertData IN )
{
	ConnectData OUT;
   
	float3 inPosition = IN.position.xyz;
	if ( any( windDirAndSpeed ) )
	{
		inPosition = windBranchBending(
			inPosition,
			normalize( IN.normal ),
			accumTime,
			windDirAndSpeed.z,
			IN.diffuse.g,
			windParams.y,
			IN.diffuse.r,
			dot( worldTransform[3], 1 ),
			windParams.z,
			windParams.w,
			IN.diffuse.b );
		inPosition = 
			windTrunkBending( inPosition, windDirAndSpeed.xy, inPosition.z * windParams.x );
	}
	
	// calc position
	OUT.hpos = mul(worldViewProjTransform, float4(inPosition.xyz,1));  
	
	// calc depth
	OUT.screenspacePosW = float4(0, 0, 0, OUT.hpos.w);
	
	// pass texcoords
	OUT.texCoord = float4(IN.texCoord.xy,0,0);
   
    // deferred bump
    float3x3 objToTangentSpace;
	objToTangentSpace[0] = IN.T;
	objToTangentSpace[1] = cross( IN.T, normalize(IN.normal) ) * IN.tangentW;
	objToTangentSpace[2] = normalize(IN.normal);
	float3x3 viewToTangent = mul( objToTangentSpace, (float3x3)viewToObj );
	OUT.outViewToTangent = viewToTangent;
   
    // Eye Space Depth (Out)
	float3 depthPos = mul( worldTransform, float4(inPosition.xyz,1) ).xyz;
	OUT.wsEyeVec = float4( depthPos.xyz - eyePosWorld, 1 );
   
	return OUT;
}
