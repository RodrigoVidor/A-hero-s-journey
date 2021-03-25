using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class descButtonQuest : MonoBehaviour {

    public string descQuest;
    GameObject auxDesc;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showDesc (GameObject desc)
    {
        auxDesc = Instantiate(desc, transform.position, Quaternion.identity) as GameObject;
        auxDesc.GetComponentInChildren<Text>().text = descQuest;
        auxDesc.transform.parent = transform.parent.parent.parent.parent.parent;
    }
}
