using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItem : MonoBehaviour {

    public int tipo; // 0 = weapon // 1 = armor // 2 = consum // 3 = material // 4 = quest
    public string nomeDropItem;
    
    //public int quant;
    public GameObject efeito, auxPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void instEfeito()
    {
        Instantiate(efeito, auxPos.transform.position, Quaternion.identity);
    }
}
