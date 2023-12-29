Shader "Custom/FirstShader"
{
    Properties{
        _MainTex("Base (RGB)", 2D) = "white" { }
        _Color("Sphere Color", Color) = (1,1,1,1) // Warna untuk setengah bagian lainnya
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }
            LOD 200

            CGPROGRAM
            #pragma surface surf Lambert

    sampler2D _MainTex;
    fixed4 _Color;

    struct Input
    {
        float2 uv_MainTex;
    };

    void surf(Input IN, inout SurfaceOutput o)
    {
        // Mengambil warna dari tekstur asli
    fixed4 texColor = tex2D(_MainTex, IN.uv_MainTex);

    // Membuat setengah bagian menjadi gelap
    if (IN.uv_MainTex.y < 0.5)
    {
        o.Albedo = 0.1 * texColor.rgb; // Menggabungkan dengan warna gelap, bisa disesuaikan
    }
    else
    {
        // Setengah lainnya memiliki warna dari tekstur asli
    o.Albedo = _Color.rgb * texColor.rgb;
    }
    }
            ENDCG
            }
                FallBack"Diffuse"
}