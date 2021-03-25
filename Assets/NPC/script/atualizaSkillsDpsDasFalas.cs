using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atualizaSkillsDpsDasFalas : MonoBehaviour {

    public int skill;

	// Use this for initialization
	void Start () {

        if (skill == 2)
        {
            GameObject.FindGameObjectWithTag("heroRot").GetComponent<atualizaSkillsButtons>().atualizaButtons2();
        }
        if (skill == 3)
        {
            GameObject.FindGameObjectWithTag("heroRot").GetComponent<atualizaSkillsButtons>().atualizaButtons3();
        }
        Destroy(gameObject);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
