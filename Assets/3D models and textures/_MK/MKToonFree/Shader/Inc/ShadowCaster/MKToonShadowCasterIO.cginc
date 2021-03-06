//shadow input and output
#ifndef MK_TOON_SHADOWCASTER_IO
	#define MK_TOON_SHADOWCASTER_IO

	/////////////////////////////////////////////////////////////////////////////////////////////
	// INPUT
	/////////////////////////////////////////////////////////////////////////////////////////////
	struct VertexInputShadowCaster
	{
		float4 vertex : POSITION;
		//use normals for cubemapped shadows (point lights)
		#ifndef SHADOWS_CUBE
			float3 normal : NORMAL;
		#endif
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};

	/////////////////////////////////////////////////////////////////////////////////////////////
	// OUTPUT
	/////////////////////////////////////////////////////////////////////////////////////////////
	struct VertexOutputShadowCaster
	{	
		float3 sv : TEXCOORD0;
		//enable texcoords for blended shadows (dither)
		UNITY_VERTEX_OUTPUT_STEREO
		UNITY_VERTEX_INPUT_INSTANCE_ID
	};
#endif