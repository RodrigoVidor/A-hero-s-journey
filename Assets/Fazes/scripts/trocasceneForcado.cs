using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trocasceneForcado : MonoBehaviour {

    public float fadeInt;
    public bool voltaQuadro;
    float delay;
    public GameObject pontoDeInst, PAIDETODOS;
    public GameObject fade;


    // Use this for initialization
    void Start()
    {
        if(voltaQuadro)
        {
            if(PlayerPrefs.GetInt("saidaScene") == 999)
            {
                Instantiate(PAIDETODOS, pontoDeInst.transform.position, Quaternion.identity);
            }
        }
        else
        {
            Instantiate(PAIDETODOS, pontoDeInst.transform.position, Quaternion.identity);
        }
        
        
        fade = GameObject.FindGameObjectWithTag("fade");
        fade.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
        delay = 0.7f;
    }
	
	// Update is called once per frame
	void Update () {

        if (delay >= 0)
        {
            fade.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, fadeInt);
            delay -= Time.deltaTime;
            fadeInt = delay;
            // print((delay * -1) - 0.7f);
            musicOverScene.musicTime.volume = (delay * -1) + 0.7f;
        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
