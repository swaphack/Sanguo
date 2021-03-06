Shader "Motion/Dissolve/Dissolve_Direction"
{
    Properties
    {
        // 纹理
        _MainTex ("Texture", 2D) = "white" {}
        // 反转
        [Toggle]_Reverse("Reverse", int) = 0
        // 开始偏移位置
        _OffsetPosition("OffsetPosition", Vector) = (0,0,0,0)
        // 剔除方向0-x,1-y,2-z
        [Enum(Motion.Dissolve.DissolveDirection)]_Direction("Direction", int) = 0
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
        *   按照方向消失
        */
        Pass
        {
            Cull Off         

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            sampler2D _MainTex;
            bool _Reverse;
            fixed4 _OffsetPosition;
            int _Direction;
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
                float4 worldPos : TEXCOORD1;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.worldPos = mul(unity_ObjectToWorld, v.vertex) - _OffsetPosition;
                return o;
            }


            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                half value = 0;
                if (_Direction == 0) value = i.worldPos.x - _Threshold;
                else if (_Direction == 1) value = i.worldPos.y - _Threshold;
                else if (_Direction == 2) value = i.worldPos.z - _Threshold;
                if (_Reverse) value = -value;
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