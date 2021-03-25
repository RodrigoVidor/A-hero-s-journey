using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ativaConsum : MonoBehaviour {

    public GameObject[] sprite;
    public GameObject[] auxCura;
    public GameObject hero, buttonQueSeleciona;
    public int consumNumero;
    public float porcRecup;
    int posAuxCura, cont, uuu;
    public int[] posTodasAsPot;
    public string nomeAtualDoConsum;
    public string[] auxNomeDasArmas;

	// Use this for initialization
	void Start () {

        // Use this for initialization  PlayerPrefs.SetString("consum" + consumNumero, "semPot");

        for (var i = 0; i < 30; i++)
        {
            auxNomeDasArmas[i] = PlayerPrefs.GetString("listaDasArmas" + i);
        }

            nomeAtualDoConsum = PlayerPrefs.GetString("consum" + consumNumero);

        for (var i = 0; i < sprite.Length; i ++)
        {
            if(nomeAtualDoConsum == sprite[i].name)
            {
                transform.GetComponent<Image>().sprite = sprite[i].GetComponent<spriteWeapon>().spriteDessaArma;
                auxNomeDasArmasAtt();
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void auxNomeDasArmasAtt ()
    {
        for (var i = 0; i < 30; i++)
        {
            auxNomeDasArmas[i] = PlayerPrefs.GetString("listaDasArmas" + i);
            posTodasAsPot[i] = 0;
        }
        nomeAtualDoConsum = PlayerPrefs.GetString("consum" + consumNumero);
        definePot(nomeAtualDoConsum);
    }


    public void definePot(string nome)
    {
        uuu = 0;
        PlayerPrefs.SetString("consum" + consumNumero, nome);
        for (var i = 0; i < auxCura.Length; i++)
        {
            if(auxCura[i].name == nome)
            {
                transform.GetComponent<Image>().sprite = sprite[i].GetComponent<spriteWeapon>().spriteDessaArma;
                posAuxCura = i;
                break;
            }
        }
        for (var i = 0; i < auxNomeDasArmas.Length; i++)
        {

            if (auxNomeDasArmas[i] == nome)
            {
                posTodasAsPot[uuu] = i;
                uuu++;
            }
        }
        cont = 0;

        if(uuu == 0)
        {
            transform.GetComponent<Image>().sprite = sprite[0].GetComponent<spriteWeapon>().spriteDessaArma;
            PlayerPrefs.SetString("consum" + consumNumero, "semPot");
            posAuxCura = 0;
        }
        
    }


    public void acionaConsum ()
    {

        if (cont < uuu)
        {
            hero.GetComponent<inventWeapons>().discartInventory(posTodasAsPot[cont]);
            Instantiate(auxCura[posAuxCura], hero.transform.position, Quaternion.identity);
        }
        cont++;
        if (cont == uuu)
        {
            definePot("semPot");
            buttonQueSeleciona.GetComponent<selectConsum>().tiraPotComMesmoNome();
        }
    }
}
