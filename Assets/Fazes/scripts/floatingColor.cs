using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatingColor : MonoBehaviour {

    public Color cor1, cor2;
    public Material mat;
    public GameObject auxObjParent;
    public Vector3 movimento;

    // Use this for initialization
    void Start () {

        transform.parent = null;
		
	}
	
	// Update is called once per frame
	void Update () {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        mat.SetColor("_TintColor", Color.Lerp(cor1, cor2, Mathf.PingPong(Time.time, 1)));
        transform.localPosition = Vector3.Lerp(transform.localPosition - movimento, transform.localPosition + movimento, Mathf.PingPong(Time.time, 1));
        if(Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
               // print(hit.transform.tag);
                if (hit.transform.tag == "EVENTO")
                {
                    auxObjParent.transform.GetComponent<objOut>().touchEvento(gameObject);
                }
            }
        }

    }

    public void destroyThis()
    {
        Destroy(gameObject);
    }
}
