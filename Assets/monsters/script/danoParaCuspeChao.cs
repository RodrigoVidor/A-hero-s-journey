using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoParaCuspeChao : MonoBehaviour {

    public GameObject efeitoCol;
    GameObject auxHero, auxEfeito;
    public float dano, quantLentidao, delayParaDest;
    float delay;
    bool usado;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        delay += Time.deltaTime;
        if(delay > delayParaDest)
        {
            destroyComHero();
        }
		
	}

    void destroyComHero ()
    {
        if(usado)
        {
            auxHero.GetComponent<controleMOB>().resetSpeed();
            Destroy(auxEfeito);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "hero")
        {
            other.GetComponent<controleMOB>().speed = other.GetComponent<controleMOB>().speed * quantLentidao;
            auxHero = other.gameObject;
            auxEfeito = Instantiate(efeitoCol, auxHero.transform.position, Quaternion.identity) as GameObject;
            usado = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "hero")
        {
            other.GetComponent<controleMOB>().danoAux(dano);
            auxEfeito.transform.position = auxHero.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "hero")
        {
            other.GetComponent<controleMOB>().resetSpeed();
            Destroy(auxEfeito);
        }
    }
}
