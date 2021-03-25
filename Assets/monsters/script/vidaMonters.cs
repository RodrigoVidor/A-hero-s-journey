using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaMonters : MonoBehaviour {

    GameObject cameraMain;

	// Use this for initialization
	void Start () {

        cameraMain = GameObject.FindGameObjectWithTag("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.rotation = cameraMain.transform.rotation;

	}

    
}
