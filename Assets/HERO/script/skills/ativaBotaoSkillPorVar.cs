using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativaBotaoSkillPorVar : MonoBehaviour {

    public string nomeDaVar;

	// Use this for initialization
	void Start () {

        if(PlayerPrefs.GetInt(nomeDaVar) == 0)
        {
            transform.GetComponent<Image>().enabled = false;
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
        }
        else
        {
            transform.GetComponent<Image>().enabled = true;
        }
    }
}
