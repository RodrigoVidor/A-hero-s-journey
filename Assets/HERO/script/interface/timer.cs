using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour {

   // public GameObject luz;
  //  public Light auxLuz;
    public Text tempo;
    public float speedTempo;
    GameObject[] efeitoAtivaNoite, efeitoAtivaDia, fogDia, fogNoite;
    float tempoSeg, tempoAux, tempoAux2, aux, aux2, auxInside;
    int tempoMin, tempoHr;

	// Use this for initialization
	void Start () {

        if(Application.loadedLevelName == "homeInside")
        {
            auxInside = 0.3f;
        }
        else
        {
            auxInside = 1;
        }

        //for(int i = 0; i < 100; i++)
       // {
       // efeitoAtivaNoite = GameObject.FindGameObjectsWithTag("efeitoAtivaNoite");
       // efeitoAtivaDia = GameObject.FindGameObjectsWithTag("efeitoAtivaDia");
        //fogDia = GameObject.FindGameObjectsWithTag("fogDia");
       // fogNoite = GameObject.FindGameObjectsWithTag("fogNoite");
        //  }
        //86400
        speedTempo = 60;

        tempoSeg = PlayerPrefs.GetFloat("seg");
        tempoMin = PlayerPrefs.GetInt("min");
        tempoHr = PlayerPrefs.GetInt("hr");
        tempo.text = tempoHr.ToString("00") + ":" + tempoMin.ToString("00");
       /* if (tempoHr < 7 || tempoHr >= 19)
        {
            foreach (GameObject go in efeitoAtivaNoite)
            {
                go.SetActive(true);
            }
            foreach (GameObject goD in efeitoAtivaDia)
            {
                goD.SetActive(false);
            }/*
            foreach (GameObject goFd in fogDia)
            {
                ParticleSystem.EmissionModule em = goFd.GetComponent <ParticleSystem>().emission;
                em.enabled = false;
            }
            foreach (GameObject goFn in efeitoAtivaDia)
            {
                ParticleSystem.EmissionModule em = goFn.GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }
        }
       /* else
        {
            foreach (GameObject go in efeitoAtivaNoite)
            {
                go.SetActive(false);
            }
            foreach (GameObject goD in efeitoAtivaDia)
            {
                goD.SetActive(true);
            }/*
            foreach (GameObject goFd in fogDia)
            {
                ParticleSystem.EmissionModule em = goFd.GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }
            foreach (GameObject goFn in efeitoAtivaDia)
            {
                ParticleSystem.EmissionModule em = goFn.GetComponent<ParticleSystem>().emission;
                em.enabled = false;
            }
        }*/
    }
	
	// Update is called once per frame
	void Update () {

        tempoSeg += Time.deltaTime * speedTempo;
        tempoAux2 = tempoSeg + (tempoMin * 60) + (tempoHr * 3600);

        if (tempoHr < 12)
        {
            tempoAux = tempoSeg + (tempoMin * 60) + (tempoHr * 3600); 
        }
        else 
        {
            tempoAux =  86400 -(tempoSeg + (tempoMin * 60) + (tempoHr * 3600)); 
        }

        aux = tempoAux / 43200;
        aux2 = tempoAux2 * 180 / 43200;
        //print(aux);
       // RenderSettings.ambientLight = new Color(aux, aux, aux);
      //  auxLuz.intensity = auxInside * ((aux * 2.5f) + 0.3f);
     //   luz.transform.eulerAngles = new Vector3(0, 0, aux2);

        if (tempoSeg >= 60)
        {
            tempoMin++;
            tempoSeg = 0;
            atualisaTempo();
        }
        if (tempoMin >= 60)
        {
            tempoHr++;
            tempoMin = 0;
            atualisaTempoHr();
        }
        if(tempoHr == 24)
        {
            tempoHr = 0;
            tempoAux2 = 0;
            atualisaTempoHr();
            atualisaTempo();
        }
        PlayerPrefs.SetFloat("seg", tempoSeg);
       
    }

    void atualisaTempo ()
    {
        tempo.text = tempoHr.ToString("00") + ":" + tempoMin.ToString("00");
        PlayerPrefs.SetInt("min", tempoMin);
    }

    void atualisaTempoHr()
    {
        tempo.text = tempoHr.ToString("00") + ":" + tempoMin.ToString("00");
        PlayerPrefs.SetInt("hr", tempoHr);
        /*if (tempoHr < 7 || tempoHr >= 19)
        {
            foreach (GameObject go in efeitoAtivaNoite)
            {
                go.SetActive(true);
            }
            foreach (GameObject goD in efeitoAtivaDia)
            {
                goD.SetActive(false);
            }/*
            foreach (GameObject goFd in fogDia)
            {
                ParticleSystem.EmissionModule em = goFd.GetComponent<ParticleSystem>().emission;
                em.enabled = false;
            }
            foreach (GameObject goFn in efeitoAtivaDia)
            {
                ParticleSystem.EmissionModule em = goFn.GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }
        }
        else
        {
            foreach (GameObject go in efeitoAtivaNoite)
            {
                go.SetActive(false);
            }
            foreach (GameObject goD in efeitoAtivaDia)
            {
                goD.SetActive(true);
            }/*
            foreach (GameObject goFd in fogDia)
            {
                ParticleSystem.EmissionModule em = goFd.GetComponent<ParticleSystem>().emission;
                em.enabled = true;
            }
            foreach (GameObject goFn in efeitoAtivaDia)
            {
                ParticleSystem.EmissionModule em = goFn.GetComponent<ParticleSystem>().emission;
                em.enabled = false;
            }
        }*/
    }
}
