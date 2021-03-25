using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillHeroPos : MonoBehaviour {

    Transform hero;

	// Use this for initialization
	void Start () {

        hero = GameObject.FindGameObjectWithTag("hero").transform;
        transform.parent = hero.transform;
    }
	
	// Update is called once per frame
	void Update () {

        



	}
}
