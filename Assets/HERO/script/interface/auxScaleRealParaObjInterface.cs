using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxScaleRealParaObjInterface : MonoBehaviour {

    public float mtpx = 1, mtpy = 1, mtpz = 1;

    // Use this for initialization
    void Start () {

        transform.GetComponent<RectTransform>().transform.localScale = new Vector3(Screen.width * mtpx, mtpy, Screen.height * mtpz);

        Destroy(this);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
