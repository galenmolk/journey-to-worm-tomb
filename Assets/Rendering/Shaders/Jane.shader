Shader "Custom/Jane"
{
    Properties
    {
        [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}

        _R_Val ("R Value", Range(0,1)) = 0
        _G_Val ("G Value", Range(0,1)) = 0
        _B_Val ("B Value", Range(0,1)) = 0
        _A_Val ("A Value", Range(0,1)) = 0
    }
    SubShader
    {
        Tags
        {
            "RenderType"="Transparent"
            "Queue"="Transparent"
        }

        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

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
            float _R_Val;
            float _G_Val;
            float _B_Val;
            float _A_Val;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                col.r = _R_Val;
                col.g = _G_Val;
                col.b = _B_Val;
                col.a = _A_Val;
                return col;
            }
            ENDCG
        }
    }
}
