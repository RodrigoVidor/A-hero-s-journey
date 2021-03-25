using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativaSkill : MonoBehaviour {

    public Sprite[] sprites;
    public int numeroDaSkill;
    public Image spriteFundo;

    // Use this for initialization
    void Start()
    {

        transform.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("skill" + numeroDaSkill)];
        //print(numeroDaSkill);
        spriteFundo.sprite = transform.GetComponent<Image>().sprite;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void atualizaSpriteSkills ()
    {

        transform.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("skill" + numeroDaSkill)];
        spriteFundo.sprite = transform.GetComponent<Image>().sprite;

    }
}
