using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atualizaStatusUpLvl : MonoBehaviour {

    public GameObject heroBase;
    public Text pontosTotais, strBse, vitBase, magBase;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onInstant ()
    {
        pontosTotais.text = PlayerPrefs.GetInt("statusPoints").ToString();

        strBse.text = PlayerPrefs.GetInt("baseStr").ToString();
        vitBase.text = PlayerPrefs.GetInt("baseVit").ToString();
        magBase.text = PlayerPrefs.GetInt("baseMag").ToString();
        if(PlayerPrefs.GetInt("statusPoints") == 0)
        {
            heroBase.GetComponent<heroBase>().auxAlteraStatus();
            gameObject.SetActive(false);
        }
    } 
}
