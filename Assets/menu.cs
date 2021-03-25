using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu : MonoBehaviour {

    public GameObject menuObj, preStartObj, confirma, continueButton;
    int auxFoco;

    private void Start()
    {
        if (PlayerPrefs.GetInt("foco") == 0)
        {
            continueButton.SetActive(false);
        }
    }

    public void StartMenu()
    {
        //PlayerPrefs.SetInt("startParaVida", 500);
        // PlayerPrefs.SetInt("startParaMana", 500);
        PlayerPrefs.SetInt("saidaScene", 500);
        PlayerPrefs.SetInt("INIT", 0);
        //PlayerPrefs.SetInt("questNumber", 500);
        //Application.LoadLevel("homeInside");
        SceneManager.LoadScene("homeInside");

    }

    public void preStart()
    {
        menuObj.GetComponent<menuPosAltera>().pos = new Vector2(Screen.width * -1, 0);
        preStartObj.GetComponent<menuPosAltera>().pos = new Vector2(0, 0);
    }

    public void backPreStart()
    {
        menuObj.GetComponent<menuPosAltera>().pos = new Vector2(0, 0);
        preStartObj.GetComponent<menuPosAltera>().pos = new Vector2(Screen.width * -1, 0);
    }

    public void swordStart()
    {
        auxFoco = 1;
        confirma.SetActive(true);
    }

    public void mageStart()
    {
        auxFoco = 2;
        confirma.SetActive(true);
    }

    public void negaConfirma ()
    {
        confirma.SetActive(false);
    }

    public void StartNewGameMenu()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("foco", auxFoco);
        PlayerPrefs.SetInt("hr", 7);
        PlayerPrefs.SetInt("startParaVida", 500);
        PlayerPrefs.SetInt("startParaMana", 500);
        PlayerPrefs.SetInt("saidaScene", 500);
        PlayerPrefs.SetInt("questNumber", 0);
        PlayerPrefs.SetInt("INIT", 1);
        PlayerPrefs.SetString("armaAtualNome", "soco");
        PlayerPrefs.SetString("armaduraAtualNome" + 1, "semArmadura");
        PlayerPrefs.SetString("armaduraAtualNome" + 2, "semArmadura");
        PlayerPrefs.SetString("armaduraAtualNome" + 3, "semArmadura");
        if (PlayerPrefs.GetInt("foco") == 1)
        {
            PlayerPrefs.SetInt("baseStr", 10);
            PlayerPrefs.SetInt("baseVit", 10);
            PlayerPrefs.SetInt("baseMag", 2);
        }
        else if (PlayerPrefs.GetInt("foco") == 2)
        {
            PlayerPrefs.SetInt("baseStr", 3);
            PlayerPrefs.SetInt("baseVit", 7);
            PlayerPrefs.SetInt("baseMag", 12);

        }
        PlayerPrefs.SetInt("contTP", 1);
        PlayerPrefs.SetString("nomeProxTP" + PlayerPrefs.GetInt("contTP"), "homeInside");
        PlayerPrefs.SetInt("lvl", 1);
        //Application.LoadLevel("homeInside");
        SceneManager.LoadScene("homeInside");

    }

    public void Quit()
    {
        Application.Quit();
    }

}
