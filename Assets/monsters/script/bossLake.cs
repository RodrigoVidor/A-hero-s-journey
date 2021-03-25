using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossLake : MonoBehaviour {


    GameObject hero, efeitoHit;
    public GameObject vidaSprite,/* auxDano,*/ mostraDanos, auxColliderPos, efeitoAtk, poder1, posParaPoder1, poder2, posParaPoder2;
    GameObject auxMostraDanos, auxEfeitoAtk, auxPoder1, auxPoder2;
    Collider col;
    Rigidbody rig;
    //public Sprite vidaSprite;
    public Animator anim;
    public float distanciaHero, distanciaHeroAttack, speed, speedRot, vida, XP, dano, danoPoder2, delayParaAtkBasico, delayParaPoder1, delayParaPoder2;
    float distanciaAux, vidaReal, scaleVida, delayAtk, delay1, delay2;
    public Vector4 localPoder1, localPoder2, localPoder3;
    RaycastHit hit;
    //bool hit;

    // Use this for initialization
    void Start()
    {

        posParaPoder2.transform.parent = null;

        posParaPoder2.transform.position = new Vector3(-810, 0.5f, -235);
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }

        //auxDano.GetComponent<danoAtaques>().dano = dano;
        col = transform.GetComponent<CapsuleCollider>();
        rig = transform.GetComponent<Rigidbody>();
        //anim.SetFloat("speedMove", speed);
        vidaReal = vida;
        scaleVida = vidaSprite.transform.localScale.x;
        auxHero();

    }

    // Update is called once per frame
    void Update()
    {
        delayAtk += Time.deltaTime;
        delay1 += Time.deltaTime;
        delay2 += Time.deltaTime;

        //distanciaAux = Vector3.Distance(hero.transform.position, transform.position);
        // if (!hit)
        // {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hero.transform.position.x, 0, hero.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z)), speedRot * Time.deltaTime);
        //  }

        if (delayAtk > delayParaAtkBasico)
        {
            AtkVoid();
        }

        if (delay1 > delayParaPoder1)
        {
            poder1void();
        }
        if (delay2 > delayParaPoder2)
        {
            poder2void();
        }


    }

    public void AtkVoid ()
    {
        anim.SetBool("attack", true);
    }

    public void actvColliderAtk()
    {
        auxEfeitoAtk = Instantiate(efeitoAtk, auxColliderPos.transform.position, auxColliderPos.transform.rotation) as GameObject;
        auxEfeitoAtk.GetComponent<danoAtaques>().dano = dano;
        auxEfeitoAtk.GetComponent<rangedAttack>().posFinal = new Vector3(hero.transform.position.x, hero.transform.position.y, hero.transform.position.z);
        anim.SetBool("attack", false);
        delayAtk = 0;
        //auxColliderPos.GetComponent<Collider>().enabled = true;
        //// auxColliderPos.GetComponent<Collider>().enabled = false;
    }

    public void poder1void ()
    {
        auxPoder1 = Instantiate(poder1, posParaPoder1.transform.position, posParaPoder1.transform.rotation) as GameObject;
        auxPoder1.GetComponent<poderCuspe>().posFinal = new Vector3(Random.Range(localPoder1.y, localPoder1.x), -5, Random.Range(localPoder1.w, localPoder1.z));

        auxPoder1 = Instantiate(poder1, posParaPoder1.transform.position, posParaPoder1.transform.rotation) as GameObject;
        auxPoder1.GetComponent<poderCuspe>().posFinal = new Vector3(Random.Range(localPoder2.y, localPoder2.x), -5, Random.Range(localPoder2.w, localPoder2.z));

        auxPoder1 = Instantiate(poder1, posParaPoder1.transform.position, posParaPoder1.transform.rotation) as GameObject;
        auxPoder1.GetComponent<poderCuspe>().posFinal = new Vector3(Random.Range(localPoder1.x, localPoder1.y), -5, Random.Range(localPoder1.z, localPoder1.w));
        delay1 = 0;
    }

    public void poder2void()
    {
        auxPoder2 = Instantiate(poder2, posParaPoder2.transform.position, Quaternion.Euler(0,Random.Range(70,105),0));
        auxPoder2.GetComponent<danoAtaques>().dano = danoPoder2;
        delay2 = 0;
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


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(new Vector3(localPoder1.x, 1, localPoder1.z), new Vector3(localPoder1.y, 1, localPoder1.z));
        Gizmos.DrawLine(new Vector3(localPoder1.x, 1, localPoder1.w), new Vector3(localPoder1.y, 1, localPoder1.w));
        Gizmos.DrawLine(new Vector3(localPoder1.y, 1, localPoder1.z), new Vector3(localPoder1.y, 1, localPoder1.w));
        Gizmos.DrawLine(new Vector3(localPoder1.x, 1, localPoder1.z), new Vector3(localPoder1.x, 1, localPoder1.w));

        Gizmos.DrawLine(new Vector3(localPoder2.x, 1, localPoder2.z), new Vector3(localPoder2.y, 1, localPoder2.z));
        Gizmos.DrawLine(new Vector3(localPoder2.x, 1, localPoder2.w), new Vector3(localPoder2.y, 1, localPoder2.w));
        Gizmos.DrawLine(new Vector3(localPoder2.y, 1, localPoder2.z), new Vector3(localPoder2.y, 1, localPoder2.w));
        Gizmos.DrawLine(new Vector3(localPoder2.x, 1, localPoder2.z), new Vector3(localPoder2.x, 1, localPoder2.w));

        Gizmos.DrawLine(new Vector3(localPoder3.x, 1, localPoder3.z), new Vector3(localPoder3.y, 1, localPoder3.z));
        Gizmos.DrawLine(new Vector3(localPoder3.x, 1, localPoder3.w), new Vector3(localPoder3.y, 1, localPoder3.w));
        Gizmos.DrawLine(new Vector3(localPoder3.y, 1, localPoder3.z), new Vector3(localPoder3.y, 1, localPoder3.w));
        Gizmos.DrawLine(new Vector3(localPoder3.x, 1, localPoder3.z), new Vector3(localPoder3.x, 1, localPoder3.w));


    }

    void dieMOTHERFUCKER()
    {
        transform.GetComponent<dropRate>().randomDrop();
        PlayerPrefs.SetInt("desativaBarreiraCaminhoCaveSecundario", 1);
        GameObject.Find("barreiraCachoeira").SetActive(false);
        vidaSprite.transform.localScale = Vector3.zero;
        anim.SetBool("die", true);
        hero.GetComponent<heroBase>().expSoma(XP);
        Destroy(col);
        Destroy(rig);
        //Destroy(auxDano.GetComponent<Collider>());
        Destroy(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "curaBossLake")
        {
            vidaReal += other.GetComponent<slimeCura>().vidaReal;
            other.GetComponent<slimeCura>().cura();
        }
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

