using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnRandom : MonoBehaviour {

    public GameObject monstro;
    public float rangeX, rangeZ, altura;
    public int numeroMontros;
    public bool ifRotPredef;


    // Use this for initialization
    void Start () {

        for (var i = 0; i < numeroMontros; i++)
        {
            if (ifRotPredef)
            {
                Instantiate(monstro,
                    new Vector3(transform.position.x + Random.Range(-rangeX, rangeX), altura, transform.position.z + Random.Range(-rangeZ, rangeZ)),
                    monstro.transform.rotation);
            }
            else
            {
                Instantiate(monstro,
                    new Vector3(transform.position.x + Random.Range(-rangeX, rangeX), altura, transform.position.z + Random.Range(-rangeZ, rangeZ)),
                    Quaternion.Euler(0, Random.Range(0, 360), 0));
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(transform.position.x + rangeX, altura, transform.position.z + rangeZ), new Vector3(transform.position.x - rangeX, altura, transform.position.z + rangeZ));
        Gizmos.DrawLine(new Vector3(transform.position.x + rangeX, altura, transform.position.z - rangeZ), new Vector3(transform.position.x - rangeX, altura, transform.position.z - rangeZ));
        Gizmos.DrawLine(new Vector3(transform.position.x - rangeX, altura, transform.position.z - rangeZ), new Vector3(transform.position.x - rangeX, altura, transform.position.z + rangeZ));
        Gizmos.DrawLine(new Vector3(transform.position.x + rangeX, altura, transform.position.z - rangeZ), new Vector3(transform.position.x + rangeX, altura, transform.position.z + rangeZ));
    }
}
