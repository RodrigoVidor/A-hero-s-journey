using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopMove : MonoBehaviour {

    GameObject cam;
    public GameObject menuObj, shopBuyObj, shopSellObj, caixaTextoSemEspaco, caixaTextoSemDinheiro, buyButtonComSlot, buyButtonSemSlot;
    public GameObject[] objVenda, subClasses;
    public int[] preco, itensSemSlot; //itens valor 0 = precisa de slot, valor 1 = nao precisa
    public GameObject posParaInst;
    GameObject auxInst;
    int auxPosPreco, cont;
    Vector3 posHero;
    public Vector3 posParaCamera, rotParaCamera;

    // Use this for initialization
    void Start () {

        cam = GameObject.FindGameObjectWithTag("MainCamera");
        posHero = GameObject.FindGameObjectWithTag("hero").transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ativaShop(int numero)
    {
        if (numero == 1)
        {
            subClasses[0].SetActive(true);
        }
        else if (numero == 2)
        {
            subClasses[1].SetActive(true);
        }
        else if (numero == 3) 
        {
            subClasses[2].SetActive(true);
        }
        shopBuyObj.SetActive(false);
    }

    public void voltaSubclasse()
    {
        for (var pp = 0; pp < subClasses.Length; pp++) 
        {
            subClasses[pp].SetActive(false);
        }
        buyButtonSemSlot.SetActive(false);
        buyButtonComSlot.SetActive(false);
        shopBuyObj.SetActive(true);
    }

    public void shopBuy()
    {
        menuObj.GetComponent<menuPosAltera>().pos = new Vector2(Screen.width * -1, 0);
        shopBuyObj.GetComponent<menuPosAltera>().pos = new Vector2(0, 0);
        cam.GetComponent<cameraFoco>().camFocoShopIbi(posParaCamera, rotParaCamera);
    }

    public void shopSell()
    {
        //menuObj.GetComponent<menuPosAltera>().pos = new Vector2(Screen.width * -1, 0);
        //shopSellObj.GetComponent<menuPosAltera>().pos = new Vector2(0, 0);
    }

    public void back()
    {
        menuObj.GetComponent<menuPosAltera>().pos = new Vector2(0, 0);
        shopBuyObj.GetComponent<menuPosAltera>().pos = new Vector2(Screen.width * -1, 0);
        //shopSellObj.GetComponent<menuPosAltera>().pos = new Vector2(Screen.width * -1, 0);
        cam.GetComponent<cameraFoco>().camFocoGame();
    }

    public void buy()
    {
        cont = 0;
        if(PlayerPrefs.GetInt("dinheiro") >= preco[auxPosPreco])
        {
            for(int i = 0; i < 30; i++)
            {
                if(PlayerPrefs.GetString("listaDasArmas" + i) == "emptySlot")
                {
                    PlayerPrefs.SetInt("dinheiro", PlayerPrefs.GetInt("dinheiro") - preco[auxPosPreco]);
                    Instantiate(objVenda[auxPosPreco], posHero, Quaternion.identity);
                    break;
                }
                cont++;
            }
            if(cont >= 30)
            {
                Instantiate(caixaTextoSemEspaco, transform.position, Quaternion.identity);
            } 
        }
        else
        {
            Instantiate(caixaTextoSemDinheiro, transform.position, Quaternion.identity);
        }
    }

    public void buyObjSemSlot()
    {
        if (PlayerPrefs.GetInt("dinheiro") >= preco[auxPosPreco])
        {          
            PlayerPrefs.SetInt("dinheiro", PlayerPrefs.GetInt("dinheiro") - preco[auxPosPreco]);
            Instantiate(objVenda[auxPosPreco], posHero, Quaternion.identity);
        }
        else
        {
            Instantiate(caixaTextoSemDinheiro, transform.position, Quaternion.identity);
        }
    }

    public void sell()
    {

    }

    public void selecionaObj(int posDoItem)
    {
        if(auxInst != null)
        {
            Destroy(auxInst);
        }
        if (itensSemSlot[posDoItem] == 0)
        {
            buyButtonSemSlot.SetActive(false);
            buyButtonComSlot.SetActive(true);
        }
        else
        {
            buyButtonComSlot.SetActive(false);
            buyButtonSemSlot.SetActive(true);
        }
        auxPosPreco = posDoItem;
        auxInst = Instantiate(objVenda[posDoItem], posParaInst.transform.position, Quaternion.identity) as GameObject;
    }

    public void sairShop ()
    {
        Destroy(auxInst);
        Destroy(gameObject);
    }
}
