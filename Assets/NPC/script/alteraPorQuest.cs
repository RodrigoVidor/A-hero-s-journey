using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alteraPorQuest : MonoBehaviour {

    public bool ativoInt, ativoString;
    public int numeroDaQuestParaMudanca;
    public string ouNomeQuest;
    public GameObject[] objParaAtivar, objParaDesativar;

    // Use this for initialization
    void Start()
    {
        if (ativoInt != ativoString)
        {
            if (ativoInt)
            {
                if (numeroDaQuestParaMudanca == PlayerPrefs.GetInt("quantQuestCompletas"))
                {
                    for (var i = 0; i < objParaAtivar.Length; i++)
                    {
                        objParaAtivar[i].SetActive(true);
                    }
                    for (var j = 0; j < objParaDesativar.Length; j++)
                    {
                        objParaDesativar[j].SetActive(false);
                    }
                }
            }
            else if (ativoString)
            {
                if (PlayerPrefs.GetInt(ouNomeQuest) == 1)
                {
                    for (var i = 0; i < objParaAtivar.Length; i++)
                    {
                        objParaAtivar[i].SetActive(true);
                    }
                    for (var j = 0; j < objParaDesativar.Length; j++)
                    {
                        objParaDesativar[j].SetActive(false);
                    }
                }
            }
        }
        else
        {

            if (numeroDaQuestParaMudanca == PlayerPrefs.GetInt("quantQuestCompletas") && PlayerPrefs.GetInt(ouNomeQuest) == 1)
            {
                for (var i = 0; i < objParaAtivar.Length; i++)
                {
                    objParaAtivar[i].SetActive(true);
                }
                for (var j = 0; j < objParaDesativar.Length; j++)
                {
                    objParaDesativar[j].SetActive(false);
                }
            }
            
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void atualiza () {

        if (ativoInt != ativoString)
        {
            if (ativoInt)
            {
                if (numeroDaQuestParaMudanca == PlayerPrefs.GetInt("quantQuestCompletas"))
                {
                    for (var i = 0; i < objParaAtivar.Length; i++)
                    {
                        objParaAtivar[i].SetActive(true);
                    }
                    for (var j = 0; j < objParaDesativar.Length; j++)
                    {
                        objParaDesativar[j].SetActive(false);
                    }
                }
            }
            else if (ativoString)
            {
                // print(ouNomeQuest);
                //print(PlayerPrefs.GetInt(ouNomeQuest));
                if (PlayerPrefs.GetInt(ouNomeQuest) == 1)
                {
                    for (var i = 0; i < objParaAtivar.Length; i++)
                    {
                        objParaAtivar[i].SetActive(true);
                    }
                    for (var j = 0; j < objParaDesativar.Length; j++)
                    {
                        objParaDesativar[j].SetActive(false);
                    }
                }
            }
        }
        else
        {

            if (numeroDaQuestParaMudanca == PlayerPrefs.GetInt("quantQuestCompletas") && PlayerPrefs.GetInt(ouNomeQuest) == 1)
            {
                for (var i = 0; i < objParaAtivar.Length; i++)
                {
                    objParaAtivar[i].SetActive(true);
                }
                for (var j = 0; j < objParaDesativar.Length; j++)
                {
                    objParaDesativar[j].SetActive(false);
                }
            }

        }

    }
}
