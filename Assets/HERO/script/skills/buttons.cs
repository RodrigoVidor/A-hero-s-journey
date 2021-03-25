using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    public GameObject hero, spriteParaNaoTrocarSkill;
    public int numeroPoder;
    public float delay;
    int j;
    int tipoDeMira;  //0 seta ... 1 esfera ... 2 earth ... 3 swordDive
    float delayAux;
    Image img;
    Vector3 auxScale;
    public int numeroDoBotao;

    public GameObject setaSkill, esferaParaMira, earthMira, setaSwordDive, setaSwordLancer, setaSwordForce;

    void Start()
    {

        img = transform.GetComponent<Image>();
        if (numeroPoder == 4)
        {
            tipoDeMira = 1;
            auxScale = new Vector3(4.5f, 4.5f, 4.5f);
        }
        if (numeroPoder == 5 || numeroPoder == 3)
        {
            tipoDeMira = 1;
            auxScale = new Vector3(1, 1, 1);
        }
        if (numeroPoder == 1)
        {
            auxScale = new Vector3(0.33f, 0.47f, 0.33f);
        }
        if (numeroPoder == 2)
        {
            auxScale = new Vector3(0.4f, 0.3f, 0.2f);
        }
        if (numeroPoder == 11)
        {
            auxScale = new Vector3(0.33f, 0.4f, 0.13f);
        }
        if (numeroPoder == 12)
        {
            auxScale = new Vector3(0.33f, 0.18f, 2);
        }
        if (numeroPoder == 6)
        {
            tipoDeMira = 2;
        }
        if (numeroPoder == 7)
        {
            tipoDeMira = 5;
        }
        if (numeroPoder == 8)
        {
            tipoDeMira = 3;
        }
        if (numeroPoder == 9)
        {
            tipoDeMira = 4;
        }
        delay = hero.GetComponent<controleROT>().poderGeral[numeroPoder].transform.GetComponent<manaCost>().delay;
        delayAux = PlayerPrefs.GetFloat("delayParaPoder" + numeroDoBotao);
        //findHero();


    }
    public void atualizaMira(int numeroSkill)
    {
        numeroPoder = numeroSkill;
        if (numeroPoder == 4)
        {
            tipoDeMira = 1;
            auxScale = new Vector3(4.5f, 4.5f, 4.5f);
        }
        if (numeroPoder == 5 || numeroPoder == 3)
        {
            tipoDeMira = 1;
            auxScale = new Vector3(1, 1, 1);
        }
        if (numeroPoder == 1)
        {
            tipoDeMira = 0;
            auxScale = new Vector3(0.33f, 0.47f, 0.33f);
        }
        if (numeroPoder == 2)
        {
            tipoDeMira = 0;
            auxScale = new Vector3(0.4f, 0.3f, 0.2f);
        }
        if (numeroPoder == 11)
        {
            tipoDeMira = 0;
            auxScale = new Vector3(0.33f, 0.4f, 0.13f);
        }
        if (numeroPoder == 12)
        {
            tipoDeMira = 0;
            auxScale = new Vector3(0.33f, 0.18f, 2);
        }
        if (numeroPoder == 6)
        {
            tipoDeMira = 2;
        }
        if (numeroPoder == 7)
        {
            tipoDeMira = 5;
        }
        if (numeroPoder == 8)
        {
            tipoDeMira = 3;
        }
        if (numeroPoder == 9)
        {
            tipoDeMira = 4;
        }
        delay = hero.GetComponent<controleROT>().poderGeral[numeroPoder].transform.GetComponent<manaCost>().delay;
        delayAux = delay;
    }

    void Update()
    {
        delayAux += Time.deltaTime;
        //print(delayAux / delay);
        img.fillAmount = delayAux / delay;
        spriteParaNaoTrocarSkill.GetComponent<Image>().fillAmount = img.fillAmount;
        PlayerPrefs.SetFloat("delayParaPoder" + numeroDoBotao, delayAux);

    }

    public void OnPointerDown(PointerEventData data) {

        if (tipoDeMira == 0)
        {
            setaSkill.SetActive(true);
            setaSkill.transform.localScale = auxScale;

        }
        else if (tipoDeMira == 1)
        {
            esferaParaMira.SetActive(true);
            esferaParaMira.transform.localScale = auxScale;
        }
        else if (tipoDeMira == 2)
        {
            earthMira.SetActive(true);
        }
        else if (tipoDeMira == 3)
        {
            setaSwordDive.SetActive(true);
        }
        else if (tipoDeMira == 4)
        {
            setaSwordLancer.SetActive(true);
        }
        else if (tipoDeMira == 5)
        {
            setaSwordForce.SetActive(true);
        }

    }

    public void OnPointerUp(PointerEventData data) {

        if (delayAux >= delay)
        {
            hero.GetComponent<controleROT>().poder1(numeroPoder);
            delayAux = 0;

        }
        setaSkill.SetActive(false);
        esferaParaMira.SetActive(false);
        earthMira.SetActive(false);
        setaSwordDive.SetActive(false);
        setaSwordLancer.SetActive(false);
        setaSwordForce.SetActive(false);

    }

   /*     void findHero()
        {
            for (var i = 0; i < 10; i++)
            {
                hero = GameObject.FindGameObjectWithTag("heroRot");
                if (hero == null)
                {
                    i = 0;
                    
                    j++;
                }
                if(j > 10000000)
                {
                    break;
                }
            }
        }*/

    }

    