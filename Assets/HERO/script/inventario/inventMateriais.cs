using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventMateriais : MonoBehaviour {

    public string[] referenciaNomesMateriais;
    public string[] matNoInvent;
    public string[] auxParaVerInvent;
    int auxContInvent;
    float auxPosButtons;
    public GameObject paiDeTodosMateriais, buttonParaMat;
    GameObject auxInstButton;
    public Text textDoButton, textoDoInvent;
   // [TextArea]
  //  public string mostraNoInventPlayer;

    // Use this for initialization
    void Start () {

        matNoInvent = new string[PlayerPrefs.GetInt("numeroDeMateriaisNoInvent")];
        auxParaVerInvent = new string[PlayerPrefs.GetInt("numeroDeMateriaisNoInvent")];
        for (var j = 0; j < referenciaNomesMateriais.Length; j++)
         {
             //print(PlayerPrefs.GetInt(referenciaNomesMateriais[j]));
             if(PlayerPrefs.GetInt(referenciaNomesMateriais[j]) > 0)
             {
                 matNoInvent[auxContInvent] = referenciaNomesMateriais[j];
                 auxParaVerInvent[auxContInvent] = referenciaNomesMateriais[j] + " = " + PlayerPrefs.GetInt(referenciaNomesMateriais[j]).ToString();
                 //mostraNoInventPlayer = mostraNoInventPlayer + auxParaVerInvent[auxContInvent] + "\n" + "\n";
                 auxInstButton = Instantiate(buttonParaMat, paiDeTodosMateriais.transform.position, Quaternion.identity) as GameObject ;
                 auxInstButton.transform.parent = paiDeTodosMateriais.transform;
                 auxInstButton.GetComponentInChildren<Text>().text = auxParaVerInvent[auxContInvent];
                 auxInstButton.GetComponent<auxPosInterface>().auxY += auxPosButtons;
                 auxPosButtons += -0.08f;
                 auxContInvent++;
                 //print("SS");
             }
         }
        //textoDoInvent.text = mostraNoInventPlayer;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ajusteMostraItens ()
    {
        auxContInvent = 0;
        auxPosButtons = 0;
        // mostraNoInventPlayer = null;
        int childs = paiDeTodosMateriais.transform.childCount;
        for (int i = 0; i < childs; i ++)
        {
            Destroy(paiDeTodosMateriais.transform.GetChild(i).gameObject);
        }
        for (var k = 0; k < referenciaNomesMateriais.Length; k++)
        {
            //print(PlayerPrefs.GetInt(referenciaNomesMateriais[j]));
            if (PlayerPrefs.GetInt(referenciaNomesMateriais[k]) > 0)
            {
                matNoInvent[auxContInvent] = referenciaNomesMateriais[k];
                auxParaVerInvent[auxContInvent] = referenciaNomesMateriais[k] + " = " + PlayerPrefs.GetInt(referenciaNomesMateriais[k]).ToString();
                auxInstButton = Instantiate(buttonParaMat, paiDeTodosMateriais.transform.position, Quaternion.identity) as GameObject;
                auxInstButton.transform.parent = paiDeTodosMateriais.transform;
                auxInstButton.GetComponentInChildren<Text>().text = auxParaVerInvent[auxContInvent];
                auxInstButton.GetComponent<auxPosInterface>().auxX = 0.157f;
                auxInstButton.GetComponent<auxPosInterface>().auxY += auxPosButtons;
                auxPosButtons += -0.08f;
                //  mostraNoInventPlayer = mostraNoInventPlayer + auxParaVerInvent[auxContInvent] + "\n" + "\n";
                auxContInvent++;
                //print("SS");
            }
        }
       // textoDoInvent.text = mostraNoInventPlayer;
    }


    public void getMaterialInvent(string nameMat)
    {
        for(var i = 0; i < 1000; i++)
        {
            if(i < matNoInvent.Length)
            {
                if(matNoInvent[i] == nameMat)
                {
                    PlayerPrefs.SetInt(nameMat, PlayerPrefs.GetInt(nameMat) + 1);
                    matNoInvent[i] = nameMat;
                    auxParaVerInvent[i] = nameMat + " = " + PlayerPrefs.GetInt(nameMat).ToString();
                    // mostraNoInventPlayer = mostraNoInventPlayer + auxParaVerInvent[i] + "\n";
                    // textoDoInvent.text = mostraNoInventPlayer;
                    ajusteMostraItens();
                    break;
                }
            }
            else
            {
                matNoInvent = new string[matNoInvent.Length + 1];
                auxParaVerInvent = new string[matNoInvent.Length + 1];
                PlayerPrefs.SetInt(nameMat, PlayerPrefs.GetInt(nameMat) + 1);
                matNoInvent[i] = nameMat;
                auxParaVerInvent[i] = nameMat + " = " + PlayerPrefs.GetInt(nameMat).ToString();
               // mostraNoInventPlayer = auxParaVerInvent[i] + "\n";
               // textoDoInvent.text = mostraNoInventPlayer;
                ajusteMostraItens();
                PlayerPrefs.SetInt("numeroDeMateriaisNoInvent", matNoInvent.Length);
                break;
            }
        }
    }
}
