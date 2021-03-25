using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBarrier : MonoBehaviour {

    public float delay;
    float delayAux;
    Transform hero;

    // Use this for initialization
    void Start()
    {

        hero = GameObject.FindGameObjectWithTag("hero").transform;
        transform.parent = hero.transform;
        hero.GetComponent<controleMOB>().iceBarrierSkill = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {

        delayAux += Time.deltaTime;

        if(delayAux >= delay)
        {
            hero.GetComponent<controleMOB>().iceBarrierSkill = 1;
            Destroy(gameObject);
        }
		
	}
}
