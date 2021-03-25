using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objOut : MonoBehaviour {

    public string nomeDaVar, textoObjTrue, textoObjFalse;
    public GameObject blocoAcao, efeitoDestroy, canvasTextoTrue, canvasTextoFalse;
    GameObject auxCavasTexto;
    Vector3 posInitBloco;
    //GameObject auxBlocoParent;
    //public bool ativarParaNDeletarSeFor1;

	// Use this for initialization
	void Start () {

        blocoAcao.SetActive(false);
        posInitBloco = blocoAcao.transform.position;
        //print(posInitBloco);
        /*
        if(PlayerPrefs.GetInt(nomeObjSave) == 1 && ativarParaNDeletarSeFor1 == false)
        {
            Destroy(gameObject);
        }
        else if(PlayerPrefs.GetInt(nomeObjSave) ==  0 && ativarParaNDeletarSeFor1 == true)
        {
            Destroy(gameObject);
        }
		*/
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void touchEvento(GameObject eventoParaDestroy)
    {
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt(nomeDaVar) == 1)
        {
            auxCavasTexto = Instantiate(canvasTextoTrue, transform.position, efeitoDestroy.transform.rotation) as GameObject;
            auxCavasTexto.GetComponentInChildren<Text>().text = textoObjTrue;
            auxCavasTexto.GetComponent<auxParaCanvasDaCaixaDeDialogo>().recebeObj(gameObject);
            //Instantiate(efeitoDestroy, transform.position, efeitoDestroy.transform.rotation);
            //eventoParaDestroy.transform.GetComponent<floatingColor>().destroyThis();
            //Destroy(gameObject);
        }
        else
        {
            auxCavasTexto = Instantiate(canvasTextoFalse, transform.position, efeitoDestroy.transform.rotation) as GameObject;
            auxCavasTexto.GetComponent<auxParaCanvasDaCaixaDeDialogo>().recebeObj(gameObject);
            auxCavasTexto.GetComponentInChildren<Text>().text = textoObjFalse;
        }
        eventoParaDestroy.SetActive(false);
    }

    public void eventoAceito(GameObject canvas)
    {
        Time.timeScale = 1;
        Instantiate(efeitoDestroy, transform.position, efeitoDestroy.transform.rotation);
        //eventoParaDestroy.transform.GetComponent<floatingColor>().destroyThis();
        Destroy(gameObject);
        Destroy(canvas);
    }

    public void eventoNaoAceito(GameObject canvas)
    {
        Time.timeScale = 1;
        //Instantiate(efeitoDestroy, transform.position, efeitoDestroy.transform.rotation);
        //eventoParaDestroy.transform.GetComponent<floatingColor>().destroyThis();
        Destroy(canvas);
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "hero")
        {
            blocoAcao.SetActive(true);
            //auxBlocoParent = Instantiate(blocoAcao, transform.position, blocoAcao.transform.rotation) as GameObject;
            //auxBlocoParent.transform.parent = other.transform;
            //Destroy(gameObject);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "hero")
        {
            blocoAcao.SetActive(false);
            blocoAcao.transform.position = posInitBloco;
            //Destroy(auxBlocoParent);
            //Destroy(gameObject);
        }
    }
}
