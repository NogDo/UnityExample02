Shader "Custom/TestSurfaceShader"
{
	// 이 셰이더에서 사용할 변수 선언
	Properties
	{
		// _변수명 ([Inspector에서 표시될 이름], 자료형) = [초기값 할당] 라인의 끝에선 ;대신 줄바꿈으로 구분
		_MainTex("Main Texture", 2D) = "white" {}
		OverlabTex("Overlab Texture", 2D) = "gray" {}
		_colorAmount("Color AMount", Range(0, 1)) = 1
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }

		// Level Of Detail의 약자. 200 : Diffuse Level
		LOD 200

		// C For Graphics 문법이 사용된 영역 (CGPROGRAM ~ ENDCG)
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert
		// 정점 셰이더 라이브러리 함수를 사용하겠다.
		//#pragma vertex vert
		// 픽셀 셰이딩 라이브러리 함수를 사용하겠다.
		//#pragma fragment frag

		sampler2D _MainTex;
		sampler2D OverlabTex;
		float _colorAmount;

		struct Input
		{
			// uv 매핑을 적용한 _MainTex 색 정보
			float2 uv_MainTex;
			float2 uvOverlabTex;
			float4 screenPos;
		};

			// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
			// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
			// #pragma instancing_options assumeuniformscaling
			UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)
		
		// _Time : float4, 즉 4차원의 값으로 제공이 되는데
		// x = t / 20,	y = t,	z = t * 2,	w = t * 3

		void surf(Input IN, inout SurfaceOutput o)
		{
			// 표면 셰이더에 텍스쳐 색을 적용
			o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * _colorAmount;
			//oAlbedo *= tex2D(OverlabTex, IN.uvOverlabTex).rgb;
			
			float2 screenUV = (IN.screenPos.xy / IN.screenPos.w) * float2(10, 5);
			o.Albedo *= tex2D(OverlabTex, screenUV + _Time.y).rgb;
		}
		ENDCG
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		// C For Graphics 문법이 사용된 영역 (CGPROGRAM ~ ENDCG)
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;

		struct Input
		{
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf(Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb * 0.5;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Standard"
}
