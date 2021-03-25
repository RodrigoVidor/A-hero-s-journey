using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventoTextoNPCQuest : MonoBehaviour {

    public string nomeQuest;
    public bool ifQuestComEntrega;
    public string[] nomeMat;
    public int[] quantMat, posParaDestroy;
    public Color cor1, cor2;
    public Material mat;
    public Vector3 movimento;
    public GameObject caixaDeTextoQuestCompleta, caixaDeTextoQuestIncompleta;
    GameObject auxGetQuest, auxFalas, auxAbas;
    public bool ifCaixasDepois;
    public GameObject[] caixaDeTextoParaSerAtivadaAposEssa;
    int j, cont;

    // Use this for initialization
    void Start()
    {

        transform.parent = null;
        if (PlayerPrefs.GetInt(nomeQuest) == 1)
        {
            Destroy(gameObject);
            if (ifCaixasDepois)
            {
                for (var PP = 0; PP < caixaDeTextoParaSerAtivadaAposEssa.Length; PP++)
                {
                    caixaDeTextoParaSerAtivadaAposEssa[PP].SetActive(true);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        mat.SetColor("_TintColor", Color.Lerp(cor1, cor2, Mathf.PingPong(Time.time, 1)));
        transform.localPosition = Vector3.Lerp(transform.localPosition - movimento, transform.localPosition + movimento, Mathf.PingPong(Time.time, 1));
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                // print(hit.transform.tag);
                if (hit.transform.tag == "EVENTO" && hit.transform == transform)
                {
                    if (ifQuestComEntrega)
                    {
                        auxAbas = GameObject.FindGameObjectWithTag("UPMENU");
                        auxAbas.GetComponent<upMenu>().abasResetParaQuest();
                        for (var k = 0; k < nomeMat.Length; k++)
                        {
                            for (var i = 0; i < 30; i++)
                            {
                                if (j < quantMat[k])
                                {
                                    
                                    if (PlayerPrefs.GetString("listaDasArmas" + i) == nomeMat[k])
                                    {
                                        j++;
                                        posParaDestroy[cont] = i;
                                        cont++;
                                        
                                    }
                                    
                                }
                                else
                                {
                                   
                                    j = 0;
                                    break;                                
                                }
                                
                            }
                        }
                        if (cont == posParaDestroy.Length)
                        {
                            auxFalas = Instantiate(caixaDeTextoQuestCompleta, transform.position, Quaternion.identity) as GameObject;
                            auxFalas.GetComponent<nextText>().paiParaRetorno = gameObject;
                            /* PlayerPrefs.SetInt(nomeQuest, 1);
                            if (ifCaixasDepois)
                            {
                                for (var aa = 0; aa < caixaDeTextoParaSerAtivadaAposEssa.Length; aa++)
                                {
                                    caixaDeTextoParaSerAtivadaAposEssa[aa].SetActive(true);
                                }
                            }
                            for (var a = 0; a < posParaDestroy.Length; a++)
                            {
                                //  PlayerPrefs.SetInt(nomeMat[a], PlayerPrefs.GetInt(nomeMat[a]) - quantMat[a]);
                                GameObject.FindGameObjectWithTag("hero").GetComponent<inventWeapons>().discartInventory(posParaDestroy[a]);

                                if(PlayerPrefs.GetInt("posArmaEquip") == posParaDestroy[a])
                                {
                                    GameObject.FindGameObjectWithTag("WEAPON").GetComponent<equipWeapon>().tiraArma();
                                }
                            }
                            Destroy(gameObject);*/
                        }
                        else
                        {
                            Instantiate(caixaDeTextoQuestIncompleta, transform.position, Quaternion.identity);
                            cont = 0;
                        }
                    }
                    else
                    {
                        auxFalas = Instantiate(caixaDeTextoQuestCompleta, transform.position, Quaternion.identity) as GameObject;
                        auxFalas.GetComponent<nextText>().paiParaRetorno = gameObject;
                       /* PlayerPrefs.SetInt(nomeQuest, 1);
                        if (ifCaixasDepois)
                        {
                            for (var aa = 0; aa < caixaDeTextoParaSerAtivadaAposEssa.Length; aa++)
                            {
                                caixaDeTextoParaSerAtivadaAposEssa[aa].SetActive(true);
                            }
                        }
                        Destroy(gameObject);*/
                    }
                }
            }
        }

    }

    public void terminaFalas ()
    {
        if (ifQuestComEntrega)
        {
            PlayerPrefs.SetInt(nomeQuest, 1);
            if (ifCaixasDepois)
            {
                for (var aa = 0; aa < caixaDeTextoParaSerAtivadaAposEssa.Length; aa++)
                {
                    caixaDeTextoParaSerAtivadaAposEssa[aa].SetActive(true);
                }
            }
            for (var a = 0; a < posParaDestroy.Length; a++)
            {
                //  PlayerPrefs.SetInt(nomeMat[a], PlayerPrefs.GetInt(nomeMat[a]) - quantMat[a]);
                GameObject.FindGameObjectWithTag("hero").GetComponent<inventWeapons>().discartInventory(posParaDestroy[a]);

                if (PlayerPrefs.GetInt("posArmaEquip") == posParaDestroy[a])
                {
                    GameObject.FindGameObjectWithTag("WEAPON").GetComponent<equipWeapon>().tiraArma();
                }
            }
            Destroy(gameObject);
        }
        else
        {
            PlayerPrefs.SetInt(nomeQuest, 1);
            if (ifCaixasDepois)
            {
                for (var aa = 0; aa < caixaDeTextoParaSerAtivadaAposEssa.Length; aa++)
                {
                    caixaDeTextoParaSerAtivadaAposEssa[aa].SetActive(true);
                }
            }
            Destroy(gameObject);
        }
    }
}

