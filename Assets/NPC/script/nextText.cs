using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextText : MonoBehaviour {

    public bool nextQuestNoFimDoDialogo, questCompleteNofimDoDialogo, mainQuest, randomStart, recebeVarNoFimDoDialogo, criaNoFimDoDialogo, instNoFimDoDialogo;
    public GameObject objCria;
    public Vector3 posObjCria;
    public string nomeDaVarParaSalvar;
    public int quantParaSalvar;
    public Text caixaDeTexto;
    GameObject[] colisaoDosEventos;
    public string[] textGeral;
    public Sprite[] CabecaUsada;
    public int numeroDaPrimeiraCabeca;
    public int[] changeCabecaNumero, qualCabeca;
    public Image imageParaTroca;
    int i, j;
    public bool executaUmaVez, SemPaiPraRetorno;
    public GameObject paiParaRetorno;
    public string nomeProxQuest;
    [TextArea]
    public string DescQuest, descrResumida;

    private void Start()
    {
        colisaoDosEventos = GameObject.FindGameObjectsWithTag("EVENTO");
        if (PlayerPrefs.GetInt(transform.name) == 0)
        {
            for (var p = 0; p < colisaoDosEventos.Length; p++)
            {
                colisaoDosEventos[p].GetComponent<Collider>().enabled = false;
            }

            if (randomStart)
            {
                nextRandom();
            }
            else
            {
                caixaDeTexto.text = textGeral[i];
                imageParaTroca.sprite = CabecaUsada[numeroDaPrimeiraCabeca];
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void next()
    {
        i++;
        if(randomStart)
        {

            for (var p = 0; p < colisaoDosEventos.Length; p++)
            {
                if (colisaoDosEventos[p] != null)
                {
                    colisaoDosEventos[p].GetComponent<Collider>().enabled = true;
                }
            }
            if (nextQuestNoFimDoDialogo)
            {
                
                if(recebeVarNoFimDoDialogo)
                {  
                    PlayerPrefs.SetInt(nomeDaVarParaSalvar, quantParaSalvar);
                }
                if (SemPaiPraRetorno == false)
                {
                    paiParaRetorno.GetComponent<eventoTextoNPCQuest>().terminaFalas();
                }
                GameObject.FindGameObjectWithTag("hero").GetComponent<questGeral>().nextQuestNew(nomeProxQuest, DescQuest, descrResumida);
            }
            if (executaUmaVez)
            {
                PlayerPrefs.SetInt(transform.name, 1);
            }
            Destroy(gameObject);
        }
        if (i < textGeral.Length)
        {
            caixaDeTexto.text = textGeral[i];
            if (changeCabecaNumero.Length > 0)
            {
                if (i == changeCabecaNumero[j])
                {
                    imageParaTroca.sprite = CabecaUsada[qualCabeca[j]];
                    j++;
                }
            }
        }
        else
        {
            for (var p = 0; p < colisaoDosEventos.Length; p++)
            {
                if (colisaoDosEventos[p] != null)
                {
                    colisaoDosEventos[p].GetComponent<Collider>().enabled = true;
                }
            }

            if (nextQuestNoFimDoDialogo)
            {
                
                if (recebeVarNoFimDoDialogo)
                {
                    PlayerPrefs.SetInt(nomeDaVarParaSalvar, quantParaSalvar);
                }
                if (SemPaiPraRetorno == false)
                {
                    paiParaRetorno.GetComponent<eventoTextoNPCQuest>().terminaFalas();
                }
                GameObject.FindGameObjectWithTag("hero").GetComponent<questGeral>().nextQuestNew(nomeProxQuest, DescQuest, descrResumida);

            }
            else if (questCompleteNofimDoDialogo)
            {
                
                if (mainQuest)
                {
                    PlayerPrefs.SetInt("mainQuestCompletas", PlayerPrefs.GetInt("mainQuestCompletas") + 1);
                }
                if (recebeVarNoFimDoDialogo)
                {
                    PlayerPrefs.SetInt(nomeDaVarParaSalvar, quantParaSalvar);
                }
                if (SemPaiPraRetorno == false)
                {
                    paiParaRetorno.GetComponent<eventoTextoNPCQuest>().terminaFalas();
                }
                GameObject.FindGameObjectWithTag("hero").GetComponent<questGeral>().questCompleta();

            }
            if (criaNoFimDoDialogo)
            {
                objCria.SetActive(true);
            }
            if (instNoFimDoDialogo)
            {
                Instantiate(objCria, posObjCria, objCria.transform.rotation);
            }
            if (executaUmaVez)
            {
                PlayerPrefs.SetInt(transform.name, 1);
            }
            Destroy(gameObject);
        }
        
    }
    public void nextRandom()
    {
        caixaDeTexto.text = textGeral[Random.Range(0,textGeral.Length)];
    }
}
