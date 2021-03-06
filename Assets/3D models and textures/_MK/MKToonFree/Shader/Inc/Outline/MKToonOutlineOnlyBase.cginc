//base include for outline
#ifndef MK_TOON_OUTLINE_ONLY_BASE
	#define MK_TOON_OUTLINE_ONLY_BASE
	/////////////////////////////////////////////////////////////////////////////////////////////
	// VERTEX SHADER
	/////////////////////////////////////////////////////////////////////////////////////////////
	VertexOutputOutlineOnly outlinevert(VertexInputOutlineOnly v)
	{
		VertexOutputOutlineOnly o;
		UNITY_INITIALIZE_OUTPUT(VertexOutputOutlineOnly, o);
		v.vertex.xyz += normalize(v.normal) * _OutlineSize;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.color = _OutlineColor;
		UNITY_TRANSFER_FOG(o,o.pos);
		return o;
	}

	/////////////////////////////////////////////////////////////////////////////////////////////
	// FRAGMENT SHADER
	/////////////////////////////////////////////////////////////////////////////////////////////
	fixed4 outlinefrag(VertexOutputOutlineOnly o) : SV_Target
	{
		UNITY_APPLY_FOG(o.fogCoord, o.color);
		return o.color;
	}
#endif