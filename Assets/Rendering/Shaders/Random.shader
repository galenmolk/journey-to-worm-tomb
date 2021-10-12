Shader "Unlit/Random"
{
    Properties
    {
        _Color1 ("Color1", Vector) = (1, 1, 1, 1)
        _Color2 ("Color2", Vector) = (1, 1, 1, 1)
        _Color3 ("Color3", Vector) = (1, 1, 1, 1)
        _Color4 ("Color4", Vector) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _Color1;
            float4 _Color2;
            float4 _Color3;
            float4 _Color4;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = fixed4(sin(_Time.y * 5), sin(_Time.y), sin(_Time.y * 0.5), sin(_Time.y * 0.05));
                col.x *= _Color1.x;
                col.y *= _Color2.y;
                col.z *= _Color3.z;
                return col;
            }
            ENDCG
        }
    }
}
