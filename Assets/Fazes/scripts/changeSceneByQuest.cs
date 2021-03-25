using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSceneByQuest : MonoBehaviour {

    public string[] varName;
    public int[] valor;
    public string[] nomeDaScene;

	// Use this for initialization
	void Start () {
		
        for(var i = 0; i < varName.Length; i++)
        {
            if (valor[i] == PlayerPrefs.GetInt(varName[i]))
            {
                Application.LoadLevel(nomeDaScene[i]);
            }
        }

	}

}
