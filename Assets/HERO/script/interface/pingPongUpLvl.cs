using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pingPongUpLvl : MonoBehaviour {

    public Image button;
    public Text texto;

    float cor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        cor = Mathf.PingPong(Time.time, 1);

        button.color = new Color(button.color.r, button.color.g, button.color.b, cor);
        texto.color = new Color(texto.color.r, texto.color.g, texto.color.b, cor);

    }
}
