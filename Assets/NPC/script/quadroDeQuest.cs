using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quadroDeQuest : MonoBehaviour {

    public GameObject quadroFundo;

    public Color cor1, cor2;
    public Material mat;
    public Vector3 movimento;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        mat.SetColor("_TintColor", Color.Lerp(cor1, cor2, Mathf.PingPong(Time.time, 1)));
        transform.localPosition = Vector3.Lerp(transform.localPosition - movimento, transform.localPosition + movimento, Mathf.PingPong(Time.time, 1));

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                // print(hit.transform.tag);
                if (hit.transform.tag == "EVENTO" && hit.transform == transform)
                {
                    Instantiate(quadroFundo, transform.position, Quaternion.identity);
                    //print("ta de sacanagem ?");
                }
            }
        }
    }


}
