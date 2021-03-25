using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxScaleInterface : MonoBehaviour {

    public float mtpx = 1, mtpy = 1;

	// Use this for initialization
	void Start () {

        transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * mtpx, Screen.height * mtpy);

        Destroy(this);

    }
	
	// Update is called once per frame
	void Update () {

        
		//transform.GetComponent<>
	}
}
