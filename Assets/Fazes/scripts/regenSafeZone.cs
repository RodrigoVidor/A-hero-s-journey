using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regenSafeZone : MonoBehaviour {

    Collider box;

    float delay;

	// Use this for initialization
	void Start () {

        box = transform.GetComponent<Collider>();

	}
	
	// Update is called once per frame
	void Update () {

        delay += Time.deltaTime;

        if(delay >= 0.5f)
        {
            box.enabled = true;
        }
		
	}
}
