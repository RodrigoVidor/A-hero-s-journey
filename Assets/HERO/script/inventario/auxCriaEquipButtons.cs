using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class auxCriaEquipButtons : MonoBehaviour {

    public GameObject buttonSlotConsum;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void equipConsum()
    {
        //Instantiate(buttonSlotConsum, transform.position, Quaternion.identity);
        buttonSlotConsum.SetActive(true);
    }

    public void backConsum()
    {
        buttonSlotConsum.SetActive(false);
    }
}
