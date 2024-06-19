Shader "Custom/TestSurfaceShader"
{
	// �� ���̴����� ����� ���� ����
	Properties
	{
		// _������ ([Inspector���� ǥ�õ� �̸�], �ڷ���) = [�ʱⰪ �Ҵ�] ������ ������ ;��� �ٹٲ����� ����
		_MainTex("Main Texture", 2D) = "white" {}
		OverlabTex("Overlab Texture", 2D) = "gray" {}
		_colorAmount("Color AMount", Range(0, 1)) = 1
	}
	SubShader
	{
		Tags { "RenderType" = "Opaque" }

		// Level Of Detail�� ����. 200 : Diffuse Level
		LOD 200

		// C For Graphics ������ ���� ���� (CGPROGRAM ~ ENDCG)
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert
		// ���� ���̴� ���̺귯�� �Լ��� ����ϰڴ�.
		//#pragma vertex vert
		// �ȼ� ���̵� ���̺귯�� �Լ��� ����ϰڴ�.
		//#pragma fragment frag

		sampler2D _MainTex;
		sampler2D OverlabTex;
		float _colorAmount;

		struct Input
		{
			// uv ������ ������ _MainTex �� ����
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
		
		// _Time : float4, �� 4������ ������ ������ �Ǵµ�
		// x = t / 20,	y = t,	z = t * 2,	w = t * 3

		void surf(Input IN, inout SurfaceOutput o)
		{
			// ǥ�� ���̴��� �ؽ��� ���� ����
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

		// C For Graphics ������ ���� ���� (CGPROGRAM ~ ENDCG)
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
