Shader "Custom/Shader3"
{
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" { }
        _Color("Sphere Color", Color) = (1, 1, 1, 1)
        _RotationSpeed("Rotation Speed", Range(0, 10)) = 1
    }

        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            fixed4 _Color;
            float _RotationSpeed;

            struct Input
            {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o)
            {
                fixed4 texColor = tex2D(_MainTex, IN.uv_MainTex);

                // Menggunakan waktu untuk menganimasikan rotasi
                float time = _Time.y * _RotationSpeed;
                float angle = time * 6.28; // 6.28 radians = 360 degrees

                // Menghitung koordinat baru setelah rotasi
                float2 rotatedUV = mul(float2x2(cos(angle), -sin(angle), sin(angle), cos(angle)), IN.uv_MainTex - 0.5) + 0.5;

                // Memutuskan apakah bagian atas atau bawah dari objek
                if (rotatedUV.y < 0.5)
                {
                    o.Albedo = 0.3 * texColor.rgb;
                }
                else
                {
                    o.Albedo = _Color.rgb * texColor.rgb;
                }
            }
            ENDCG
        }

            FallBack "Diffuse"
}