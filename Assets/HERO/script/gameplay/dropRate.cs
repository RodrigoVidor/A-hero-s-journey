using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropRate : MonoBehaviour {

    public int goldPor, itemPor, manaPor, vidaPor;

    public GameObject goldObj, itemObjComum, itemObjRaro, manaObj, vidaObj;

    //public string itemComum;
    public enum State
    {
        SpiderEgg, Bone, SpiderVenon, RabbitFur
    }

    public State itemComum;
    public int tipoDeItemC;
   // public string itemRaro;

    public State itemRaro;
    public int tipoDeItemR;
    public int chanceItemComum;
    public int goldQuantMin, goldQuantMax, manaQuantMin, manaQuantMax, vidaQuantMin, vidaQuantMax;
    //public float auxScale;
    float rand;
    GameObject auxDrop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void randomDrop()
    {
        rand = Random.value * 100;
        // print(rand);

        ////// gold
        if (rand < goldPor)
        {
            // print("gold");
            auxDrop = Instantiate(goldObj, transform.position, goldObj.transform.rotation) as GameObject;
            auxDrop.GetComponent<dropGeral>().quant = Random.Range(goldQuantMin, goldQuantMax);
           // auxSize.transform.localScale = new Vector3(auxScale, auxScale, auxScale);
        }

        ///////// item
        else if (rand >= goldPor && rand < (goldPor + itemPor))
        {
            //  print("item");
            
            if(Random.value * 100 <= chanceItemComum)
            {
                auxDrop = Instantiate(itemObjComum, transform.position, itemObjComum.transform.rotation) as GameObject;
                auxDrop.GetComponent<dropItem>().nomeDropItem = itemComum.ToString();
                auxDrop.GetComponent<dropItem>().tipo = tipoDeItemC;
            }
            else
            {
                auxDrop = Instantiate(itemObjRaro, transform.position, itemObjRaro.transform.rotation) as GameObject;
                auxDrop.GetComponent<dropItem>().nomeDropItem = itemRaro.ToString();
                auxDrop.GetComponent<dropItem>().tipo = tipoDeItemR;
            }
            
            // auxSize.transform.localScale = new Vector3(auxScale, auxScale, auxScale);
        }

        ////////// mana
        else if (rand >= (goldPor + itemPor) && rand < (goldPor + itemPor + manaPor))
        {
            // print("mana");
            auxDrop = Instantiate(manaObj, transform.position, manaObj.transform.rotation) as GameObject;
            auxDrop.GetComponent<dropGeral>().quant = Random.Range(manaQuantMin, manaQuantMax);
            // auxSize.transform.localScale = new Vector3(auxScale, auxScale, auxScale);
        }

        ///////// vida
        else if (rand >= (goldPor + itemPor + manaPor) && rand <= (goldPor + itemPor + manaPor + vidaPor))
        {
            // print("vida");
            auxDrop = Instantiate(vidaObj, transform.position, vidaObj.transform.rotation) as GameObject;
            auxDrop.GetComponent<dropGeral>().quant = Random.Range(vidaQuantMin, vidaQuantMax);
            //auxSize.transform.localScale = new Vector3(auxScale, auxScale, auxScale);
        }
        
    }
}
