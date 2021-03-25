using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criaCaixa : MonoBehaviour {

    GameObject auxCaixaDialogo;
    public int[] ifCaixa;
    public GameObject[] caixaDeDialogo;
    public string[] nomeDaVar;

    // Use this for initialization
    void Start () {

        for (var i = 0; i < ifCaixa.Length; i++)
        {
            if (ifCaixa[i] == PlayerPrefs.GetInt("questNumber"))
            {
                if (PlayerPrefs.GetInt(nomeDaVar[i]) == 0)
                {
                    auxCaixaDialogo = Instantiate(caixaDeDialogo[i], transform.position, transform.rotation) as GameObject;
                    PlayerPrefs.SetInt(nomeDaVar[i], 1);
                }
                // auxCaixaDialogo.GetComponentInChildren<Text>().text = textoCaixa[i];
            }
        }
        if (PlayerPrefs.GetInt("INIT") == 0)
        {
            Instantiate(caixaDeDialogo[0], transform.position, transform.rotation);
            PlayerPrefs.SetInt("INIT", 1);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
