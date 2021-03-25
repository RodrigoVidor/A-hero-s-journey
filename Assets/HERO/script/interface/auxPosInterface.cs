using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxPosInterface : MonoBehaviour {

    public float auxX, auxY;

	// Use this for initialization
	void Start () {

        transform.localPosition = new Vector2(Screen.width * auxX, Screen.height * auxY);

        Destroy(this);

    }

    // Update is called once per frame
    void Update () {

        // transform.localPosition = new Vector2(Screen.width * auxX, Screen.height * auxY);

    }
}
