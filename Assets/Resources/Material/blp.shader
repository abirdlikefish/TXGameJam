Shader "Custom/blp"
{
    Properties
    {
        _Diffuse("_Diffuse",Color) = (1,1,1,1) // 控制材质颜色及其透明度
    }

    SubShader
    {
        Tags { "LightMode" = "ForwardBase" }
        ZWrite Off
        ZTest Always
        // 启用透明混合模式
        Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Lighting.cginc"

            fixed4 _Diffuse;

            struct a2v {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                fixed3 color : COLOR;
            };

            v2f vert(a2v v) 
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                fixed3 ambient = UNITY_LIGHTMODEL_AMBIENT.xyz;
                fixed3 worldNormal = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
                fixed3 worldLight = normalize(_WorldSpaceLightPos0.xyz);
                fixed3 diffuse = _LightColor0.rgb * _Diffuse.rgb * saturate(dot(worldNormal, worldLight));
                o.color = ambient + diffuse;
                return o;
            }

            fixed4 frag(v2f i) :SV_Target
            {
                // 使用透明度混合效果，只叠加光照部分
                return fixed4(i.color, _Diffuse.a); // 使用透明度控制
            }
            ENDCG
        }
    }
    Fallback "Diffuse"
}
