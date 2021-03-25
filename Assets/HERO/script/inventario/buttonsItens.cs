using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonsItens : MonoBehaviour
{

    public GameObject buttonInteracao, consum1, consum2;
    GameObject auxInst, hero;
    public int numeroDoInvent;

    // Use this for initialization
    void Start()
    {
        //hero = GameObject.FindGameObjectWithTag("hero");

        /*
        if (PlayerPrefs.GetInt("consum1") == 1)
        {
            consum1.SetActive(true);
            consum1.GetComponent<ativaConsum>().vidaOuMana = false;
            consum1.GetComponent<ativaConsum>().porcRecup = PlayerPrefs.GetFloat("porcConsum1");
            consum1.GetComponent<ativaConsum>().hero = gameObject;
        }
        else if(PlayerPrefs.GetInt("consum1") == 2)
        {
            consum1.SetActive(true);
            consum1.GetComponent<ativaConsum>().vidaOuMana = true;
            consum1.GetComponent<ativaConsum>().porcRecup = PlayerPrefs.GetFloat("porcConsum1");
            consum1.GetComponent<ativaConsum>().hero = gameObject;
        }
        if (PlayerPrefs.GetInt("consum2") == 1)
        {
            consum2.SetActive(true);
            consum2.GetComponent<ativaConsum>().vidaOuMana = false;
            consum2.GetComponent<ativaConsum>().porcRecup = PlayerPrefs.GetFloat("porcConsum2");
            consum2.GetComponent<ativaConsum>().hero = gameObject;
        }
        else if (PlayerPrefs.GetInt("consum2") == 2)
        {
            consum2.SetActive(true);
            consum2.GetComponent<ativaConsum>().vidaOuMana = true;
            consum2.GetComponent<ativaConsum>().porcRecup = PlayerPrefs.GetFloat("porcConsum2");
            consum2.GetComponent<ativaConsum>().hero = gameObject;
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void janelaInteracao(GameObject item)
    {
        auxInst = Instantiate(buttonInteracao, item.transform.position, Quaternion.identity) as GameObject;
        auxInst.transform.parent = item.transform.parent.parent;
        auxInst.GetComponent<Image>().sprite = item.GetComponent<auxImagenWeapon>().imagenFundo;
        numeroDoInvent = item.GetComponent<dragWeapon>().posDoButtonNoInvent;
        hero = item.GetComponent<dragWeapon>().hero;
        auxInst.transform.Find("spriteArma").GetComponent<Image>().sprite = item.GetComponent<auxImagenWeapon>().imagenDaArma;
        auxInst.transform.Find("nome").GetComponent<Text>().text = "\n     " + item.GetComponent<auxImagenWeapon>().nomeItem;
        auxInst.transform.Find("desc").GetComponent<Text>().text = item.GetComponent<auxImagenWeapon>().descricao;
        if(item.GetComponent<auxImagenWeapon>().questItem == true)
        {
            auxInst.transform.Find("Discart").gameObject.SetActive(false);
        }

    }




    /* public void slot1(GameObject vidaOuMana)
     {
         consum1.SetActive(true);
         PlayerPrefs.SetInt("consum1", vidaOuMana.GetComponent<spriteWeapon>().vidaOuMana);
         consum1.GetComponent<ativaConsum>().porcRecup = vidaOuMana.GetComponent<spriteWeapon>().porcRecuperacao;
         PlayerPrefs.SetFloat("porcConsum1", vidaOuMana.GetComponent<spriteWeapon>().porcRecuperacao);
         consum1.GetComponent<ativaConsum>().hero = gameObject;
     }
     public void slot2(GameObject vidaOuMana)
     {
         consum2.SetActive(true);
         PlayerPrefs.SetInt("consum2", vidaOuMana.GetComponent<spriteWeapon>().vidaOuMana);
         consum2.GetComponent<ativaConsum>().porcRecup = vidaOuMana.GetComponent<spriteWeapon>().porcRecuperacao;
         PlayerPrefs.SetFloat("porcConsum2", vidaOuMana.GetComponent<spriteWeapon>().porcRecuperacao);
         consum2.GetComponent<ativaConsum>().hero = gameObject;
     }*/

    public void destroyInteracao ()
    {
        Destroy(auxInst);
    }

    public void discartItem ()
    {
        hero.GetComponent<inventWeapons>().discartInventory(numeroDoInvent);
        if (PlayerPrefs.GetInt("posArmaEquip") == numeroDoInvent)
        {
            GameObject.FindGameObjectWithTag("WEAPON").GetComponent<equipWeapon>().tiraArma();
        }
        Destroy(auxInst);
    }

}
