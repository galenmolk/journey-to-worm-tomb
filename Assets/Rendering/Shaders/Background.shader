Shader "Worm Tomb/Background"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
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
                float4 vertex : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            uniform sampler2D _MainTex;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
    //add different dimensions
                float3 adjustedWorldPos = floor(i.worldPos / 0.05);
                float chessboard = adjustedWorldPos.x + adjustedWorldPos.y;
    //divide it by 2 and get the fractional part, resulting in a value of 0 for even and 0.5 for odd numbers.

                chessboard = frac(chessboard * 0.5);

    //multiply it by 2 to make odd values white instead of grey

                chessboard *= 2;
                return chessboard;
            }
            ENDCG
        }
    }
}
