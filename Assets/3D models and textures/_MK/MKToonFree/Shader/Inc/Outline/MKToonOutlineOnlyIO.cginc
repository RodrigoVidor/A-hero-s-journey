//Vertexshader Input and Output
#ifndef MK_TOON_OUTLINE_ONLY_IO
	#define MK_TOON_OUTLINE_ONLY_IO
	/////////////////////////////////////////////////////////////////////////////////////////////
	// INPUT
	/////////////////////////////////////////////////////////////////////////////////////////////
	struct VertexInputOutlineOnly
	{
		float4 vertex : POSITION;
		half3 normal : NORMAL;
	};

	/////////////////////////////////////////////////////////////////////////////////////////////
	// OUTPUT
	/////////////////////////////////////////////////////////////////////////////////////////////
	struct VertexOutputOutlineOnly
	{
		float4 pos : SV_POSITION;
		fixed4 color : COLOR;
		UNITY_FOG_COORDS(0)
	};
#endif