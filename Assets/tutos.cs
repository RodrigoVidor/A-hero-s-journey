using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutos : MonoBehaviour {

    public GameObject tuto0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Application.loadedLevelName == "home")
        {
            if(PlayerPrefs.GetInt("tutosAtivos") == 0)
            {
                ativaTutos();
            }
           
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void ativaTutos()
    {
        tuto0.SetActive(true);

    }
}
