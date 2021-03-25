using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleportButtons : MonoBehaviour {

    public GameObject buttonTP, canvas;
    GameObject auxButton;
    public float auxSomaPos;

	// Use this for initialization
	void Start () {

        if (PlayerPrefs.GetInt("contTP") > 0)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("contTP"); i++)
            {
                auxButton = Instantiate(buttonTP, transform.position, Quaternion.identity) as GameObject;
                auxButton.transform.parent = transform;
                auxButton.GetComponentInChildren<Text>().text = PlayerPrefs.GetString("nomeProxTP" + (i+1));
                auxButton.GetComponent<teleportTeleport>().nomeDaArea = PlayerPrefs.GetString("nomeProxTP" + (i + 1));
                auxButton.GetComponent<auxPosInterface>().auxY = auxSomaPos;
                auxSomaPos -= 0.17f;
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroyTeleportCanvas ()
    {
        Destroy(canvas);
    }
}
