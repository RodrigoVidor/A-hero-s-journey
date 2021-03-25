using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyGeral : MonoBehaviour {

    public float delay;

    float delayCont;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        delayCont += Time.deltaTime;

        if(delayCont >= delay)
        {
            Destroy(gameObject);
        }

	}
}
