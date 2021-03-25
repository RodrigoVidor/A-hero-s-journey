using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstAposDelay : MonoBehaviour {

    public GameObject objParaInst, pos;
    public float delay;
    float delayAux;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        delayAux += Time.deltaTime;

        if(delayAux > delay)
        {
            Instantiate(objParaInst, pos.transform.position, objParaInst.transform.rotation);
            Destroy(this);
        }
		
	}
}
