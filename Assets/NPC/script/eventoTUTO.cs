using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventoTUTO : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                // print(hit.transform.tag);
                if (hit.transform.tag == "EVENTO" && hit.transform == transform)
                {
                    GameObject.FindGameObjectWithTag("controles").transform.Find("Tutos").Find("TutoQuest").gameObject.SetActive(false);
                    PlayerPrefs.SetInt("tutosAtivos", 1);
                }
            }
        }
    }
}
