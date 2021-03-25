using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillQueMoveHero : MonoBehaviour {

    public static bool algumPowerQueMovimenta;
    public float delayToDestroy;
    public GameObject[] efeitosParaTirarDoParent;
    float delay;
    GameObject hero;
    int i;

    // Use this for initialization
    void Start () {

        algumPowerQueMovimenta = true;
        hero = GameObject.FindGameObjectWithTag("hero");
        

    }
	
	// Update is called once per frame
	void Update () {

        hero.transform.position = transform.position;
        hero.transform.GetChild(0).localPosition = Vector3.zero;
        delay += Time.deltaTime;
        if(delay >= delayToDestroy)
        {
            for(i = 0; i < efeitosParaTirarDoParent.Length; i++)
            {
                efeitosParaTirarDoParent[i].transform.parent = null;
            }
            algumPowerQueMovimenta = false;
            Destroy(transform.parent.gameObject);
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "hero" && other.tag != "hitHero")
        {
            for (i = 0; i < efeitosParaTirarDoParent.Length; i++)
            {
                efeitosParaTirarDoParent[i].transform.parent = null;
            }
            algumPowerQueMovimenta = false;
            Destroy(transform.parent.gameObject);
        }
    }
}
