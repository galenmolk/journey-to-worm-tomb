Shader "Custom/Background"
{
    Properties
    {
        _Color1 ("Color1", Color) = (1, 1, 1, 1)
        _Color2 ("Color1", Color) = (0, 1, 1, 1)
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

            uniform float4 _Color1;
            uniform float4 _Color2;

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float pixelGradient (float y)
            {
                return floor(y * 40) * .025;
            }
            
            float4 frag (Interpolators i) : SV_Target
            {
                float wavy = pixelGradient(i.uv.y * sin(_Time.y) + 0.1);
                float4 col = lerp(_Color1, _Color2, wavy);
                return col;
            }
            ENDCG
        }
    }
}
