Shader "mqmtech/Background"
{
	Properties {
		_MainTex ("Color (RGB) Alpha (A)", 2D) = "white"
	 }
 
    SubShader {
    
    	Tags { "Queue"="Transparent" "RenderType"="Transparent" }
    	Blend SrcAlpha OneMinusSrcAlpha
    	
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            sampler2D _MainTex;

            struct vertexInput {
                float4 vertex : POSITION;
                float4 texcoord0 : TEXCOORD0;
            };

            struct fragmentInput{
                float4 position : SV_POSITION;
                float4 texcoord0 : TEXCOORD0;
            };

            fragmentInput vert(vertexInput i){
                fragmentInput o;
                o.position = mul (UNITY_MATRIX_MVP, i.vertex);
                o.texcoord0 = i.texcoord0;
                return o;
            }

            half4 frag(fragmentInput i) : COLOR {
            	half3 p = i.texcoord0 * 2 - 1;
            	
                half4 color = half4(0.9, 0.9, 0.9, 0.0);
                
                /*color = lerp(color, half4(0, 0, 0, 1), length(smoothstep(0, 0.3, abs(p.x))));
                color = lerp(color, half4(1, 0, 0, 1), length(smoothstep(0.2, 0.5, abs(p.x))));
                color = lerp(color, half4(0, 1, 0, 1), length(smoothstep(0.4, 0.7, abs(p.x))));
                color = lerp(color, half4(0, 0, 1, 1), length(smoothstep(0.6, 0.9, abs(p.x))));
                color = lerp(color, half4(1, 1, 1, 1), length(smoothstep(0.8, 1.0, abs(p.x))));*/
                
                //p.x += _Time.x;
                
                p.y *= 20;
                p.y += sin(_Time.y + p.x * 9) * 1.0;
                p.y += sin(_Time.x + p.x * 99) * 0.4;
                p.y += sin(p.x * 999) * 0.05;
                
                int xi = (int) p.y;
                int mod = xi % 2;
                if(mod > 0)
                {
                	color = half4(0.5, 0.0, 0.0, 1.0);
                }
                
                return color;
            }
            ENDCG
        }
    }
}
