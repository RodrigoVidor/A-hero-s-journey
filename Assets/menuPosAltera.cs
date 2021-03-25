using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuPosAltera : MonoBehaviour {

    public Vector2 pos;

	// Use this for initialization
	void Start () {

        pos = transform.localPosition;
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.localPosition = Vector2.Lerp(transform.localPosition, pos, 2 * Time.deltaTime);

	}
}
