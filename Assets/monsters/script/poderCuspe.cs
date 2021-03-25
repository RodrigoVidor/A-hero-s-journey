using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poderCuspe : MonoBehaviour {

    public GameObject efeitoChao, efeitoExplosao;
    public Vector3 posFinal;
    public float speedRot, speedMov;
    public ParticleSystem efeito;
    
	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void Update () {

        //transform.position = Vector3.Lerp(transform.position, posFinal, speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(posFinal - transform.position), speedRot * Time.deltaTime);
        transform.Translate(0, 0, speedMov * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "chao")
        {
            Instantiate(efeitoExplosao, transform.position, efeitoExplosao.transform.rotation);
            Instantiate(efeitoChao, transform.position, efeitoChao.transform.rotation);
            Invoke("destroyEfeito", 3);
            posFinal = new Vector3(transform.position.x, -20,transform.position.z);
            speedRot = 50;
        }
    }

    void destroyEfeito()
    {
        Destroy(gameObject);
    }
}
