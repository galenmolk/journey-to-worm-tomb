Shader "WormTomb/HealthBar"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Health ("Health", Range(0, 1)) = 1
        _FillColor ("Fill Color", Color) = (0, 1, 0, 1)
        _BackgroundColor ("Background Color", Color) = (1, 0, 0, 1)
        _BorderWidthX ("Border Width X", Range(0.0, 0.2)) = 0.1
        _BorderWidthY ("Border Width Y", Range(0.0, 0.2)) = 0.1
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

            uniform sampler2D _MainTex;
            uniform float _Health;
            uniform float4 _FillColor;
            uniform float4 _BackgroundColor;
            uniform float _BorderWidthX;
            uniform float _BorderWidthY;
            
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (v2f i) : SV_Target
            {
                float4 tex = tex2D(_MainTex, i.uv);

                bool x = (i.uv.x < _BorderWidthX || i.uv.x > 1 - _BorderWidthX);
                bool y = (i.uv.y < _BorderWidthY || i.uv.y > 1 - _BorderWidthY);
                if (x || y)
                    return tex;
                
                float4 color = lerp(_BackgroundColor, _FillColor, i.uv.x < _Health);
                return color * tex;
            }
            ENDCG
        }
    }
}
