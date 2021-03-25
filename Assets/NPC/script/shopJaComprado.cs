using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopJaComprado : MonoBehaviour {

    public string nomeDoItem;

	// Use this for initialization
	void Start () {
		
        if(PlayerPrefs.GetInt(nomeDoItem) == 1)
        {
            gameObject.SetActive(false);
        }

	}
	
	// Update is called once per frame
	void Update () {

        if (PlayerPrefs.GetInt(nomeDoItem) == 1)
        {
            gameObject.SetActive(false);
        }

    }
}
