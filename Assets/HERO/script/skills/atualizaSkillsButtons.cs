using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atualizaSkillsButtons : MonoBehaviour {

    public GameObject buttonSkill2, fundoSkill2, buttonsSelectSkill2;
    public GameObject buttonSkill3, fundoSkill3, buttonsSelectSkill3;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void atualizaButtons2()
    {
        buttonSkill2.GetComponent<ativaBotaoSkillPorVar>().atualizaButton();
        fundoSkill2.GetComponent<ativaBotaoSkillPorVar>().atualizaButton();
        buttonsSelectSkill2.GetComponent<ativaSelecaoSkillPorVar>().atualizaButton();
    }
    public void atualizaButtons3()
    {
        buttonSkill3.GetComponent<ativaBotaoSkillPorVar>().atualizaButton();
        fundoSkill3.GetComponent<ativaBotaoSkillPorVar>().atualizaButton();
        buttonsSelectSkill3.GetComponent<ativaSelecaoSkillPorVar>().atualizaButton();
    }
}
