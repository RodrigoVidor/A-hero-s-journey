using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class selectSkills : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int lvlUnlock;
    Collider colliderDaSkill;
    public Sprite lockSkill, skillVerdadeira;
    Image img;
    Vector3 posInit;
    Vector2 auxPosScreen;
    bool auxPos;
    public int numeroSkill;

    // Use this for initialization
    void Start () {

        colliderDaSkill = transform.GetComponent<Collider>();
        img = transform.GetComponent<Image>();

        posInit = transform.localPosition;
        auxPosScreen = new Vector2((Screen.width * 0.5f) + 96, (Screen.height * 0.5f) - 13);
        if(PlayerPrefs.GetInt("lvl") <= lvlUnlock)
        {
            colliderDaSkill.enabled = false;
            img.sprite = lockSkill;
        }
        else
        {
            colliderDaSkill.enabled = true;
            img.sprite = skillVerdadeira;
        }

	}
	
	// Update is called once per frame
	void Update () {
		if(auxPos == false)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, posInit, 4 * Time.deltaTime);
           // if (transform.position >= posInit)
          //  {
          //      auxPos = true;
          //  }
        }


	}

    public void confirmaLvl()
    {
        colliderDaSkill = transform.GetComponent<Collider>();
        img = transform.GetComponent<Image>();
        if (PlayerPrefs.GetInt("lvl") <= lvlUnlock)
        {
             colliderDaSkill.enabled = false;
             img.sprite = lockSkill;
        }
        else
        {
            colliderDaSkill.enabled = true;
            img.sprite = skillVerdadeira;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // posInit = transform.localPosition;
        transform.SetSiblingIndex(11);
        auxPos = true;
    }


    public void OnDrag(PointerEventData eventData)
    {
         transform.localPosition = new Vector2(Input.mousePosition.x - auxPosScreen.x, Input.mousePosition.y - auxPosScreen.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
       // transform.position = posInit;
        auxPos = false;
    }

   /* public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "skill")
        {
            auxSkillPos = other.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        auxSkillPos = null;
    }*/
}
