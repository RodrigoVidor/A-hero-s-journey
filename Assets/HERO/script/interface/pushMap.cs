using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class pushMap : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    bool auxPosMap, defineDirecao;
    public RectTransform rect;
    public int speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (auxPosMap == false)
        {
            if (defineDirecao)
            {
                if (rect.localPosition.x <= -Screen.width - 1 || rect.localPosition.x >= -Screen.width + 1)
                {
                    rect.localPosition = Vector2.Lerp(rect.localPosition, new Vector2(Screen.width * 0.5f, 0), speed * Time.deltaTime);
                    //   auxCamParaQuadro = false;
                }
                else
                {
                    auxPosMap = true;
                }

            }
            else
            {
                if (rect.localPosition.x <= -1 || rect.localPosition.x >= 1)
                {
                    rect.localPosition = Vector2.Lerp(rect.localPosition, new Vector2(-Screen.width * 0.5f, 0), speed * Time.deltaTime);
                    // auxCamParaQuadro = true;
                }
                else
                {

                    auxPosMap = true;
                }
            }
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        auxPosMap = true;
    }


    public void OnDrag(PointerEventData eventData)
    {

        rect.localPosition = new Vector2(Input.mousePosition.x - (Screen.width * 0.5f), 0);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        auxPosMap = false;
        camFoco();
    }
    public void camFoco()
    {
        if (auxPosMap == false)
        {
            if (rect.position.x > Screen.width * 0.5f)
            {
                defineDirecao = true;
                if (PlayerPrefs.GetInt("tutosAtivos") == 4)
                {
                    GameObject.FindGameObjectWithTag("controles").transform.Find("Tutos").Find("TutoMap").gameObject.SetActive(false);
                    PlayerPrefs.SetInt("tutosAtivos", 666);
                }
            }
            else
            {
                defineDirecao = false;
            }
        }
    }
}
