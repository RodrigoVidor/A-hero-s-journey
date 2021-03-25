using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDef : MonoBehaviour {

    public GameObject[] monstro;
    public float altura;
    public Vector2[] posInst;
    //public int numeroMontros;
    public bool ifRotPredef, executaUmaVez, executaCriaDestroyMesmoSemMatar;
    public string varParaExecutarUmaVez;

    GameObject auxMonst;

    public int contMonstros;
    public bool destroy, cria;
    public GameObject objDestroy, objCria;


    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.GetInt(varParaExecutarUmaVez) == 0)
        {
            for (var i = 0; i < monstro.Length; i++)
            {
                if (ifRotPredef)
                {
                    auxMonst = Instantiate(monstro[i],
                        new Vector3(transform.position.x + posInst[i].x, altura, transform.position.z + posInst[i].y),
                        monstro[i].transform.rotation) as GameObject;
                    auxMonst.GetComponent<monsterGeral>().auxSpawnDef = gameObject;
                    auxMonst.GetComponent<monsterGeral>().ifSpawnDef = true;
                    contMonstros++;
                }
                else
                {
                    auxMonst = Instantiate(monstro[i],
                        new Vector3(transform.position.x + posInst[i].x, altura, transform.position.z + posInst[i].y),
                        Quaternion.Euler(0, Random.Range(0, 360), 0)) as GameObject;
                    auxMonst.GetComponent<monsterGeral>().auxSpawnDef = gameObject;
                    auxMonst.GetComponent<monsterGeral>().ifSpawnDef = true;
                    contMonstros++;
                }
            }
        }
        else if (executaCriaDestroyMesmoSemMatar)
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

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDeathMonsters()
    {
        contMonstros--;
        if(contMonstros <= 0)
        {
            if(destroy)
            {
                Destroy(objDestroy);
            }
            if(cria)
            {
                objCria.SetActive(true);
            }
            if(executaUmaVez)
            {
                PlayerPrefs.SetInt(varParaExecutarUmaVez,1);
            }
        }
    }

   
}
