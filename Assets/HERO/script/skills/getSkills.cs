using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getSkills : MonoBehaviour {

    public Sprite[] sprites;
    public int numeroDaSkill;
    public GameObject buttonSkill;
    public bool passive;

	// Use this for initialization
	void Start () {

        transform.GetComponent<Image>().sprite = sprites[PlayerPrefs.GetInt("skill"+ numeroDaSkill)];
        buttonSkill.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
        buttonSkill.GetComponent<buttons>().numeroPoder = PlayerPrefs.GetInt("skill" + numeroDaSkill);

        gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cancelSkill ()
    {
        if (transform.GetComponent<Image>().fillAmount == 1)
        {
            PlayerPrefs.SetInt("skill" + numeroDaSkill, 0);
            transform.GetComponent<Image>().sprite = sprites[0];
            buttonSkill.GetComponent<Image>().sprite = sprites[0];
            buttonSkill.GetComponent<buttons>().numeroPoder = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "skill")
        {
            if (transform.GetComponent<Image>().fillAmount == 1)
            {
                transform.GetComponent<Image>().sprite = other.transform.GetComponent<Image>().sprite;
                buttonSkill.GetComponent<Image>().sprite = transform.GetComponent<Image>().sprite;
                PlayerPrefs.SetInt("skill" + numeroDaSkill, other.transform.GetComponent<selectSkills>().numeroSkill);
                // buttonSkill.GetComponent<buttons>().numeroPoder = PlayerPrefs.GetInt("skill" + numeroDaSkill);
                buttonSkill.GetComponent<buttons>().atualizaMira(PlayerPrefs.GetInt("skill" + numeroDaSkill));
            }
        }
    }
}
