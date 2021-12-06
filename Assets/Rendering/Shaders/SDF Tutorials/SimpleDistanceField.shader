Shader "Custom/SimpleDistanceField"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BorderWidth("Border Width", Float) = 0.5
        _Background("Background", Color) = (0,0,0.25,1)
        _Border("Border", Color) = (0,1,0,1)
        _Offset("Offset", Range(-1, 1)) = 0
        _Fill ("Fill", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;

            // field controls
            float _BorderWidth;
            float _Offset;

            // colors
            float4 _Background;
            float4 _Border;
            float4 _Fill;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                // stretch quad to maintain aspect ratio
                o.vertex.y *= _MainTex_TexelSize.x * _MainTex_TexelSize.w;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.uv = 1 - o.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 sdf = tex2D(_MainTex, i.uv);

                float d = sdf.r + _Offset;

                if (abs(d) < _BorderWidth)
                    return _Border;
                else if (d < 0)
                    return _Fill;
                else
                    return _Background;
            }
            ENDCG
        }
    }
}
