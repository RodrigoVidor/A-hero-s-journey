using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translateY : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //transform.Translate(Vector3.up * speed * Time.deltaTime);
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 4, 0), speed * Time.deltaTime);
		
	}
}
