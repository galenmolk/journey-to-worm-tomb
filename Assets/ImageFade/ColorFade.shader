Shader "Custom/ColorFade"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _FadeAmount ("Fade Amount", Range(0,1)) = 1
        _FadeWidth ("Fade Width", Range(0, 1)) = 1
        _Color ("Color", Color) = (1,1,1,1) 
    }
    
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            uniform sampler2D _MainTex;
            uniform float4 _MainTex_ST;
            uniform float _FadeAmount;
            uniform float _FadeWidth;
            uniform float4 _Color;

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float InverseLerp(float start, float end, float input)
            {
                return (input - start)/(end - start);
            }
            
            float4 frag (Interpolators i) : SV_Target
            {
                float t = InverseLerp(_FadeAmount - _FadeWidth, _FadeAmount + _FadeWidth, (i.uv.y + i.uv.x) * 0.5);

                // Clamp value between 0 and 1.
                t = saturate(t);
                
                _Color.a = lerp(1, 0, t);
                return _Color;
            }
            ENDCG
        }
    }
}
