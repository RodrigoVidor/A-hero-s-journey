using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventWeapons : MonoBehaviour {

    public GameObject[] armas;
    public GameObject[] armaduras;
    public GameObject[] botas;
    public GameObject[] capas;
    public GameObject[] itens;
    public GameObject[] consum;
    public GameObject[] questItens;
    public GameObject noItem;
    public string[] nomeDasArmas;
    public Image[] imagemArmas;
    //public string[] nomeDasArmasAux;
    public GameObject[] auxObjGame;
    //public int[] quantAux;
    public GameObject paiDeTodosMateriais, buttons;
    public int slotVazios;
    GameObject auxButtons;
    int auxContInvent, auxContLinha, auxPosItens, r;
    Vector2 auxPosButtonOnDestroy;
    float auxPosButtonsX, auxPosButtonsY;
   // public Text textDoButton, textoDoInvent;
    public Image spriteWeapon;
    public Vector2[] posButtons;
    public GameObject[] consums;


    // Use this for initialization
    void Start () {

        //nomeDasArmas = new string[PlayerPrefs.GetInt("tamanhoDaListaDeArmas")];
        // quant = new int[PlayerPrefs.GetInt("tamanhoDaListaDeArmas")];
        //  nomeDasArmasAux = new string[PlayerPrefs.GetInt("tamanhoDaListaDeArmas")];
        //  quantAux = new int[PlayerPrefs.GetInt("listaDasArmasQuant")];
        // if (PlayerPrefs.GetInt("tamanhoDaListaDeArmas") != 0) 
        // {
        // for (var i = 0; i <= PlayerPrefs.GetInt("tamanhoDaListaDeArmas"); i++)
        for (var i = 0; i < 30; i++)
        {
            nomeDasArmas[i] = PlayerPrefs.GetString("listaDasArmas" + i);
            if (PlayerPrefs.GetString("listaDasArmas" + i) == "")
            {
                PlayerPrefs.SetString("listaDasArmas" + i, "emptySlot");
                nomeDasArmas[i] = "emptySlot";
                //print(PlayerPrefs.GetString("listaDasArmas" + i));
            }
            //     nomeDasArmasAux = nomeDasArmas;
            //quant[i] = PlayerPrefs.GetInt("listaDasArmasQuant" + nomeDasArmas[i]);
            //     quantAux = quant;
            auxButtons = Instantiate(buttons, paiDeTodosMateriais.transform.position, Quaternion.identity) as GameObject;
            auxButtons.transform.parent = paiDeTodosMateriais.transform;
            auxButtons.GetComponent<dragWeapon>().posDoButtonNoInvent = auxContInvent;
            auxButtons.GetComponent<dragWeapon>().hero = gameObject;
            auxObjGame[i] = auxButtons;

            auxButtons.GetComponent<auxPosInterface>().auxX += posButtons[i].x;
            auxButtons.GetComponent<auxPosInterface>().auxY += posButtons[i].y;

            //auxButtons.GetComponentInChildren<Text>().text = "\n    " + nomeDasArmas[i] + " = " + quant[i];
            if (nomeDasArmas[i] == "emptySlot")
            {
                auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = noItem.GetComponent<spriteWeapon>().spriteDessaArma;
                auxButtons.transform.Find("spriteArma").GetComponent<Image>().color = Color.clear;
                //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = noItem.GetComponent<spriteWeapon>().spriteButton;
                auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = noItem.GetComponent<spriteWeapon>().spriteDessaArma;
                auxButtons.GetComponent<auxImagenWeapon>().nomeItem = noItem.GetComponent<spriteWeapon>().nomeItem;
                auxButtons.GetComponent<auxImagenWeapon>().descricao = noItem.GetComponent<spriteWeapon>().descricao;
                auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                auxButtons.GetComponent<Image>().color = Color.clear;
                auxPosItens++;
                slotVazios++;

                //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];

                if (auxContLinha == 6)
                {
                    auxPosButtonsY += 0.103f;
                    auxPosButtonsX = 0;
                    auxContLinha = 0;
                }
                // auxButtons.GetComponent<dragWeapon>().auxParaPosInventInit = new Vector2(auxPosButtonsX, -auxPosButtonsY);
                //  auxButtons.GetComponent<dragWeapon>().auxParaPosInventFinal = new Vector2(auxPosButtonsX, -auxPosButtonsY);
                // auxButtons.GetComponent<auxPosInterface>().auxX += auxPosButtonsX;
                // auxButtons.GetComponent<auxPosInterface>().auxY += -auxPosButtonsY;

                auxButtons.GetComponent<dragWeapon>().nomeDoItem = "emptySlot";
                auxPosButtonsX += 0.063f;
                auxContInvent++;
                auxContLinha++;
            }
            else
            {
                for (var t = 0; t < nomeDasArmas.Length; t++)/// pode dar problema com o numero de armas maior q slots
                {
                    if (t < armas.Length)
                    {
                        if (armas[t].name == nomeDasArmas[i])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = armas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = armas[t].GetComponent<spriteWeapon>().questItem;
                            //auxButtons.transform.GetChild(1).tag = "WEAPON";
                            auxButtons.GetComponent<Image>().color = Color.yellow;
                            auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = armas[t];
                            auxPosItens++;
                            break;
                        }
                    }
                    if (t < armaduras.Length)
                    {
                        if (armaduras[t].name == nomeDasArmas[i])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = armaduras[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = armaduras[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = armaduras[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().nomeItem = armaduras[t].GetComponent<spriteWeapon>().nomeItem;
                            auxButtons.GetComponent<auxImagenWeapon>().descricao = armaduras[t].GetComponent<spriteWeapon>().descricao;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = armaduras[t].GetComponent<spriteWeapon>().questItem;
                            auxButtons.transform.GetChild(1).tag = "ARMOR";
                            auxButtons.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                            auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = armaduras[t];
                            auxPosItens++;
                            break;
                        }
                    }
                    if (t < capas.Length)
                    {
                        if (capas[t].name == nomeDasArmas[i])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = capas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = capas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = capas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().nomeItem = capas[t].GetComponent<spriteWeapon>().nomeItem;
                            auxButtons.GetComponent<auxImagenWeapon>().descricao = capas[t].GetComponent<spriteWeapon>().descricao;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = capas[t].GetComponent<spriteWeapon>().questItem;
                            auxButtons.transform.GetChild(1).tag = "HELM";
                            auxButtons.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                            auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = capas[t];
                            auxPosItens++;
                            break;
                        }
                    }

                    if (t < botas.Length)
                    {
                        if (botas[t].name == nomeDasArmas[i])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = botas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = botas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = botas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().nomeItem = botas[t].GetComponent<spriteWeapon>().nomeItem;
                            auxButtons.GetComponent<auxImagenWeapon>().descricao = botas[t].GetComponent<spriteWeapon>().descricao;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = botas[t].GetComponent<spriteWeapon>().questItem;
                            auxButtons.transform.GetChild(1).tag = "BOOTS";
                            auxButtons.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                            auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = botas[t];
                            auxPosItens++;
                            break;
                        }
                    }
                    if (t < itens.Length)
                    {
                        if (itens[t].name == nomeDasArmas[i])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = itens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = itens[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = itens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().nomeItem = itens[t].GetComponent<spriteWeapon>().nomeItem;
                            auxButtons.GetComponent<auxImagenWeapon>().descricao = itens[t].GetComponent<spriteWeapon>().descricao;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = itens[t].GetComponent<spriteWeapon>().questItem;
                            auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                            auxButtons.GetComponent<Image>().color = Color.green;
                            auxPosItens++;
                            //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];
                            break;
                        }
                    }
                    if (t < consum.Length)
                    {
                        if (consum[t].name == nomeDasArmas[i])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = consum[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = consum[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = consum[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().nomeItem = consum[t].GetComponent<spriteWeapon>().nomeItem;
                            auxButtons.GetComponent<auxImagenWeapon>().descricao = consum[t].GetComponent<spriteWeapon>().descricao;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = consum[t].GetComponent<spriteWeapon>().questItem;
                            auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                            auxButtons.GetComponent<Image>().color = Color.red;
                            auxButtons.GetComponentInChildren<Transform>().tag = "POT";
                            auxPosItens++;
                            //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];
                            break;
                        }
                    }
                    if (t < questItens.Length)
                    {
                        if (questItens[t].name == nomeDasArmas[i])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = questItens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = questItens[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = questItens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().nomeItem = questItens[t].GetComponent<spriteWeapon>().nomeItem;
                            auxButtons.GetComponent<auxImagenWeapon>().descricao = questItens[t].GetComponent<spriteWeapon>().descricao;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = questItens[t].GetComponent<spriteWeapon>().questItem;
                            auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                            auxButtons.GetComponent<Image>().color = Color.blue;
                            auxPosItens++;
                            //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];
                            break;
                        }
                    }
                }
                if (auxContLinha == 6)
                {
                    auxPosButtonsY += 0.103f;
                    auxPosButtonsX = 0;
                    auxContLinha = 0;
                }
                //auxButtons.GetComponent<dragWeapon>().auxParaPosInventInit = new Vector2(auxPosButtonsX, -auxPosButtonsY);
                //auxButtons.GetComponent<dragWeapon>().auxParaPosInventFinal = new Vector2(auxPosButtonsX, -auxPosButtonsY);
                 auxButtons.GetComponent<dragWeapon>().nomeDoItem = nomeDasArmas[i];
                //auxButtons.GetComponent<auxPosInterface>().auxX += auxPosButtonsX;
                // auxButtons.GetComponent<auxPosInterface>().auxY += -auxPosButtonsY;
                auxPosButtonsX += 0.063f;
                auxContInvent++;
                auxContLinha++;
            }
        }
        // }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

   

    public void ajusteWeapons()
    {
        auxContInvent = 0;
        auxPosButtonsX = 0;
        auxPosButtonsY = 0;
        auxContLinha = 0;
        int childs = paiDeTodosMateriais.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            Destroy(paiDeTodosMateriais.transform.GetChild(i).gameObject);
        }
        for (var p = 0; p < 1000; p++)
        {
            if (p < nomeDasArmas.Length)
            {
                nomeDasArmas[p] = PlayerPrefs.GetString("listaDasArmas" + p);
               // quant[p] = PlayerPrefs.GetInt("listaDasArmasQuant" + nomeDasArmas[p]);
                auxButtons = Instantiate(buttons, paiDeTodosMateriais.transform.position, Quaternion.identity) as GameObject;
                auxButtons.transform.parent = paiDeTodosMateriais.transform;
                for (var t = 0; t < armas.Length; t++)
                {
                    if (t < armas.Length)
                    {
                        if (armas[t].name == nomeDasArmas[p])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //  auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = armas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = armas[t].GetComponent<spriteWeapon>().questItem;
                            // auxButtons.transform.GetChild(1).tag = "WEAPON";
                            auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = armas[t];
                            auxButtons.GetComponent<Image>().color = Color.yellow;
                            break;
                        }
                    }
                    if (t < itens.Length)
                    {
                        if (itens[t].name == nomeDasArmas[p])
                        {
                            //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = itens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            //  auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = itens[t].GetComponent<spriteWeapon>().spriteButton;
                            auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = itens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                            auxButtons.GetComponent<auxImagenWeapon>().nomeItem = itens[t].GetComponent<spriteWeapon>().nomeItem;
                            auxButtons.GetComponent<auxImagenWeapon>().descricao = itens[t].GetComponent<spriteWeapon>().descricao;
                            auxButtons.GetComponent<auxImagenWeapon>().questItem = itens[t].GetComponent<spriteWeapon>().questItem;
                            auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                            //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];
                            auxButtons.GetComponent<Image>().color = Color.green;
                            break;
                        }
                    }
                }
                // auxButtons.GetComponentInChildren<Text>().text = "\n    " + nomeDasArmas[p] + " = " + quant[p];
                if (auxContLinha == 6)
                {
                    auxPosButtonsY += 0.103f;
                    auxPosButtonsX = 0;
                    auxContLinha = 0;
                }
                auxButtons.GetComponent<auxPosInterface>().auxX += auxPosButtonsX;
                auxButtons.GetComponent<auxPosInterface>().auxY += -auxPosButtonsY;
                auxPosButtonsX += 0.063f;
                auxContInvent++;
                auxContLinha++;
            }
        }
    }

    public void ajusteWeaponsNew()
    {
        
        Destroy(auxObjGame[r]);
        //print(r);
        //print(auxPosButtonOnDestroy);
        auxButtons = Instantiate(buttons, paiDeTodosMateriais.transform.position, Quaternion.identity) as GameObject;
        auxButtons.GetComponent<dragWeapon>().hero = gameObject;
        auxButtons.GetComponent<dragWeapon>().posDoButtonNoInvent = r;
        auxButtons.GetComponent<dragWeapon>().nomeDoItem = nomeDasArmas[r];
        auxObjGame[r] = auxButtons;
        auxButtons.transform.parent = paiDeTodosMateriais.transform;
        auxButtons.GetComponent<auxPosInterface>().auxX += posButtons[r].x;
        auxButtons.GetComponent<auxPosInterface>().auxY += posButtons[r].y;
        for (var t = 0; t < nomeDasArmas.Length; t++)
        {
            if (nomeDasArmas[r] == "emptySlot")
            {
                auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = noItem.GetComponent<spriteWeapon>().spriteDessaArma;
                auxButtons.transform.Find("spriteArma").GetComponent<Image>().color = Color.clear;
                //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = noItem.GetComponent<spriteWeapon>().spriteButton;
                auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = noItem.GetComponent<spriteWeapon>().spriteDessaArma;
                auxButtons.GetComponent<auxImagenWeapon>().nomeItem = noItem.GetComponent<spriteWeapon>().nomeItem;
                auxButtons.GetComponent<auxImagenWeapon>().descricao = noItem.GetComponent<spriteWeapon>().descricao;
                auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                auxButtons.GetComponent<Image>().color = Color.clear;
                auxPosItens++;
                slotVazios++;

                // auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                // auxButtons.GetComponent<Image>().color = Color.clear;
                

                break;
            }
            else
            {
                if (t < armas.Length)
                {
                    //if (armas[t].name == nomeDasArmas[nomeDasArmas.Length - 1])
                    if (armas[t].name == nomeDasArmas[r])
                    {
                        //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        //  auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = armas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        auxButtons.GetComponent<auxImagenWeapon>().questItem = armas[t].GetComponent<spriteWeapon>().questItem;
                        auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = armas[t];
                        //auxButtons.transform.GetChild(1).tag = "WEAPON";
                        auxButtons.GetComponent<Image>().color = Color.yellow;

                        //  auxPosButtonsX += 0.063f;
                        //  auxContInvent++;
                        // auxContLinha++;
                        //  auxPosItens++;
                        break;
                    }
                }
                if (t < armaduras.Length)
                {
                    if (armaduras[t].name == nomeDasArmas[r])
                    {
                        //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = armaduras[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = armaduras[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = armaduras[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        auxButtons.GetComponent<auxImagenWeapon>().nomeItem = armaduras[t].GetComponent<spriteWeapon>().nomeItem;
                        auxButtons.GetComponent<auxImagenWeapon>().descricao = armaduras[t].GetComponent<spriteWeapon>().descricao;
                        auxButtons.GetComponent<auxImagenWeapon>().questItem = armaduras[t].GetComponent<spriteWeapon>().questItem;
                        auxButtons.transform.GetChild(1).tag = "ARMOR";
                        auxButtons.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                        auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = armaduras[t];
                        //auxPosItens++;
                        break;
                    }
                }
                if (t < capas.Length)
                {
                    if (capas[t].name == nomeDasArmas[r])
                    {
                        //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = capas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = capas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = capas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        auxButtons.GetComponent<auxImagenWeapon>().nomeItem = capas[t].GetComponent<spriteWeapon>().nomeItem;
                        auxButtons.GetComponent<auxImagenWeapon>().descricao = capas[t].GetComponent<spriteWeapon>().descricao;
                        auxButtons.GetComponent<auxImagenWeapon>().questItem = capas[t].GetComponent<spriteWeapon>().questItem;
                        auxButtons.transform.GetChild(1).tag = "HELM";
                        auxButtons.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                        auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = capas[t];
                        //auxPosItens++;
                        break;
                    }
                }

                if (t < botas.Length)
                {
                    if (botas[t].name == nomeDasArmas[r])
                    {
                        //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = botas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = botas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = botas[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        auxButtons.GetComponent<auxImagenWeapon>().nomeItem = botas[t].GetComponent<spriteWeapon>().nomeItem;
                        auxButtons.GetComponent<auxImagenWeapon>().descricao = botas[t].GetComponent<spriteWeapon>().descricao;
                        auxButtons.GetComponent<auxImagenWeapon>().questItem = botas[t].GetComponent<spriteWeapon>().questItem;
                        auxButtons.transform.GetChild(1).tag = "BOOTS";
                        auxButtons.GetComponent<Image>().color = new Color(1, 0.5f, 0, 1);
                        auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = botas[t];
                        //auxPosItens++;
                        break;
                    }
                }
                if (t < itens.Length)
                {
                    //print(itens[t].name);
                    //if (itens[t].name == nomeDasArmas[nomeDasArmas.Length - 1])
                    if (itens[t].name == nomeDasArmas[r])
                    {
                        //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = itens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        //  auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = itens[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = itens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        auxButtons.GetComponent<auxImagenWeapon>().nomeItem = itens[t].GetComponent<spriteWeapon>().nomeItem;
                        auxButtons.GetComponent<auxImagenWeapon>().descricao = itens[t].GetComponent<spriteWeapon>().descricao;
                        auxButtons.GetComponent<auxImagenWeapon>().questItem = itens[t].GetComponent<spriteWeapon>().questItem;
                        auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                        //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];
                        auxButtons.GetComponent<Image>().color = Color.green;

                        // auxPosButtonsX += 0.063f;
                        // auxContInvent++;
                        // auxContLinha++;
                        // auxPosItens++;
                        break;
                    }
                }
                if (t < consum.Length)
                {
                    if (consum[t].name == nomeDasArmas[r])
                    {
                        //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = consum[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        //  auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = consum[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = consum[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        auxButtons.GetComponent<auxImagenWeapon>().nomeItem = consum[t].GetComponent<spriteWeapon>().nomeItem;
                        auxButtons.GetComponent<auxImagenWeapon>().descricao = consum[t].GetComponent<spriteWeapon>().descricao;
                        auxButtons.GetComponent<auxImagenWeapon>().questItem = consum[t].GetComponent<spriteWeapon>().questItem;
                        auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                        //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];
                        auxButtons.GetComponentInChildren<Transform>().tag = "POT";
                        auxButtons.GetComponent<Image>().color = Color.red;

                        // auxPosButtonsX += 0.063f;
                        // auxContInvent++;
                        // auxContLinha++;
                        // auxPosItens++;
                        break;
                    }
                }
                if (t < questItens.Length)
                {
                    if (questItens[t].name == nomeDasArmas[r])
                    {
                        //auxButtons.GetComponent<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.transform.Find("spriteArma").GetComponent<Image>().sprite = questItens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        //auxButtons.GetComponentInChildren<Image>().sprite = armas[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenFundo = questItens[t].GetComponent<spriteWeapon>().spriteButton;
                        auxButtons.GetComponent<auxImagenWeapon>().imagenDaArma = questItens[t].GetComponent<spriteWeapon>().spriteDessaArma;
                        auxButtons.GetComponent<auxImagenWeapon>().nomeItem = questItens[t].GetComponent<spriteWeapon>().nomeItem;
                        auxButtons.GetComponent<auxImagenWeapon>().descricao = questItens[t].GetComponent<spriteWeapon>().descricao;
                        auxButtons.GetComponent<auxImagenWeapon>().questItem = questItens[t].GetComponent<spriteWeapon>().questItem;
                        auxButtons.transform.GetChild(1).GetComponent<Collider>().enabled = false;
                        auxButtons.GetComponent<Image>().color = Color.blue;
                        //auxPosItens++;
                        //auxButtons.GetComponentInChildren<dragWeapon>().armaParaInst = itens[t];
                        break;
                    }
                }
            }
        }
        if (consums[0].GetComponent<ativaConsum>().nomeAtualDoConsum == nomeDasArmas[r])
        {
            consums[0].GetComponent<ativaConsum>().auxNomeDasArmasAtt();
        }
        if (consums[1].GetComponent<ativaConsum>().nomeAtualDoConsum == nomeDasArmas[r])
        {
            consums[1].GetComponent<ativaConsum>().auxNomeDasArmasAtt();
        }

    }

    public void discartInventory (int pos)
    {
        r = pos;
        
        nomeDasArmas[r] = "emptySlot";
        PlayerPrefs.SetString("listaDasArmas" + (r), "emptySlot");

        //PlayerPrefs.SetInt("listaDasArmasQuant" + nomeDasArmas[nomeDasArmas.Length - 1], 1);
        PlayerPrefs.SetInt("listaDasArmasQuant" + nomeDasArmas[r], 1);

        // PlayerPrefs.SetInt("tamanhoDaListaDeArmas", nomeDasArmas.Length);
        // print(r);
        PlayerPrefs.SetInt("tamanhoDaListaDeArmas", r);
        slotVazios = 0;
        for (int jjj = 0; jjj < 30; jjj++)
        {
            if (nomeDasArmas[jjj] == "emptySlot")
            {
                slotVazios++;
            }
        }
        ajusteWeaponsNew();
        
    }

    public void getArmas(string nomeDaArmaPega)
    {
        for(var j = 0; j < 1000; j++)
        {
            /* if(j < nomeDasArmas.Length)
             {
                 if(nomeDasArmas[j] == nomeDaArmaPega)
                 {
                    // print("A");
                     quant[j]++;
                     print("listaDasArmasQuant" + nomeDasArmas[j]);
                     PlayerPrefs.SetInt("listaDasArmasQuant" + nomeDasArmas[j], quant[j]);
                     // ajusteWeapons();
                     ajusteWeaponsNew();
                     break;
                 }
             }
             else
             {*/
            // print("B");
            //  nomeDasArmasAux = new string[nomeDasArmasAux.Length + 1];
            //  nomeDasArmasAux = nomeDasArmas;

            //nomeDasArmas = new string[nomeDasArmas.Length + 1];

            //  nomeDasArmas = nomeDasArmasAux;
            //  quantAux = new int[quantAux.Length + 1];
            //  quantAux = quant;

            //  quant = new int[quant.Length + 1];

            //  quant = quantAux;
            //  print(nomeDasArmas.Length);
            // print(nomeDasArmas.Length - 1);
            // print(nomeDaArmaPega);

            // nomeDasArmas[nomeDasArmas.Length - 1] = nomeDaArmaPega;
            // print(auxPosItens);
            for (r = 0; r < 30; r++)
            {
                if(nomeDasArmas[r] == "emptySlot")
                {

                    nomeDasArmas[r] = nomeDaArmaPega;

                    // quant[quant.Length - 1] = 1;
                    //quant[r] = 1;

                    //PlayerPrefs.SetString("listaDasArmas" + (nomeDasArmas.Length - 1), nomeDaArmaPega);
                    PlayerPrefs.SetString("listaDasArmas" + (r), nomeDaArmaPega);

                    //PlayerPrefs.SetInt("listaDasArmasQuant" + nomeDasArmas[nomeDasArmas.Length - 1], 1);
                    PlayerPrefs.SetInt("listaDasArmasQuant" + nomeDasArmas[r], 1);

                    // PlayerPrefs.SetInt("tamanhoDaListaDeArmas", nomeDasArmas.Length);
                   // print(r);
                    PlayerPrefs.SetInt("tamanhoDaListaDeArmas", r);

                    // ajusteWeapons();

                    ajusteWeaponsNew();
                    break;
                }
            }
             slotVazios = 0;
            for (int jjj = 0; jjj < 30; jjj++)
            {
                if (nomeDasArmas[jjj] == "emptySlot")
                {
                    slotVazios++;
                }
            }
            

                break;
            //}
        }
    }
}
