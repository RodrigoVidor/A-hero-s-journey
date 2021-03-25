using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropGeral : MonoBehaviour {

    public int quant;
    public GameObject efeito, auxPos;
    public bool porcentagem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void instEfeito ()
    {
        Instantiate(efeito, auxPos.transform.position, Quaternion.identity);
    }

}
