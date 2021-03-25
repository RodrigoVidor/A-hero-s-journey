using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterGeral : MonoBehaviour {

    public bool ifRanged, ifMissionMonster, ifDestroiBody, ifSpawnDef, agressive, semMoveAleatorio;
    bool agressiveAux, moveSpeedAux;
    GameObject hero, efeitoHit;
    public GameObject vidaSprite, modoSprite,/* auxDano,*/ mostraDanos, auxColliderPos, efeitoAtk, efeitoDestroy, auxSpawnDef, agressivaOBJ;
    GameObject auxMostraDanos, auxEfeitoAtk;
    Collider col;
    Rigidbody rig;
    //public Sprite vidaSprite;
    public Animator anim;
    public float distanciaHero, distanciaHeroAttack, speed, speedRot, vida, XP, dano;
    float distanciaAux, vidaReal, scaleVida, delayPassive, delayPassiveAux, auxPosFinal;
    RaycastHit hit;
    Vector3 posInit, newPos;
    public float distanciaParaMove;
    
    //bool hit;

    // Use this for initialization
    void Start () {


        if(agressive)
        {
            modoSprite.GetComponent<SpriteRenderer>().color = Color.red;
            agressiveAux = true;
        }

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
        posInit = transform.position;
        delayPassive = 2 + Random.value * 3;

        //newPos = posInit;
        newPos = new Vector3(Random.Range(posInit.x - distanciaParaMove, posInit.x + distanciaParaMove), 0, Random.Range(posInit.z - distanciaParaMove, posInit.z + distanciaParaMove));

    }
	
	// Update is called once per frame
	void Update () {

        if (agressive)
        {
            
            distanciaAux = Vector3.Distance(hero.transform.position, transform.position);
            // if (!hit)
            // {
            if (distanciaAux < distanciaHero && distanciaAux >= distanciaHeroAttack)
            {
                if (speed > 0 && moveSpeedAux == false)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                   
                }
                anim.SetBool("move", true);
                anim.SetBool("attack", false);
                if (moveSpeedAux == false)
                {
                    
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hero.transform.position.x, 0, hero.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z)), speedRot * Time.deltaTime);
                }
            }
            else if (distanciaAux < distanciaHeroAttack)
            {
                if (speed > 0 && moveSpeedAux == false)
                {
                    transform.Translate(Vector3.forward * speed * Time.deltaTime);
                }
                anim.SetBool("move", false);
                anim.SetBool("attack", true);
                if (moveSpeedAux == false)
                {
                    
                    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hero.transform.position.x, 0, hero.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z)), speedRot * Time.deltaTime);
                }
                
            }
            else
            {
                anim.SetBool("move", false);
                anim.SetBool("attack", false);
                if (!agressiveAux)
                {
                    agressive = false;
                    modoSprite.GetComponent<SpriteRenderer>().color = Color.yellow;
                    delayPassiveAux = 0;
                    delayPassive = Random.value * 4;
                }
            }
            //  }
        }

        else if (semMoveAleatorio == false)
        {
            if (Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z), new Vector3(newPos.x, 0, newPos.z)) < 1) 
            {
                delayPassiveAux += Time.deltaTime;
                anim.SetBool("move", false);
            }
            else
            {
                anim.SetBool("move", true);
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
            // if ((newPos - new Vector3(transform.position.x, 0, transform.position.z)) != Vector3.zero)
            // {

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(newPos - new Vector3(transform.position.x, 0, transform.position.z)), speedRot * Time.deltaTime);
            // } 

            if (delayPassiveAux >= delayPassive)
            {
                print("3");
                anim.SetBool("move", true);
                delayPassiveAux = 0;
                delayPassive = 1 + Random.value * 4;
                newPos = new Vector3(Random.Range(posInit.x - distanciaParaMove, posInit.x + distanciaParaMove), 0, Random.Range(posInit.z - distanciaParaMove, posInit.z + distanciaParaMove));
                
            }
        }


    }

    public void tiraMoveSpeed ()
    {
        moveSpeedAux = true;
    }

    public void voltaMoveSpeed()
    {
        moveSpeedAux = false;
    }

    public void actvColliderAtk ()
    {
        auxEfeitoAtk = Instantiate(efeitoAtk, auxColliderPos.transform.position, auxColliderPos.transform.rotation) as GameObject;
        auxEfeitoAtk.GetComponent<danoAtaques>().dano = dano;
        if (ifRanged)
        {
            auxEfeitoAtk.GetComponent<rangedAttack>().posFinal = hero.transform.position;
        }
        //auxColliderPos.GetComponent<Collider>().enabled = true;
        //// auxColliderPos.GetComponent<Collider>().enabled = false;
    }

    public void desactvColliderAtk()
    {
        ////auxColliderPos.GetComponent<Collider>().enabled = true;
       // auxColliderPos.GetComponent<Collider>().enabled = false;
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

    void dieMOTHERFUCKER()
    {
        if (ifMissionMonster)
        {
            auxParaVoltaDasMissoes.quantParaVoltar++;
        }
        else
        {
            transform.GetComponent<dropRate>().randomDrop();
        }

        if(ifSpawnDef)
        {
            auxSpawnDef.GetComponent<spawnDef>().OnDeathMonsters();
        }
        
        vidaSprite.transform.localScale = Vector3.zero;
        modoSprite.transform.localScale = Vector3.zero;
        anim.SetBool("die", true);
        hero.GetComponent<heroBase>().expSoma(XP);
        Destroy(col);
        Destroy(rig);
        //Destroy(auxDano.GetComponent<Collider>());
        if(ifDestroiBody)
        {
            Instantiate(efeitoDestroy, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
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
            modoSprite.transform.localScale = new Vector3((scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.y, vidaSprite.transform.localScale.z);

            agressive = true;
            modoSprite.GetComponent<SpriteRenderer>().color = Color.red;
            Instantiate(agressivaOBJ, transform.position, transform.rotation);

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

            //rig.AddForce(0, 0, 100, ForceMode.Impulse);

            anim.SetTrigger("hit");
            vidaSprite.transform.localScale = new Vector3((scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.y, vidaSprite.transform.localScale.z);
            modoSprite.transform.localScale = new Vector3((scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.y, vidaSprite.transform.localScale.z);

            agressive = true;
            modoSprite.GetComponent<SpriteRenderer>().color = Color.red;
            Instantiate(agressivaOBJ, transform.position, transform.rotation);

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
            modoSprite.transform.localScale = new Vector3((scaleVida * vidaReal) / vida, vidaSprite.transform.localScale.y, vidaSprite.transform.localScale.z);

            agressive = true;
            modoSprite.GetComponent<SpriteRenderer>().color = Color.red;
            Instantiate(agressivaOBJ, transform.position, transform.rotation);

            if (vidaReal <= 0)
            {
                dieMOTHERFUCKER();
            }
        }
        if (!agressive)
        {
            if (other.tag == "AGRESSIVATODOMUNDONESSAPORRA")
            {
                agressive = true;
                modoSprite.GetComponent<SpriteRenderer>().color = Color.red;

            }
        }

    }

}
