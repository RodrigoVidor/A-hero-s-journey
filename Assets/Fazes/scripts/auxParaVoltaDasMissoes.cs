using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxParaVoltaDasMissoes : MonoBehaviour {

    public string nomeDaVolta;
    public static int quantParaVoltar;
    int quant;
    public GameObject posParaVoltar, trocaScene;
    //GameObject aux;

    public enum state
    {
        ativaTeleportVillage
    }

    public state recompensa;

	// Use this for initialization
	void Start () {

        quant = transform.GetComponent<spawnRandom>().numeroMontros;
		
	}
	
	// Update is called once per frame
	void Update () {

        if(quantParaVoltar == quant)
        {
            Invoke(recompensa.ToString(), 0);
            trocaScene.SetActive(true);
            //aux = Instantiate(trocaScene, posParaVoltar.transform.position, Quaternion.identity) as GameObject;
           // aux.GetComponent<trocascene>().saida = 999;
            //aux.GetComponent<trocascene>().scene = nomeDaVolta;
            quantParaVoltar = 0;
        }
		
	}

    public void ativaTeleportVillage()
    {
        PlayerPrefs.SetInt("teleportVillage", 1);
        PlayerPrefs.SetInt("contTP", PlayerPrefs.GetInt("contTP") + 1);
        PlayerPrefs.SetString("nomeProxTP" + PlayerPrefs.GetInt("contTP"), "village");
    }
}
