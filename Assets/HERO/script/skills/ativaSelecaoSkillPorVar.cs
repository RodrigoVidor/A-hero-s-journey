using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativaSelecaoSkillPorVar : MonoBehaviour {

    public string nomeDaVar;

    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.GetInt(nomeDaVar) == 0)
        {
            transform.GetComponent<Image>().enabled = false;
            transform.GetComponent<BoxCollider>().enabled = false;
        }
    }

        // Update is called once per frame
    void Update () {

		
	}

    public void atualizaButton()
    {
        if (PlayerPrefs.GetInt(nomeDaVar) == 0)
        {
            transform.GetComponent<Image>().enabled = false;
            transform.GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            transform.GetComponent<Image>().enabled = true;
            transform.GetComponent<BoxCollider>().enabled = true;
        }
    }
}
