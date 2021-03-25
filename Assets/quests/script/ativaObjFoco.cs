using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativaObjFoco : MonoBehaviour {

    public GameObject objQuestFocoSword, objQuestFocoMag;


    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.GetInt("foco") == 1)
        {
            objQuestFocoSword.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("foco") == 2)
        {
            objQuestFocoMag.SetActive(true);
        }
        Destroy(this);
    }

        // Update is called once per frame
        void Update () {
		
	}
}
