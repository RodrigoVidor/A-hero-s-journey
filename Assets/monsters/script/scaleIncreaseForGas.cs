using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleIncreaseForGas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.localScale = Vector3.Slerp(transform.localScale, new Vector3(50, 50, 50), 4 * Time.deltaTime);
		
	}
}
