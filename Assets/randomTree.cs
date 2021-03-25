using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomTree : MonoBehaviour {

    public GameObject obj;
    public int quant, sizeX, sizeZ, altura;

	// Use this for initialization
	void Start () {

        for(int i = 0; i < quant; i++)
        {
            Instantiate(obj, new Vector3(Random.Range(-sizeX, sizeX), altura, Random.Range(-sizeZ, sizeZ)),Quaternion.identity);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
