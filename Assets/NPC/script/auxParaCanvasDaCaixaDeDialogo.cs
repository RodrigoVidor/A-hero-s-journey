using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxParaCanvasDaCaixaDeDialogo : MonoBehaviour {

    GameObject auxObj;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void recebeObj(GameObject pai)
    {
        auxObj = pai;
    }

    public void eventoAceito ()
    {
        auxObj.GetComponent<objOut>().eventoAceito(gameObject);
    }

    public void eventoNaoAceito()
    {
        auxObj.GetComponent<objOut>().eventoNaoAceito(gameObject);
    }

    public void eventoGeral()
    {
        Destroy(gameObject);
    }

}
