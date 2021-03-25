using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstObjQuest : MonoBehaviour {

    public GameObject objQuestFocoSword, objQuestFocoMag;
    public bool lastDestroy;


	// Use this for initialization
	void Start () {

        if(PlayerPrefs.GetInt("foco") == 1)
        {
            Instantiate(objQuestFocoSword, transform.position, Quaternion.identity);
        }
		else if (PlayerPrefs.GetInt("foco") == 2)
        {
            Instantiate(objQuestFocoMag, transform.position, Quaternion.identity);
        }
        if (lastDestroy)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
