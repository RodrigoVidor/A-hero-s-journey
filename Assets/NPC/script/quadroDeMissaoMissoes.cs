using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quadroDeMissaoMissoes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void mission (string nome)
    {
        Application.LoadLevel(nome);
    }

    public void quitQuadro ()
    {
        Destroy(gameObject);
    }
}
