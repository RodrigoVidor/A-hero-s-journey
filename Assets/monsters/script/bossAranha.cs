using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAranha : MonoBehaviour {

    GameObject hero, efeitoHit;
    public GameObject vidaSprite, auxDano, mostraDanos, auxColliderPos, poderAranha1, auxPosPoderCuspe, posAtkEsquerdo, posAtkDireito, efeitoAtk, efeitoParaCuspe, gasPower;
    GameObject auxMostraDanos, auxPoderCuspe, auxAtk;
    Collider col;
    Rigidbody rig;
    //public Sprite vidaSprite;
    public Animator anim;
    public float distanciaHero, distanciaHeroAttack, speed, speedRot, vida, XP, dano, delayParaPoderCuspe, distanciaHeroPoderCuspe;
    float distanciaAux, vidaReal, scaleVida, auxDelayParaPoderCuspe, delayParaRot, delayGas;
    int auxAtkLados;
    bool poderCuspeAtivado = false;
    bool jaSaiu = false;

    public float minRangeCuspe1X, maxRangeCuspe1X, minRangeCuspe1Y, maxRangeCuspe1Y;
    public float minRangeCuspe2X, maxRangeCuspe2X, minRangeCuspe2Y, maxRangeCuspe2Y;
    public float minRangeCuspe3X, maxRangeCuspe3X, minRangeCuspe3Y, maxRangeCuspe3Y;

    //bool hit;

    // Use this for initialization
    void Start()
    {

      //  auxDano.GetComponent<danoAtaques>().dano = dano;
        col = transform.GetComponent<CapsuleCollider>();
        rig = transform.GetComponent<Rigidbody>();
        anim.SetFloat("speedMove", speed);
        vidaReal = vida;
        scaleVida = vidaSprite.transform.localScale.x;
       // auxHero();

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
        if (jaSaiu)
        {
            delayGas += Time.deltaTime;
            if (delayGas > 3)
            {
                jaSaiu = false;
            }
        }
        else
        {
            if(poderCuspeAtivado == false)
            {
                if (distanciaAux < 7)
                {
                    gas();
                }
            }
        }
        auxDelayParaPoderCuspe += Time.deltaTime;
        if (auxAtkLados == 2 && poderCuspeAtivado == false)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(hero.transform.position - transform.position), speedRot * Time.deltaTime);
            delayParaRot += Time.deltaTime;
            if(delayParaRot >= 4)
            {
                auxAtkLados = 0;
            }
        }
        distanciaAux = Vector3.Distance(hero.transform.position, transform.position);
        // if (!hit)
        // {
        if (distanciaAux < distanciaHero && distanciaAux >= distanciaHeroAttack && poderCuspeAtivado == false)
        {
            anim.SetBool("move", true);
            anim.SetBool("idle", false);
            anim.SetBool("attackDireita", false);
            anim.SetBool("attackEsquerda", false);
            anim.SetBool("attack", false);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(hero.transform.position - transform.position), speedRot * Time.deltaTime);
        }
        else if (distanciaAux < distanciaHeroAttack && auxAtkLados == 2 && poderCuspeAtivado == false)
        {
            anim.SetBool("move", false);
            anim.SetBool("idle", true);
        }
        else if (distanciaAux < distanciaHeroAttack && auxAtkLados == 0 && poderCuspeAtivado == false)
        {
            // print(Random.value);

            anim.SetBool("move", false);
            anim.SetBool("idle", true);
            //teste = Random.value;
            //print(teste);
            if (Random.value <= 0.5f)
            {
                anim.SetBool("attackEsquerda", true);
                auxAtkLados = 1;
            }
            else
            {
                anim.SetBool("attackDireita", true);
                auxAtkLados = 1;
            }
            //anim.SetBool("attack", true);
          // transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(hero.transform.position - transform.position), speed * Time.deltaTime);
        }
      /*  else if (distanciaAux >= distanciaHero)
        {
            anim.SetBool("move", false);
            anim.SetBool("attack", false);
            anim.SetBool("attackDireita", false);
            anim.SetBool("attackEsquerda", false);
        }*/
        //  }

        if(auxDelayParaPoderCuspe > delayParaPoderCuspe * 0.5f)
        {
            efeitoParaCuspe.SetActive(true);
            if (auxDelayParaPoderCuspe > delayParaPoderCuspe)
            {
                poderCuspeAtivado = true;
                anim.SetBool("move", false);
                anim.SetBool("attack", false);
                anim.SetBool("attackDireita", false);
                anim.SetBool("attackEsquerda", false);
                anim.SetBool("run", false);
                poderAranhaCuspe();
                anim.SetBool("poderCuspe", true);
                auxDelayParaPoderCuspe = 0;
                /* if (Vector3.Distance(new Vector3(291, -0.5f, -90), transform.position) > 5)
                 {
                     transform.Translate(Vector3.forward * speed * 6 * Time.deltaTime);
                     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(291, -0.5f, -90) - transform.position), speed * 3 * Time.deltaTime);
                     anim.SetBool("move", false);
                     anim.SetBool("attack", false);
                     anim.SetBool("attackDireita", false);
                     anim.SetBool("attackEsquerda", false);
                     anim.SetBool("run", true);
                 }
                 else
                 {
                     anim.SetBool("run", false);
                     transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(291, -0.5f, -150) - transform.position), speed * 3 * Time.deltaTime);


                     if (distanciaAux < distanciaHeroPoderCuspe && auxDelayParaPoderCuspe > delayParaPoderCuspe * 1.4f)
                     {
                         poderAranhaCuspe();
                         auxDelayParaPoderCuspe = 0;
                     }
                 }*/
            }
        }

        else if (auxDelayParaPoderCuspe > 6)
        {
            anim.SetBool("poderCuspe", false);
            poderCuspeAtivado = false;
        }



    }

    public void gas()
    {
        if (!jaSaiu)
        {
            Instantiate(gasPower, transform.position, gasPower.transform.rotation);
            jaSaiu = true;
        }
    }

    public void poderAranhaCuspe()
    {
        auxPoderCuspe = Instantiate(poderAranha1, auxPosPoderCuspe.transform.position, auxPosPoderCuspe.transform.rotation) as GameObject;
        auxPoderCuspe.GetComponent<poderCuspe>().posFinal = new Vector3(Random.Range(minRangeCuspe1X, maxRangeCuspe1X), -5, Random.Range(minRangeCuspe1Y, maxRangeCuspe1Y));
        Invoke("poderAranhaCuspe1", 0.5f);
    }
    public void poderAranhaCuspe1()
    {
        auxPoderCuspe = Instantiate(poderAranha1, auxPosPoderCuspe.transform.position, auxPosPoderCuspe.transform.rotation) as GameObject;
        auxPoderCuspe.GetComponent<poderCuspe>().posFinal = new Vector3(Random.Range(minRangeCuspe2X, maxRangeCuspe2X), -5, Random.Range(minRangeCuspe2Y, maxRangeCuspe2Y));
        Invoke("poderAranhaCuspe2", 0.5f);
    }
    public void poderAranhaCuspe2()
    {
        auxPoderCuspe = Instantiate(poderAranha1, auxPosPoderCuspe.transform.position, auxPosPoderCuspe.transform.rotation) as GameObject;
        auxPoderCuspe.GetComponent<poderCuspe>().posFinal = new Vector3(Random.Range(minRangeCuspe3X, maxRangeCuspe3X), -5, Random.Range(minRangeCuspe3Y, maxRangeCuspe3Y));
        efeitoParaCuspe.SetActive(false);
        auxDelayParaPoderCuspe = 0;
        //poderCuspeAtivado = false;
    }

    public void miraHeroDpsAtk ()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(hero.transform.position - transform.position), 20 * Time.deltaTime);
        anim.SetBool("attackDireita", false);
        anim.SetBool("attackEsquerda", false);
        delayParaRot = 0;
        auxAtkLados = 2;
        //auxAtkLados = false;
    }

    public void instAtkEsquerdo ()
    {
        auxAtk = Instantiate(efeitoAtk, posAtkEsquerdo.transform.position, posAtkEsquerdo.transform.rotation) as GameObject;
        auxAtk.GetComponent<danoAtaques>().dano = dano;
    }

    public void instAtkDireito()
    {
        auxAtk =  Instantiate(efeitoAtk, posAtkDireito.transform.position, posAtkDireito.transform.rotation) as GameObject;
        auxAtk.GetComponent<danoAtaques>().dano = dano;
    }

    public void actvColliderAtk()
    {
        auxColliderPos.GetComponent<Collider>().enabled = true;
        // auxColliderPos.GetComponent<Collider>().enabled = false;
    }

    public void desactvColliderAtk()
    {
        //auxColliderPos.GetComponent<Collider>().enabled = true;
        auxColliderPos.GetComponent<Collider>().enabled = false;
    }


    void OnDrawGizmosSelected()
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


    }

    void dieMOTHERFUCKER()
    {
        transform.GetComponent<dropRate>().randomDrop();
        vidaSprite.transform.localScale = Vector3.zero;
        anim.SetBool("die", true);
        hero.GetComponent<heroBase>().expSoma(XP);
        Destroy(col);
        Destroy(rig);
        Destroy(auxDano.GetComponent<Collider>());
        PlayerPrefs.SetInt("teiasAranhaVerde", 1);
        PlayerPrefs.SetInt("removeTeiasBossAranha", 1);
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

            anim.SetTrigger("hit");
            vidaSprite.transform.localScale = new Vector3((scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.y, vidaSprite.transform.localScale.z);
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

            anim.SetTrigger("hit");
            vidaSprite.transform.localScale = new Vector3((scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.y, vidaSprite.transform.localScale.z);
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

            anim.SetTrigger("hit");
            vidaSprite.transform.localScale = new Vector3((scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.y, vidaSprite.transform.localScale.z);
            if (vidaReal <= 0)
            {
                dieMOTHERFUCKER();
            }
        }

    }
}
