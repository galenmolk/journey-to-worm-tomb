Shader "Unlit/Background"
{
    Properties
    {
        _BackgroundTex ("Texture", 2D) = "white" {}
        [HideInInspector] _ScrollSpeed ("Scroll Speed", Float) = 0.5
        _SpeedFactor ("Speed Factor", Range(0, 0.1)) = 0.1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

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

            sampler2D _BackgroundTex;
            float4 _BackgroundTex_ST;
            float _ScrollSpeed;
            float _SpeedFactor;

            v2f vert (appdata v)
            {
                v2f o;
                v.uv.x += _Time.y * _ScrollSpeed * _SpeedFactor;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _BackgroundTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_BackgroundTex, i.uv);
                _BackgroundTex_ST.w += _Time.y;
                return col;
            }
            ENDCG
        }
    }
}
