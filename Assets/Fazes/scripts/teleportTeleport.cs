using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportTeleport : MonoBehaviour {

    public string nomeDaArea;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void teleportATIVAR ()
    {
        if (Application.loadedLevelName != nomeDaArea)
        {
            PlayerPrefs.SetInt("saidaScene", 50);
            PlayerPrefs.SetFloat("tempoMusica" + musicOverScene.musicaAux.name, musicOverScene.musicTime.time);
            Application.LoadLevel(nomeDaArea);
        }
    }
}
