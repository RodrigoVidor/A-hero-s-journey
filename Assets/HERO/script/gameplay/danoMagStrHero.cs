using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoMagStrHero : MonoBehaviour {

    public float dano, baseDanoStr, baseDanoMag;
    public GameObject efeito;

	// Use this for initialization
	void Start () {

        dano = (heroBase.strAuxBasicAtk * baseDanoStr) + (heroBase.magAuxBasicAtk * baseDanoMag);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
