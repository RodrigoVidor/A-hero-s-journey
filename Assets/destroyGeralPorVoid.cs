using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyGeralPorVoid : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroyGeral(GameObject objParaDestruir)
    {
        Destroy(objParaDestruir);
    }
}
