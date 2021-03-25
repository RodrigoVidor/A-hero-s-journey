using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class questGeral : MonoBehaviour {

    int questAtual, questNumberComplete;
    public Text displayQuestNumber, mainQuestText, activeQuestText, completeQuestText;
    public GameObject questComplete, newQuest, buttonQuest, PaiDeTodasQuest, objParaAttPonteiros;
    public string[] questNames, questCompletaTotal, nameQuestCompletaToral;
    GameObject auxButton;
    float auxPosButtons;
    string nameQuest;
    [TextArea]
    public string mainQuest, questCompletas, questAtivas;
    public Text questNaTela;

    // Use this for initialization
    void Start () {

        auxPosButtons += -0.04f;
        questAtual = PlayerPrefs.GetInt("questAtual");
        mainQuest = PlayerPrefs.GetString("questAtualTexto");
        questNaTela.text = PlayerPrefs.GetString("descricaoResumida");


        questCompletaTotal = new string[PlayerPrefs.GetInt("quantQuestCompletas")];
        nameQuestCompletaToral = new string[PlayerPrefs.GetInt("quantQuestCompletas")];

        for(var t = 0; t < PlayerPrefs.GetInt("quantQuestCompletas"); t ++)
        {
            questCompletaTotal[t] = PlayerPrefs.GetString("questCompletaTotal" + t);
            nameQuestCompletaToral[t] = PlayerPrefs.GetString("nameQuestCompletaToral" + t);
        }
        

        mainQuestText.text = "\n" + mainQuest;

        for(var o = 0; o < PlayerPrefs.GetInt("quantQuestCompletas"); o ++)
        {
            auxButton = Instantiate(buttonQuest, PaiDeTodasQuest.transform.position, Quaternion.identity) as GameObject;
            auxButton.transform.parent = PaiDeTodasQuest.transform;
            auxButton.GetComponentInChildren<Text>().text = nameQuestCompletaToral[o];
            auxButton.GetComponent<descButtonQuest>().descQuest = questCompletaTotal[o];
            auxButton.GetComponent<auxPosInterface>().auxY += auxPosButtons;
            auxPosButtons += -0.09f;
        }

        /*
        questAtual = PlayerPrefs.GetInt("questAtual");
        questNumberComplete = PlayerPrefs.GetInt("lastQuest");
        //questAtual = 3;
        
        if (questAtual == 1000)
        {
            for (var i = 0; i < questNumberComplete + 1; i++)
            {
                questCompletas = questCompletas + "\n" + questNames[i] + "\n";
            }
            displayQuestNumber.text = "N";
        }
        else
        {
            for (var i = 0; i < questAtual; i++)
            {
                questCompletas = questCompletas + "\n" + questNames[i] + "\n";
            }
            displayQuestNumber.text = questAtual.ToString();
        }
        completeQuestText.text = questCompletas;
        if (questNames.Length > questAtual)
        {
            mainQuestText.text = "\n" + questNames[questAtual];
        }
        else if(questAtual == 1000)
        {
            mainQuestText.text = "\n" + "Nothing to do right now!";
        }
        */
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void questCompleta()
    {
        //questCompletaTotal[1] = questName;
        auxButton = Instantiate(buttonQuest, PaiDeTodasQuest.transform.position, Quaternion.identity) as GameObject;
        auxButton.transform.parent = PaiDeTodasQuest.transform;
        auxButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetString("questAtualTextoName");
        auxButton.GetComponent<descButtonQuest>().descQuest = mainQuest;
        auxButton.GetComponent<auxPosInterface>().auxX = 0.2f;
        auxButton.GetComponent<auxPosInterface>().auxY += auxPosButtons;
        auxPosButtons += -0.09f;


        // questCompletas = questCompletas + "\n" + questNames[questAtual] + "\n";
        // completeQuestText.text = questCompletas;

        questCompletaTotal = new string[questCompletaTotal.Length + 1];
        nameQuestCompletaToral = new string[nameQuestCompletaToral.Length + 1];
        questCompletaTotal[PlayerPrefs.GetInt("quantQuestCompletas")] = mainQuest;
        nameQuestCompletaToral[PlayerPrefs.GetInt("quantQuestCompletas")] = PlayerPrefs.GetString("questAtualTextoName");
        PlayerPrefs.SetString("questCompletaTotal" + PlayerPrefs.GetInt("quantQuestCompletas"), mainQuest);
        PlayerPrefs.SetString("nameQuestCompletaToral" + PlayerPrefs.GetInt("quantQuestCompletas"), PlayerPrefs.GetString("questAtualTextoName"));
        mainQuest = "\n" + "Nothing to do right now!";
        mainQuestText.text = mainQuest;
        PlayerPrefs.SetString("questAtualTexto", mainQuest);
        PlayerPrefs.SetInt("quantQuestCompletas", PlayerPrefs.GetInt("quantQuestCompletas") + 1);


        //PlayerPrefs.SetInt("lastQuest", questAtual);
        //PlayerPrefs.SetInt("questAtual", 1000);
        // displayQuestNumber.text = "N";
        Instantiate(questComplete, transform.position, transform.rotation);

        for(int ff = 0; ff < objParaAttPonteiros.GetComponents<alteraPorQuest>().Length; ff ++)
        {
            objParaAttPonteiros.GetComponents<alteraPorQuest>()[ff].atualiza();
        }
    }

    /*public void nextQuest ()
    {
        questCompletas = questCompletas + "\n" + questNames[questAtual] + "\n";
        completeQuestText.text = questCompletas;

        PlayerPrefs.SetInt("lastQuest", questAtual);
        questAtual = PlayerPrefs.GetInt("lastQuest") + 1;
        PlayerPrefs.SetInt("questAtual", questAtual);
        displayQuestNumber.text = questAtual.ToString();
        Instantiate(newQuest, transform.position, transform.rotation);
        mainQuest = questNames[questAtual];
        mainQuestText.text = "\n" + mainQuest;
    }*/

    public void nextQuestNew(string nomeQuest, string descricao, string descricaoResumida)
    {
        Instantiate(newQuest, transform.position, transform.rotation);
        mainQuest = "-> " + nomeQuest + " <- \n \n" + descricao + "\n \n \n" + mainQuest;
        mainQuestText.text = "\n" + mainQuest;
        PlayerPrefs.SetString("questAtualTexto", mainQuest);
        PlayerPrefs.SetString("questAtualTextoName", nomeQuest);
        PlayerPrefs.SetString("descricaoResumida", descricaoResumida);

        questNaTela.text = "-> " + descricaoResumida + " <-";

        for (int jj = 0; jj < objParaAttPonteiros.GetComponents<alteraPorQuest>().Length; jj++)
        {
            objParaAttPonteiros.GetComponents<alteraPorQuest>()[jj].atualiza();
        }
    }

    public void abas(GameObject aba)
    {
        aba.transform.SetSiblingIndex(8);
    }

}
