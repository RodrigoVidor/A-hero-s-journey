using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class auxMostraDanos : MonoBehaviour {

    //public float dano;
    public Text danos;

	// Use this for initialization
	void Start () {

        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void restoText(float dano)
    {
        danos.text = dano.ToString("F0");
    }

    public void restoTextGold(float dano)
    {
        danos.text = dano.ToString("F0") + " G";
    }
    public void itemText (string name)
    {
        danos.text = name;
    }
}
