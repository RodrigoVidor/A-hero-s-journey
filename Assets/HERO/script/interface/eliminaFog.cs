using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class eliminaFog : MonoBehaviour {

    public Object nomeLevel;
    public string cudeumcudeumcu;

	// Use this for initialization
	void Start () {

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);

        // print(Application.loadedLevel.ToString());

        if (PlayerPrefs.GetInt(nomeLevel.name) == 1)
        {
            Destroy(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {

        
    }
}
