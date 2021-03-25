using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour {

    public GameObject ponteiro;
    public Sprite imgPoint, imgPointDown;
    public float scaleX, scaleY;
    public Vector2[] PosMov;
    public float[] delayMov;
    public float[] speed;
    public bool[] pointDown;
    float delay;
    int cont;
    public int numeroTuto;
    public GameObject tuto0, tuto1, tuto2, tuto3;

    // Use this for initialization
    void Start() {

        ponteiro.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width * scaleX, Screen.height * scaleY);
        ponteiro.transform.localPosition = new Vector2(Screen.width * PosMov[0].x, Screen.height * PosMov[0].y);
        cont++;

    }

    // Update is called once per frame
    void Update() {

        delay += Time.deltaTime;
        ponteiro.transform.localPosition = Vector2.Lerp(ponteiro.transform.localPosition, new Vector2(Screen.width * PosMov[cont].x, Screen.height * PosMov[cont].y), speed[cont] * Time.deltaTime);

        if (delay >= delayMov[cont])
        {
            if (pointDown[cont] == true)
            {
                ponteiro.GetComponent<Image>().sprite = imgPointDown;
            }
            else
            {
                ponteiro.GetComponent<Image>().sprite = imgPoint;
            }
            delay = 0;
            cont++;
        }
        if (cont >= PosMov.Length)
        {
            cont = 0;
        }

    }

    public void nextTuto()
    {
        if(numeroTuto == 0)
        {
            tuto1.SetActive(true);
            transform.gameObject.SetActive(false);
        }
        if(numeroTuto == 1)
        {
            tuto2.SetActive(true);
            transform.gameObject.SetActive(false);
        }
        if (numeroTuto == 2)
        {
            PlayerPrefs.SetInt("tutosAtivos", 3);
            transform.gameObject.SetActive(false);
        }
        if (numeroTuto == 3)
        {
            transform.gameObject.SetActive(false);
        }
    }
    
}
