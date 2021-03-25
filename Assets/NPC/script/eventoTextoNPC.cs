using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventoTextoNPC : MonoBehaviour {

    public bool ifDestroyDpsDaFala, ifQuestComplete;
    public string nomeDaQuest;
    int numQuests;
    public Color cor1, cor2;
    public Material mat;
    public Vector3 movimento;
    public GameObject caixaDeTexto;
    public bool ifCaixasDepois;
    public string nomeDessaCaxaPraNAbrirMais;
    public GameObject[] caixaDeTextoParaSerAtivadaAposEssa;

    // Use this for initialization
    void Start()
    {
        if (ifCaixasDepois)
        {
            if (PlayerPrefs.GetInt(nomeDessaCaxaPraNAbrirMais) == 1)
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
        /*if (ifQuestComplete)
        {
            numQuests = PlayerPrefs.GetInt("quantQuestCompletas");
            
            for (var i = 0; i < numQuests + 2; i ++)
            {
                if (PlayerPrefs.GetString("nameQuestCompletaToral" + i) == nomeDaQuest)
                {
                   
                    
                    break;
                }
                if(i > numQuests)
                {
                    Destroy(gameObject);
                }
            }
        }*/

        if (ifQuestComplete)
        {
            if (PlayerPrefs.GetInt(nomeDaQuest) == 1)
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

        transform.parent = null;

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
                    Instantiate(caixaDeTexto, transform.position, Quaternion.identity);
                    if (ifCaixasDepois)
                    {
                        PlayerPrefs.SetInt(nomeDessaCaxaPraNAbrirMais, 1);
                        Destroy(gameObject);
                        if (ifCaixasDepois)
                        {
                            for (var PP = 0; PP < caixaDeTextoParaSerAtivadaAposEssa.Length; PP++)
                            {
                                caixaDeTextoParaSerAtivadaAposEssa[PP].SetActive(true);
                            }
                        }
                        
                    }
                    if(ifDestroyDpsDaFala)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }

    }
}
