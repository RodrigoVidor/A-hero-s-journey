using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class textureTranslate : MonoBehaviour {

    public Material mat;
    public Vector2 speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        mat.SetTextureOffset("_MainTex", new Vector2(speed.x * Time.time, speed.y * Time.time));

	}
}
