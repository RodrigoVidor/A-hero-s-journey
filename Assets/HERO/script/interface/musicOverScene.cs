using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicOverScene : MonoBehaviour {

    public AudioClip musica;
    public static AudioClip musicaAux;
    public static AudioSource musicTime;

	// Use this for initialization
	void Start () {

        musicaAux = musica;
        musicTime = transform.GetComponent<AudioSource>();
        musicTime.clip = musicaAux;
        musicTime.time = PlayerPrefs.GetFloat("tempoMusica" + musicaAux.name);
        musicTime.Play();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
