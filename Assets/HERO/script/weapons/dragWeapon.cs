using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class dragWeapon : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    GameObject pai, otherButton;
    public Vector2[] posDEMERDA;
    public Vector3 posInit, auxPosFinal;
    Vector2 auxPosScreen;
    public Vector2 auxParaPosInventInit, auxParaPosInventFinal;
    public int posDoButtonNoInvent;
    public string nomeDoItem;
    //string nomeDoItemAux;
    int posDoButtonNoInventAux;
    string auxName;
    bool auxPos, troca;
    public GameObject armaParaInst;
    public GameObject hero;
    public static bool movendo;


    // Use this for initialization
    void Start () {

        pai = transform.parent.gameObject;
        posInit = transform.localPosition;
        auxPosFinal = posInit;
        auxPosScreen = new Vector2((Screen.width * 0.38f) + 96, (Screen.height * 0.53f) - 13);



    }

    // Update is called once per frame
    void Update () {
        if (auxPos == false)
        {
            transform.localPosition = Vector2.Lerp(transform.localPosition, posInit, 4 * Time.deltaTime);
            // if (transform.position >= posInit)
            //  {
            //      auxPos = true;
            //  }
        }

        if(troca && otherButton != null)
        {

           
            posInit = otherButton.GetComponent<dragWeapon>().posInit;
            otherButton.GetComponent<dragWeapon>().trocaItenDeLugar(auxPosFinal);
            auxPosFinal = posInit;

            posDoButtonNoInventAux = otherButton.GetComponent<dragWeapon>().posDoButtonNoInvent;

            hero.GetComponent<inventWeapons>().nomeDasArmas[posDoButtonNoInvent] = otherButton.GetComponent<dragWeapon>().nomeDoItem;
            hero.GetComponent<inventWeapons>().nomeDasArmas[posDoButtonNoInventAux] = nomeDoItem;
            hero.GetComponent<inventWeapons>().auxObjGame[posDoButtonNoInvent] = otherButton.gameObject;
            hero.GetComponent<inventWeapons>().auxObjGame[posDoButtonNoInventAux] = gameObject;
            PlayerPrefs.SetString("listaDasArmas" + (posDoButtonNoInvent), otherButton.GetComponent<dragWeapon>().nomeDoItem);
            PlayerPrefs.SetString("listaDasArmas" + (posDoButtonNoInventAux), nomeDoItem);

            otherButton.GetComponent<dragWeapon>().posDoButtonNoInvent = posDoButtonNoInvent;
            
            if (PlayerPrefs.GetInt("posArmaEquip") == posDoButtonNoInvent)
            {
                PlayerPrefs.SetInt("posArmaEquip", posDoButtonNoInventAux);
            }
            else if (PlayerPrefs.GetInt("posArmaEquip") == posDoButtonNoInventAux)
            {
                PlayerPrefs.SetInt("posArmaEquip", posDoButtonNoInvent);
            }


            posDoButtonNoInvent = posDoButtonNoInventAux;






            //auxParaPosInventInit = otherButton.GetComponent<dragWeapon>().auxParaPosInventInit ;
            //otherButton.GetComponent<dragWeapon>().trocaAuxPosDeLugar(auxParaPosInventFinal);
            //auxParaPosInventFinal = auxParaPosInventInit;

            troca = false;
            hero.GetComponent<inventWeapons>().consums[0].transform.GetComponent<ativaConsum>().auxNomeDasArmasAtt();
            hero.GetComponent<inventWeapons>().consums[1].transform.GetComponent<ativaConsum>().auxNomeDasArmasAtt();
        }

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // posInit = transform.localPosition;
        transform.parent = pai.transform.parent.parent;
        auxPos = true;
        movendo = true;

    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.localPosition = new Vector2(Input.mousePosition.x - auxPosScreen.x, Input.mousePosition.y - auxPosScreen.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // transform.position = posInit;
        transform.parent = pai.transform;
        troca = true;
        auxPos = false;
        movendo = false;

    }

    public void trocaItenDeLugar(Vector3 posTroca)
    {
        posInit = posTroca;
        auxPosFinal = posInit;

    }
    // public void trocaAuxPosDeLugar(Vector2 auxParaPosInvent)
    //{
    //auxParaPosInventInit = auxParaPosInvent;
    // auxParaPosInventFinal = auxParaPosInventInit; 
    //}

    public void OnTriggerEnter(Collider other)
    {
        if(auxPos)
        {
            if(other.tag == "ITENS")
            {
                otherButton = other.gameObject;
               // other.transform.GetComponent<dragWeapon>().posInit = posInit;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "ITENS")
        {
            otherButton = null;
            other.transform.GetComponent<dragWeapon>().posInit = other.transform.GetComponent<dragWeapon>().auxPosFinal;
        }
    }
}
