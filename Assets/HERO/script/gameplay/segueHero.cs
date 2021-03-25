using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class segueHero : MonoBehaviour {

    GameObject hero;

	// Use this for initialization
	void Start () {

        hero = GameObject.FindGameObjectWithTag("hero");

	}
	
	// Update is called once per frame
	void Update () {

        transform.position = hero.transform.position;

	}
}
