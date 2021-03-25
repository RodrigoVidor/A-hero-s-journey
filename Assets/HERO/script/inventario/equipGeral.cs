using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class equipGeral : MonoBehaviour {

    public GameObject[] auxArmasNomes;
    public int qual; // 1 capa - 2 peito - 3 bota
    public Sprite[] MERDAMERDAMERDA;
    GameObject armaAtual, armaAux;
    public GameObject /*localParaInstArma*/ heroBaseParaStatus;

    // Use this for initialization
    void Start()
    {

        for (var i = 0; i < auxArmasNomes.Length; i++)
        {
            if (PlayerPrefs.GetString("armaduraAtualNome" + qual) == auxArmasNomes[i].name)
            {
                transform.GetComponent<Image>().sprite = MERDAMERDAMERDA[i];
                if (auxArmasNomes[i].name == "semArmadura")
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
    void Update()
    {

    }

    public void InstArma()
    {
        //Destroy(armaAux);
        PlayerPrefs.SetString("armaduraAtualNome" + qual, armaAtual.name);
        //heroBaseParaStatus.GetComponentInChildren<controleROT>().efeitBasicAttack = armaAtual.GetComponent<spriteWeapon>().efeitoArma;
        //  armaAux = Instantiate(armaAtual, localParaInstArma.transform.position, armaAtual.transform.rotation) as GameObject;
        // armaAux.transform.parent = localParaInstArma.transform;
        // armaAux.transform.localPosition = armaAtual.transform.position;
        // armaAux.transform.localRotation = armaAtual.transform.rotation;
        // armaAux.transform.localScale = armaAtual.transform.localScale;
        heroBaseParaStatus.GetComponent<heroBase>().alteraStatus(armaAtual.GetComponent<spriteWeapon>().strAdd,
                    armaAtual.GetComponent<spriteWeapon>().vitAdd,
                    armaAtual.GetComponent<spriteWeapon>().magAdd, qual);
    }

    public void tiraArma()
    {
        Destroy(armaAux);
        PlayerPrefs.SetString("armaduraAtualNome" + qual, "semArmadura");
        PlayerPrefs.SetInt("posArmaEquip", 30 + qual);
        armaAtual = auxArmasNomes[0];
        transform.GetComponent<Image>().sprite = MERDAMERDAMERDA[0];
        transform.GetComponent<Image>().color = new Color(0, 0, 0);
        //heroBaseParaStatus.GetComponentInChildren<controleROT>().efeitBasicAttack = armaAtual.GetComponent<spriteWeapon>().efeitoArma;
        //armaAux = Instantiate(armaAtual, localParaInstArma.transform.position, armaAtual.transform.rotation) as GameObject;
        //armaAux.transform.parent = localParaInstArma.transform;
        //armaAux.transform.localPosition = armaAtual.transform.position;
        //armaAux.transform.localRotation = armaAtual.transform.rotation;
        //armaAux.transform.localScale = armaAtual.transform.localScale;
        heroBaseParaStatus.GetComponent<heroBase>().alteraStatus(armaAtual.GetComponent<spriteWeapon>().strAdd,
                    armaAtual.GetComponent<spriteWeapon>().vitAdd,
                    armaAtual.GetComponent<spriteWeapon>().magAdd, qual);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (qual == 1)
        {
            if (other.tag == "HELM")
            {
                transform.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;
                transform.GetComponent<Image>().color = new Color(255, 255, 255);
                armaAtual = other.transform.parent.GetComponent<dragWeapon>().armaParaInst;
                PlayerPrefs.SetInt("posArmaEquip", other.transform.parent.GetComponent<dragWeapon>().posDoButtonNoInvent);
                InstArma();
            }
        }
        if (qual == 2)
        {
            if (other.tag == "ARMOR")
            {
                transform.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;
                transform.GetComponent<Image>().color = new Color(255, 255, 255);
                armaAtual = other.transform.parent.GetComponent<dragWeapon>().armaParaInst;
                PlayerPrefs.SetInt("posArmaEquip", other.transform.parent.GetComponent<dragWeapon>().posDoButtonNoInvent);
                InstArma();
            }
        }
        if (qual == 3)
        {
            if (other.tag == "BOOTS")
            {
                transform.GetComponent<Image>().sprite = other.GetComponent<Image>().sprite;
                transform.GetComponent<Image>().color = new Color(255, 255, 255);
                armaAtual = other.transform.parent.GetComponent<dragWeapon>().armaParaInst;
                PlayerPrefs.SetInt("posArmaEquip", other.transform.parent.GetComponent<dragWeapon>().posDoButtonNoInvent);
                InstArma();
            }
        }
    }
}


