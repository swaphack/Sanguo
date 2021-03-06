Shader "Motion/Dissolve/Dissolve_Texture"
{
    Properties
    {
        // 纹理
        _MainTex("Texture", 2D) = "white" {}
        // 灰度纹理
        _GrayTex("GrayTexture", 2D) = "white" {}
        // 反转
        [Toggle]_Reverse("Reverse", int) = 0
        // 剔除阈值
        _Threshold("Threshold", Range(0, 1)) = 0
        // 光效阈值
        _EffectThreshold("EffectThreshold", Range(0, 1)) = 0
        // 光效颜色
        _EffectColor("EffectColor", Color) = (0,0,0,0)
    }
    SubShader
    {
        /*
        *   灰度图
        */
        Pass
        {
            Cull Off

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            sampler2D _GrayTex;
            bool _Reverse;
            float _Threshold;
            float _EffectThreshold;
            fixed4 _EffectColor;

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

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }


            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                fixed4 gray = tex2D(_GrayTex, i.uv);
                half value = gray.r - _Threshold;
                if (_Reverse) value = - value;
                if (value <= _EffectThreshold 
                    && _Threshold >= _EffectThreshold 
                    && _Threshold + _EffectThreshold <= 1)
                {
                    col = _EffectColor;
                }
                clip(value);
                return col;
            }
            ENDCG
        }
    }
}