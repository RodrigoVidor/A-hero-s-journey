using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoAtkHero : MonoBehaviour {

    public float dano, baseDano;
    public GameObject efeito;

	// Use this for initialization
	void Start () {

        dano = heroBase.strAuxBasicAtk * baseDano;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
