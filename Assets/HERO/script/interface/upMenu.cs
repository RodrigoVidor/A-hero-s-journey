using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class upMenu : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public RectTransform rect;
    public GameObject[] abasParaQuest;
    GameObject[] colisaoDosEventos;
    //public GameObject auxHeroExp;
    int j;
    public GameObject hero;
    public int speed;
   // public bool auxCamParaQuadro;
    bool aux, defineDirecao;
  //  public static float auxFocoY, auxFocoZ;

    void Start()
    {
        defineDirecao = true;

        colisaoDosEventos = GameObject.FindGameObjectsWithTag("EVENTO");

        //findHero();
        // auxFocoY = cameraFoco.distanciaRealY;
        // auxFocoZ = cameraFoco.distanciaRealZ;
    }

    void Update()
    {
        //rectTesteCentro.localPosition = new Vector2(0, Screen.height * 0.5f);
        if (aux == false)
        {
            if (defineDirecao)
            {
                if (rect.localPosition.y <= -Screen.height - 1 || rect.localPosition.y >= -Screen.height + 1)
                {
                    rect.localPosition = Vector2.Lerp(rect.localPosition, new Vector2(0, -Screen.height), speed * Time.deltaTime);
                    //   auxCamParaQuadro = false;
                }
                else
                {
                    aux = true;
                }

            }
            else
            {
                if (rect.localPosition.y <= -1 || rect.localPosition.y >= 1)
                {
                    rect.localPosition = Vector2.Lerp(rect.localPosition, new Vector2(0, 0), speed * Time.deltaTime);
                    // auxCamParaQuadro = true;
                }
                else
                {

                    aux = true;
                }
            }
        }
    }


    public void abasResetParaQuest()
    {
        abasParaQuest[0].transform.SetSiblingIndex(5);
        int childs = abasParaQuest[0].transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            abasParaQuest[0].transform.GetChild(i).gameObject.SetActive(true);
        }

        int childs1 = abasParaQuest[1].transform.childCount;
        for (int i = 0; i < childs1; i++)
        {
            abasParaQuest[1].transform.GetChild(i).gameObject.SetActive(false);
        }
        int childs2 = abasParaQuest[2].transform.childCount;
        for (int i = 0; i < childs2; i++)
        {
            abasParaQuest[2].transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void abas (GameObject aba)
    {
        aba.SetActive(true);
        aba.transform.SetSiblingIndex(5);
        int childs = aba.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            aba.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void abasSkill(GameObject abaSkill)
    {
        abaSkill.SetActive(true);
        abaSkill.transform.SetSiblingIndex(5);
        int childs = abaSkill.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            abaSkill.transform.GetChild(i).gameObject.SetActive(true);
            if (abaSkill.transform.GetChild(i).GetSiblingIndex() > 3)
            {
                 abaSkill.transform.GetChild(i).GetComponent<selectSkills>().confirmaLvl();
            }
        }
    }


    public void abasInvent(GameObject aba)
    {
        aba.transform.SetSiblingIndex(6);
        int childs = aba.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            aba.transform.GetChild(i).gameObject.SetActive(true);
        }
    }

    public void desableGameObject (GameObject obj)
    {
        obj.SetActive(false);
    }

    public void abasDisable(GameObject aba)
    {
        int childs = aba.transform.childCount;
        for (int i = 0; i < childs; i++)
        {
            aba.transform.GetChild(i).gameObject.SetActive(false);
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        aux = true;
    }


    public void OnDrag(PointerEventData eventData)
    {

        rect.localPosition = new Vector2(0, Input.mousePosition.y - (Screen.height)) ;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        aux = false;
        camFoco();
    }

    public void camFoco ()
    {
        if (aux == false)
        {
            if (rect.position.y < 0)
            {
                cameraFoco.auxCamCont = 0;
                for (var p = 0; p < colisaoDosEventos.Length; p++)
                {
                    if (colisaoDosEventos[p] != null)
                    {
                        colisaoDosEventos[p].GetComponent<Collider>().enabled = true;
                    }
                }
                defineDirecao = true;
                if (PlayerPrefs.GetInt("tutosAtivos") == 3)
                {
                    GameObject.FindGameObjectWithTag("controles").transform.Find("Tutos").Find("TutoMap").gameObject.SetActive(true);
                    PlayerPrefs.SetInt("tutosAtivos", 4);
                }
            }
            else
            {
                for (var p = 0; p < colisaoDosEventos.Length; p++)
                {
                    if (colisaoDosEventos[p] != null)
                    {
                        colisaoDosEventos[p].GetComponent<Collider>().enabled = false;
                    }
                }
                cameraFoco.auxCamCont = 1;
                defineDirecao = false;
                hero.GetComponent<heroBase>().expSoma(0);
                if(PlayerPrefs.GetInt("tutosAtivos") == 1)
                {
                    GameObject.FindGameObjectWithTag("controles").transform.Find("Tutos").Find("TutoMenu").GetComponent<tutorial>().nextTuto();
                    PlayerPrefs.SetInt("tutosAtivos", 2);
                }
            }
        }
    }

 /*   void findHero()
    {
        for (var i = 0; i < 10; i++)
        {
            hero = GameObject.FindGameObjectWithTag("hero");
            if (hero == null)
            {
                i = 0;

                j++;
            }
            if (j > 10000000)
            {
                break;
            }
        }
    }*/

}
