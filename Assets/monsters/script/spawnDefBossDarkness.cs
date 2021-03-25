using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDefBossDarkness : MonoBehaviour {

    public GameObject boss;

    GameObject auxMonst;

    public int contMonstros;
    public bool destroy, cria;
    public GameObject objDestroy, objCria;


    // Use this for initialization
    void Start()
    {

        auxMonst = Instantiate(boss, new Vector3(0, 0, 0), boss.transform.rotation) as GameObject;
        auxMonst.GetComponent<darknessBoss>().auxSpawnDef = gameObject;
        auxMonst.GetComponent<darknessBoss>().ifSpawnDef = true;
        contMonstros++;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDeathMonsters()
    {
        contMonstros--;
        if (contMonstros <= 0)
        {
            if (destroy)
            {
                Destroy(objDestroy);
            }
            if (cria)
            {
                objCria.SetActive(true);
            }
        }
    }
}
