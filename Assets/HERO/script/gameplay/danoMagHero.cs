using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoMagHero : MonoBehaviour {

    public float dano, baseDano;
    public GameObject efeito;
	// Use this for initialization
	void Start () {

        dano = heroBase.magAuxBasicAtk * baseDano;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
