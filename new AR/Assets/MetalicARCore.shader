Shader "ARCore/MetallicWithLightEstimation"
{
    Properties
    {
        _Shininess ("Shininess", Range (0.03, 1)) = 0.078125
        _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
				_MetallicGlossMap ("Metallic", 2D) = "black" {}
        [NoScaleOffset] _BumpMap ("Normalmap", 2D) = "bump" {}
    }
    SubShader
    {
        Tags {"RenderType" = "Opaque" }
        LOD 250

        CGPROGRAM
        #pragma surface surf MobileBlinnPhong exclude_path:prepass nolightmap noforwardadd halfasview interpolateview finalcolor:lightEstimation
        #pragma shader_feature _METALLICGLOSSMAP

        inline fixed4 LightingMobileBlinnPhong (SurfaceOutput s, fixed3 lightDir, fixed3 halfDir, fixed atten)
        {
            fixed diff = max (0, dot (s.Normal, lightDir));
            fixed nh = max (0, dot (s.Normal, halfDir));
            fixed spec = pow (nh, s.Specular*128) * s.Gloss;

            fixed4 c;
            c.rgb = (s.Albedo * _LightColor0.rgb * diff + _LightColor0.rgb * spec) * atten;
            return c;
        }

        sampler2D _MainTex;
        sampler2D _BumpMap;
				sampler2D _MetallicGlossMap;
        half _Shininess;
        fixed3 _GlobalColorCorrection;


        struct Input
        {
            float2 uv_MainTex;
        };

        void lightEstimation(Input IN, SurfaceOutput o, inout fixed4 color)
        {
            color.rgb *= _GlobalColorCorrection;
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
						fixed4 met = tex2D(_MetallicGlossMap, IN.uv_MainTex);
            o.Albedo = tex.rgb;
            o.Gloss = _Shininess - met.a;
            o.Specular = _Shininess - met.rgb;
            o.Normal = UnpackNormal (tex2D(_BumpMap, IN.uv_MainTex));
        }
        ENDCG
    }

    FallBack "Mobile/VertexLit"
}
