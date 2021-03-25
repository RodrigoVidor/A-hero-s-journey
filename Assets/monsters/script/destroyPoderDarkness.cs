using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPoderDarkness : MonoBehaviour {

    public GameObject boss;
    public float delayDestroy;
    float delay;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        delay += Time.deltaTime;

        if(delay > delayDestroy)
        {
            retornaVar();
        }

	}

    public void retornaVar()
    {
        boss.GetComponent<darknessBoss>().algumPoderAtivado = false;
        Destroy(gameObject);
    }
}
