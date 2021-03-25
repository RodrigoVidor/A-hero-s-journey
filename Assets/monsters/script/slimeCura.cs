using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeCura : MonoBehaviour {

    public Animator anim;

    GameObject efeitoHit;
    public GameObject vidaSprite,/* auxDano,*/ mostraDanos;
    GameObject auxMostraDanos;
    public float speed, vida, vidaReal;
    float scaleVida;
    Vector3 posBoss;

	// Use this for initialization
	void Start () {

        posBoss = GameObject.FindGameObjectWithTag("bossLake").transform.position;
        posBoss.y = 0;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(0, 0, speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(posBoss - transform.position), 5 * Time.deltaTime);

    }
    void dieMOTHERFUCKER()
    {
        transform.GetComponent<dropRate>().randomDrop();
        vidaSprite.transform.localScale = Vector3.zero;
        anim.SetBool("die", true);
       // hero.GetComponent<heroBase>().expSoma(XP);
      //  Destroy(col);
       // Destroy(rig);
        //Destroy(auxDano.GetComponent<Collider>());
        Destroy(this);
    }

    public void cura()
    {
        //transform.GetComponent<dropRate>().randomDrop();
        //vidaSprite.transform.localScale = Vector3.zero;
        //anim.SetBool("die", true);
        // hero.GetComponent<heroBase>().expSoma(XP);
        //  Destroy(col);
        // Destroy(rig);
        //Destroy(auxDano.GetComponent<Collider>());
        Destroy(gameObject);
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
