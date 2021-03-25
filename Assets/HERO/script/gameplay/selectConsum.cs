using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectConsum : MonoBehaviour {

    public GameObject[] sprite;
    public int numeroDoConsum;
    public GameObject buttonQueAtiva, outroBotaoPot;
    public string nomeAtualDoConsum;

    // Use this for initialization
    void Start () {

        nomeAtualDoConsum = PlayerPrefs.GetString("consum" + numeroDoConsum);

        for (var i = 0; i < sprite.Length; i++)
        {
            if (nomeAtualDoConsum == sprite[i].name)
            {
                transform.GetComponent<Image>().sprite = sprite[i].GetComponent<spriteWeapon>().spriteDessaArma; 
            }
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void tiraPotComMesmoNome ()
    {
        nomeAtualDoConsum = "semPot";
        transform.GetComponent<Image>().sprite = sprite[0].GetComponent<spriteWeapon>().spriteDessaArma;
        PlayerPrefs.SetString("consum" + buttonQueAtiva.GetComponent<ativaConsum>().consumNumero, nomeAtualDoConsum);
        buttonQueAtiva.GetComponent<ativaConsum>().definePot(nomeAtualDoConsum);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (dragWeapon.movendo == true)
        {
            if (other.transform.tag == "POT")
            {
                nomeAtualDoConsum = other.GetComponent<dragWeapon>().nomeDoItem;
                transform.GetComponent<Image>().sprite = other.GetComponent<auxImagenWeapon>().imagenDaArma;
                PlayerPrefs.SetString("consum" + buttonQueAtiva.GetComponent<ativaConsum>().consumNumero, nomeAtualDoConsum);
                buttonQueAtiva.GetComponent<ativaConsum>().definePot(nomeAtualDoConsum);
                
                if (outroBotaoPot.GetComponent<selectConsum>().nomeAtualDoConsum == nomeAtualDoConsum)
                {
                    outroBotaoPot.GetComponent<selectConsum>().tiraPotComMesmoNome();
                }

            }
        }
    }
}
