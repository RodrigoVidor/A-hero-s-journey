using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class auxFontSize : MonoBehaviour {

    public float size;

	// Use this for initialization
	void Start () {

        transform.GetComponent<Text>().fontSize = Mathf.CeilToInt(size * Screen.width);

        Destroy(this);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
