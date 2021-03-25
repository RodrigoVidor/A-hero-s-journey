using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipWeapon : MonoBehaviour {

    public GameObject[] auxArmasNomes;
    public Sprite[] MERDAMERDAMERDA;
    GameObject armaAtual, armaAux;
    public GameObject localParaInstArma, heroBaseParaStatus;

	// Use this for initialization
	void Start () {

        for (var i = 0; i < auxArmasNomes.Length; i++) 
        {
            if(PlayerPrefs.GetString("armaAtualNome") == auxArmasNomes[i].name)
            {
                transform.GetComponent<Image>().sprite = MERDAMERDAMERDA[i];
                if (auxArmasNomes[i].name == "soco")
                {
                    transform.GetComponent<Image>().color = new Color(0, 0, 0);
                }
                else
                {
                    transform.GetComponent<Image>().color = new Color(255, 255, 255);
                }
                armaAtual = auxArmasNomes[i];
                InstArma();
                break;
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InstArma ()
    {
        Destroy(armaAux);
        PlayerPrefs.SetString("armaAtualNome", armaAtual.name);
        heroBaseParaStatus.GetComponentInChildren<controleROT>().efeitBasicAttack = armaAtual.GetComponent<spriteWeapon>().efeitoArma;
        armaAux = Instantiate(armaAtual, localParaInstArma.transform.position, armaAtual.transform.rotation) as GameObject;
        armaAux.transform.parent = localParaInstArma.transform;
        armaAux.transform.localPosition = armaAtual.transform.position;
        armaAux.transform.localRotation = armaAtual.transform.rotation;
        armaAux.transform.localScale = armaAtual.transform.localScale;
        heroBaseParaStatus.GetComponent<heroBase>().alteraStatus(armaAux.GetComponent<spriteWeapon>().strAdd,
                    armaAux.GetComponent<spriteWeapon>().vitAdd,
                    armaAux.GetComponent<spriteWeapon>().magAdd, 4);
    }

    public void tiraArma()
    {
        Destroy(armaAux);
        PlayerPrefs.SetString("armaAtualNome", "soco");
        PlayerPrefs.SetInt("posArmaEquip", 30);
        armaAtual = auxArmasNomes[0];
        transform.GetComponent<Image>().sprite = MERDAMERDAMERDA[0];
        transform.GetComponent<Image>().color = new Color(0, 0, 0);
        heroBaseParaStatus.GetComponentInChildren<controleROT>().efeitBasicAttack = armaAtual.GetComponent<spriteWeapon>().efeitoArma;
        armaAux = Instantiate(armaAtual, localParaInstArma.transform.position, armaAtual.transform.rotation) as GameObject;
        armaAux.transform.parent = localParaInstArma.transform;
        armaAux.transform.localPosition = armaAtual.transform.position;
        armaAux.transform.localRotation = armaAtual.transform.rotation;
        armaAux.transform.localScale = armaAtual.transform.localScale;
        heroBaseParaStatus.GetComponent<heroBase>().alteraStatus(armaAux.GetComponent<spriteWeapon>().strAdd,
                    armaAux.GetComponent<spriteWeapon>().vitAdd,
                    armaAux.GetComponent<spriteWeapon>().magAdd, 4);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WEAPON")
        {
            transform.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;
            transform.GetComponent<Image>().color = new Color(255, 255, 255);
            armaAtual = other.transform.parent.GetComponent<dragWeapon>().armaParaInst;
            PlayerPrefs.SetInt("posArmaEquip", other.transform.parent.GetComponent<dragWeapon>().posDoButtonNoInvent);
            InstArma();
        }
    }
}
