using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class darknessBoss : MonoBehaviour {

    GameObject hero, efeitoHit;
    public GameObject vidaSprite, mostraDanos, auxColliderPos, auxSpawnDef, poderDarknessLaserObj, posInstLaser, poderDarknessLaserCircularObj, posInstLaserCircular, poderDarknessPilarObj;
    GameObject auxMostraDanos, auxPoder1;
    Collider col;
    Rigidbody rig;
    //public Sprite vidaSprite;
    public float distanciaHero, vida, XP, delayParaPoder, distanciaPoderPerto, auxPosVida;
    float distanciaAux, vidaReal, scaleVida, auxDelayParaPoder, auxRandomPower;
    public bool algumPoderAtivado = false;
    int auxContPilar;
    public bool ifSpawnDef;
    


    // public float minRangeCuspe1X, maxRangeCuspe1X, minRangeCuspe1Y, maxRangeCuspe1Y;
    //  public float minRangeCuspe2X, maxRangeCuspe2X, minRangeCuspe2Y, maxRangeCuspe2Y;
    //  public float minRangeCuspe3X, maxRangeCuspe3X, minRangeCuspe3Y, maxRangeCuspe3Y;

    //bool hit;

    // Use this for initialization
    void Start()
    {

        //  auxDano.GetComponent<danoAtaques>().dano = dano;
        col = transform.GetComponent<CapsuleCollider>();
        rig = transform.GetComponent<Rigidbody>();
        vidaReal = vida;
        scaleVida = vidaSprite.transform.localScale.x;
        // auxHero();
        auxPosVida = vidaSprite.transform.localPosition.y;

    }

    void auxHero()
    {
        for (var i = 0; i < 10; i++)
        {
            hero = GameObject.FindGameObjectWithTag("hero");
            if (hero == null)
            {
                i = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hero == null)
        {
            hero = GameObject.FindGameObjectWithTag("hero");
        }

        if (algumPoderAtivado == false)
        {
            auxDelayParaPoder += Time.deltaTime;
        }

        distanciaAux = Vector3.Distance(hero.transform.position, transform.position);

        if (auxDelayParaPoder > delayParaPoder)
        {
            auxRandomPower = Random.value;
            // if (distanciaAux < distanciaPoderPerto)
            // {
            if (auxRandomPower <= 0.3f)
                {
                    algumPoderAtivado = true;
                    poderDarknessLaser();
                    auxDelayParaPoder = 0;
                }
            else if (auxRandomPower <= 0.6f)
                {
                    algumPoderAtivado = true;
                    poderDarknessLaserCircular();
                    auxDelayParaPoder = 0;
            }

            // }
            // else
            // {
            else 
                {
                    algumPoderAtivado = true;
                    poderDarknessPilar();
                    auxDelayParaPoder = 0;
                    auxContPilar = 5;
                }

            //  }

        }

    }


    public void poderDarknessLaser()
    {
        auxPoder1 = Instantiate(poderDarknessLaserObj, posInstLaser.transform.position, poderDarknessLaserObj.transform.rotation) as GameObject;
        auxPoder1.GetComponent<destroyPoderDarkness>().boss = gameObject;
    }

    public void poderDarknessLaserCircular()
    {
        auxPoder1 = Instantiate(poderDarknessLaserCircularObj, posInstLaserCircular.transform.position, poderDarknessLaserCircularObj.transform.rotation) as GameObject;
        auxPoder1.GetComponent<destroyPoderDarkness>().boss = gameObject;
    }

    public void poderDarknessPilar()
    {
        if (auxContPilar > 0)
        {
            auxPoder1 = Instantiate(poderDarknessPilarObj, hero.transform.position, poderDarknessPilarObj.transform.rotation) as GameObject;
            auxContPilar -= 1;
            Invoke("poderDarknessPilar", 1);
        }
        else
        {
            algumPoderAtivado = false;
        }
    }




    /* void OnDrawGizmosSelected()
     {
         Gizmos.color = Color.blue;

         Gizmos.DrawLine(new Vector3(maxRangeCuspe1X, 1, maxRangeCuspe1Y), new Vector3(minRangeCuspe1X, 1, maxRangeCuspe1Y));
         Gizmos.DrawLine(new Vector3(maxRangeCuspe1X, 1, minRangeCuspe1Y), new Vector3(minRangeCuspe1X, 1, minRangeCuspe1Y));
         Gizmos.DrawLine(new Vector3(minRangeCuspe1X, 1, minRangeCuspe1Y), new Vector3(minRangeCuspe1X, 1, maxRangeCuspe1Y));
         Gizmos.DrawLine(new Vector3(maxRangeCuspe1X, 1, minRangeCuspe1Y), new Vector3(maxRangeCuspe1X, 1, maxRangeCuspe1Y));

         Gizmos.color = Color.yellow;

         Gizmos.DrawLine(new Vector3(maxRangeCuspe2X, 1, maxRangeCuspe2Y), new Vector3(minRangeCuspe2X, 1, maxRangeCuspe2Y));
         Gizmos.DrawLine(new Vector3(maxRangeCuspe2X, 1, minRangeCuspe2Y), new Vector3(minRangeCuspe2X, 1, minRangeCuspe2Y));
         Gizmos.DrawLine(new Vector3(minRangeCuspe2X, 1, minRangeCuspe2Y), new Vector3(minRangeCuspe2X, 1, maxRangeCuspe2Y));
         Gizmos.DrawLine(new Vector3(maxRangeCuspe2X, 1, minRangeCuspe2Y), new Vector3(maxRangeCuspe2X, 1, maxRangeCuspe2Y));

         Gizmos.color = Color.red;

         Gizmos.DrawLine(new Vector3(maxRangeCuspe3X, 1, maxRangeCuspe3Y), new Vector3(minRangeCuspe3X, 1, maxRangeCuspe3Y));
         Gizmos.DrawLine(new Vector3(maxRangeCuspe3X, 1, minRangeCuspe3Y), new Vector3(minRangeCuspe3X, 1, minRangeCuspe3Y));
         Gizmos.DrawLine(new Vector3(minRangeCuspe3X, 1, minRangeCuspe3Y), new Vector3(minRangeCuspe3X, 1, maxRangeCuspe3Y));
         Gizmos.DrawLine(new Vector3(maxRangeCuspe3X, 1, minRangeCuspe3Y), new Vector3(maxRangeCuspe3X, 1, maxRangeCuspe3Y));


     }*/

    void dieMOTHERFUCKER()
    {

        if (ifSpawnDef)
        {
            auxSpawnDef.GetComponent<spawnDefBossDarkness>().OnDeathMonsters();
        }
        transform.GetComponent<dropRate>().randomDrop();
        vidaSprite.transform.localScale = Vector3.zero;
        hero.GetComponent<heroBase>().expSoma(XP);
        Destroy(col);
        Destroy(rig);
        Destroy(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hitHero")
        {
            //hit = true;
            efeitoHit = other.GetComponent<danoAtkHero>().efeito;
            Instantiate(efeitoHit, transform.position, transform.rotation);
            vidaReal -= other.GetComponent<danoAtkHero>().dano;

            auxMostraDanos = Instantiate(mostraDanos, transform.position, mostraDanos.transform.rotation) as GameObject;
            auxMostraDanos.GetComponent<auxMostraDanos>().restoText(other.GetComponent<danoAtkHero>().dano);

            vidaSprite.transform.localScale = new Vector3(vidaSprite.transform.localScale.x, (scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.z);
            if (vidaReal <= 0)
            {
                dieMOTHERFUCKER();
            }
        }
        if (other.tag == "hitHeroMag")
        {
            //hit = true;
            efeitoHit = other.GetComponent<danoMagHero>().efeito;
            Instantiate(efeitoHit, transform.position, transform.rotation);
            vidaReal -= other.GetComponent<danoMagHero>().dano;

            auxMostraDanos = Instantiate(mostraDanos, transform.position, mostraDanos.transform.rotation) as GameObject;
            auxMostraDanos.GetComponent<auxMostraDanos>().danos.color = new Color(0.93f, 0, 1);
            auxMostraDanos.GetComponent<auxMostraDanos>().restoText(other.GetComponent<danoMagHero>().dano);

            vidaSprite.transform.localScale = new Vector3(vidaSprite.transform.localScale.x, (scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.z);
            // vidaSprite.transform.localPosition = new Vector3(vidaSprite.transform.localPosition.x, (auxPosVida * vidaReal) / vida, vidaSprite.transform.localPosition.z);
            if (vidaReal <= 0)
            {
                dieMOTHERFUCKER();
            }
        }

        if (other.tag == "hitHeroMagStr")
        {
            //hit = true;
            efeitoHit = other.GetComponent<danoMagStrHero>().efeito;
            Instantiate(efeitoHit, transform.position, transform.rotation);
            vidaReal -= other.GetComponent<danoMagStrHero>().dano;

            auxMostraDanos = Instantiate(mostraDanos, transform.position, mostraDanos.transform.rotation) as GameObject;
            auxMostraDanos.GetComponent<auxMostraDanos>().danos.color = new Color(1, 0.53f, 0);
            auxMostraDanos.GetComponent<auxMostraDanos>().restoText(other.GetComponent<danoMagStrHero>().dano);

            vidaSprite.transform.localScale = new Vector3(vidaSprite.transform.localScale.x, (scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.z);
            if (vidaReal <= 0)
            {
                dieMOTHERFUCKER();
            }
        }

    }
}
