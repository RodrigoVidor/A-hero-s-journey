using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateLocal : MonoBehaviour {

    public float speed;
    //public float dragX, dragY, dragZ;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
}
