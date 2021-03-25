using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxTISHdePOTdeMERDA : MonoBehaviour {

    public int numeroDoConsum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.GetComponent<ativaConsum>().definePot(PlayerPrefs.GetString("consum" + numeroDoConsum));
        Destroy(this);
		
	}
}
