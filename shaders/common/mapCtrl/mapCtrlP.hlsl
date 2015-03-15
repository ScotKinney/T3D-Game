//-----------------------------------------------------------------------------
// Torque 3D
// Copyright DeeLogic
//-----------------------------------------------------------------------------

struct ConnectData
{
   float4 hpos     : POSITION;
   float2 texCoord : TEXCOORD0;
};

float4 main(   ConnectData IN,
               uniform sampler2D baseMap,
               uniform sampler2D heightMap,
               uniform sampler1D gradientMap,
               uniform float3 lightDir,
               uniform float4 sunColor,
               uniform float4 ambientColor,
               uniform float2 lightBrightness,
               uniform float2 normalSampleOffset,
               uniform float4 squareSizeAndHeightParam, // x - sqare size, y - height scale, z - z base, w - waterHeight
               uniform float4 waterColor,
               uniform float  waterHeight,
               uniform float4 overlayColor,
               uniform float  useGradient,
               uniform float2 gradientRange,
               uniform float  opacity
            ) : COLOR
{
   float h0 = tex2D(heightMap, IN.texCoord).x * squareSizeAndHeightParam.y;
   
   if(h0 <= squareSizeAndHeightParam.w)
      return float4(waterColor.rgb, opacity);
   
   if(useGradient)
   {
      h0 = saturate((h0 - gradientRange.x)/(gradientRange.y - gradientRange.x));
      return float4(tex1D(gradientMap, h0).rgb, opacity);
   }
   
   float h1 = tex2D(heightMap, IN.texCoord + float2(normalSampleOffset.x, 0.0f)).x;
   float h2 = tex2D(heightMap, IN.texCoord + float2(0.0f, normalSampleOffset.y)).x;
   float h3 = tex2D(heightMap, IN.texCoord + float2(-normalSampleOffset.x, 0.0f)).x;
   float h4 = tex2D(heightMap, IN.texCoord + float2(0.0f, -normalSampleOffset.y)).x;

   float3 normal = float3((h1 - h3) * squareSizeAndHeightParam.y, (h4 - h2) * squareSizeAndHeightParam.y, 2.0f * squareSizeAndHeightParam.x);
   normal = normalize(normal);

//   float hh = tex2D(heightMap, IN.texCoord).x;
//   return float4(hh, hh, hh, 0);
//   return float4(normal, 0);

//   normal = float3(0, 0, 1);

   float4 baseColor = tex2D(baseMap,   IN.texCoord);
   float  light     = dot(lightDir, normal);
   
   float3 terrainColor = float3(baseColor.rgb * (ambientColor.rgb * lightBrightness.x + sunColor.rgb * lightBrightness.y * light));
   return float4(lerp(terrainColor, overlayColor.rgb, overlayColor.a), opacity);
}
