using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativaTutos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        GameObject.FindGameObjectWithTag("controles").transform.Find("Tutos").Find("TutoMenu").gameObject.SetActive(true);
        Destroy(gameObject);
	}
}
