using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startAtHeroPos : MonoBehaviour {

	// Use this for initialization
	void Start () {

        transform.position = GameObject.FindGameObjectWithTag("hero").transform.position;
       
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
