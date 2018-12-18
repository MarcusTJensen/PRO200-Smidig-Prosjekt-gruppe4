// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Unlit/Pano360Shader" {
	Properties
   {
       _MainTex ("Diffuse (RGB) Alpha (A)", 2D) = "gray" {}
       _Color ("Main Color", Color) = (1,1,1,0.5)
   }
   
   SubShader 
   {
   Pass{
        Tags {"LightMode" = "Always"}
        Cull Front
        

            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma fragmentoption ARB_precision_hint_fastest
                #pragma glsl
                #pragma target 3.0

                #include "UnityCG.cginc"

                struct appdata {
                   float4 vertex : POSITION;
                   float3 normal : NORMAL;
                };

                struct v2f
                {
                    float4    pos : SV_POSITION;
                    float3    normal : TEXCOORD0;
                };

                v2f vert (appdata v)
                {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.normal = v.normal;
                    return o;
                }

                sampler2D _MainTex;

                #define PI 3.141592653589793

                inline float2 RadialCoords(float3 a_coords)
                {
                    float3 a_coords_n = normalize(a_coords);
                    float lon = atan2(a_coords_n.z, a_coords_n.x);
                    float lat = acos(a_coords_n.y);
                    float2 sphereCoords = float2(lon, lat) * (1.0 / PI);
                    return float2(sphereCoords.x * 0.5 + 0.5, 1 - sphereCoords.y);
                }

                float4 frag(v2f IN) : COLOR
                {
                    float2 equiUV = RadialCoords(IN.normal);
                    return tex2D(_MainTex, equiUV);
                }
            ENDCG
        }
    }
    FallBack "VertexLit"
   /*
      Tags { "RenderType" = "Opaque"}
      //This is used to print the texture inside of the sphere
      Cull Front
      CGPROGRAM
      #pragma surface surf SimpleLambert
      half4 LightingSimpleLambert (SurfaceOutput s, half3 lightDir, half atten)
      {
         half4 c;
         c.rgb = s.Albedo;
         return c;
      }
      
      sampler2D _MainTex;
      struct Input
      {
         float2 uv_MainTex;
         float4 myColor : COLOR;
      };
 
      fixed3 _Color;
      void surf (Input IN, inout SurfaceOutput o)
      {
         //This is used to mirror the image correctly when printing it inside of the sphere
         IN.uv_MainTex.x = 1 — IN.uv_MainTex.x;
         fixed3 result = tex2D(_MainTex, IN.uv_MainTex)*_Color;
         o.Albedo = result.rgb;
         o.Alpha = 1;
      }
      ENDCG
   }
   Fallback "Diffuse"
   */
}