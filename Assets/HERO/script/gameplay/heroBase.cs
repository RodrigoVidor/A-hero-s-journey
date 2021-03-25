using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class heroBase : MonoBehaviour {

    public int lvl, str, vit, mag, dinheiro;
    int baseStr, baseVit, baseMag, contParaAtualizarStatus;
    public static int strAuxBasicAtk, magAuxBasicAtk;
    int varBaseXp = 300;
    float expProxLvl, expProxLvlOLD, expAtual;
    public string textExp;
    public GameObject efeitoUpLvl , controleRotParaMana, controleMobParaVida, mostraDinheiro, caixaTextoBloqueioDeXp, buttonUpLvl, telaDeColocarStatus;
    GameObject auxMostraDinheiro;
    public Image imgExp;
    public Text lvlText, expText, strText, vitText, magText, dinheiroText;

    float auxWeaponEquipedStr, auxWeaponEquipedVit, auxWeaponEquipedMag;

    float auxWeaponEquipedStrArma, auxWeaponEquipedVitArma, auxWeaponEquipedMagArma;
    float auxWeaponEquipedStrArmadura, auxWeaponEquipedVitArmadura, auxWeaponEquipedMagArmadura;
    float auxWeaponEquipedStrHelm, auxWeaponEquipedVitHelm, auxWeaponEquipedMagHelm;
    float auxWeaponEquipedStrBoots, auxWeaponEquipedVitBoots, auxWeaponEquipedMagBoots;
    // Use this for initialization
    void Start() {

        dinheiro = PlayerPrefs.GetInt("dinheiro");
        lvl = PlayerPrefs.GetInt("lvl");
        expAtual = PlayerPrefs.GetFloat("expAtual");

        if (PlayerPrefs.GetInt("lockXP") == 1)
        {
            PlayerPrefs.SetInt("lockXP", 2);
            Instantiate(caixaTextoBloqueioDeXp, transform.position, Quaternion.identity);
        }

        if (lvl == 0)
        {
            lvl = 1;
        }


        if (PlayerPrefs.GetInt("foco") == 1)
        {
            baseStr = PlayerPrefs.GetInt("baseStr") + Mathf.FloorToInt(lvl * 0.9f);
            baseVit = PlayerPrefs.GetInt("baseVit") + Mathf.FloorToInt(lvl * 0.7f);
            baseMag = PlayerPrefs.GetInt("baseMag") + Mathf.FloorToInt(lvl * 0.2f);
        }
        else if (PlayerPrefs.GetInt("foco") == 2)
        {
            baseStr = PlayerPrefs.GetInt("baseStr") + Mathf.FloorToInt(lvl * 0.3f);
            baseVit = PlayerPrefs.GetInt("baseVit") + Mathf.FloorToInt(lvl * 0.5f);
            baseMag = PlayerPrefs.GetInt("baseMag") + Mathf.FloorToInt(lvl * 1.1f);

        }
        // PlayerPrefs.SetInt("baseStr", baseStr);
        //PlayerPrefs.SetInt("baseVit", baseVit);
        // PlayerPrefs.SetInt("baseMag", baseMag);

        if (PlayerPrefs.GetInt("statusPoints") > 0)
        {
            buttonUpLvl.SetActive(true);
        }
        //ZERAREXP();

        //  str = Mathf.CeilToInt((lvl * 0.7f) + 7);
        //  strAuxBasicAtk = str;
        //  vit = Mathf.CeilToInt((lvl * 0.9f) + 10);
        //   mag = Mathf.CeilToInt((lvl * 0.5f) + 4);
        //   magAuxBasicAtk = mag;

        //  controleRotParaMana.GetComponent<controleROT>().mana = mag * 14;
        //  controleMobParaVida.GetComponent<controleMOB>().life = vit * 15;

        //  controleRotParaMana.GetComponent<controleROT>().auxMana();
        //  controleMobParaVida.GetComponent<controleMOB>().auxVida();

        expProxLvl = varBaseXp * Mathf.Pow(lvl, 1.3f);
        expProxLvlOLD = varBaseXp * Mathf.Pow((lvl - 1), 1.3f);

        //textExp = expAtual.ToString() + "/" + expProxLvl.ToString(); 7586

        lvlText.text = lvl.ToString();
        //strText.text = str.ToString();
        //vitText.text = vit.ToString();
        //magText.text = mag.ToString();
        dinheiroText.text = dinheiro.ToString();

        expSoma(0);

    }

    void ZERAREXP()
    {
        lvl = 0;
        expAtual = 0;
        expProxLvl = 0;
        expProxLvlOLD = 0;
    }

    // Update is called once per frame
    void Update() {

        



    }

    public void alteraStatus(float strr, float vitt, float magg, int qualArma)
    {

        lvl = PlayerPrefs.GetInt("lvl");
        if (PlayerPrefs.GetInt("foco") == 1)
        {
            baseStr = PlayerPrefs.GetInt("baseStr") + Mathf.FloorToInt(lvl * 0.9f);
            baseVit = PlayerPrefs.GetInt("baseVit") + Mathf.FloorToInt(lvl * 0.7f);
            baseMag = PlayerPrefs.GetInt("baseMag") + Mathf.FloorToInt(lvl * 0.2f);
        }
        else if (PlayerPrefs.GetInt("foco") == 2)
        {
            baseStr = PlayerPrefs.GetInt("baseStr") + Mathf.FloorToInt(lvl * 0.3f);
            baseVit = PlayerPrefs.GetInt("baseVit") + Mathf.FloorToInt(lvl * 0.5f);
            baseMag = PlayerPrefs.GetInt("baseMag") + Mathf.FloorToInt(lvl * 1.1f);
        }
        if (qualArma == 0)
        {
           // print("0");
        }
        if (qualArma == 1)
        {
            auxWeaponEquipedStrArma = strr;
            auxWeaponEquipedVitArma = vitt;
            auxWeaponEquipedMagArma = magg;
            //print("1");
        }
        if (qualArma == 2)
        {
            auxWeaponEquipedStrArmadura = strr;
            auxWeaponEquipedVitArmadura = vitt;
            auxWeaponEquipedMagArmadura = magg;
           // print("2");
        }
        if (qualArma == 3)
        {
            auxWeaponEquipedStrHelm = strr;
            auxWeaponEquipedVitHelm = vitt;
            auxWeaponEquipedMagHelm = magg;
            //print("3");
        }
        if (qualArma == 4)
        {
            auxWeaponEquipedStrBoots = strr;
            auxWeaponEquipedVitBoots = vitt;
            auxWeaponEquipedMagBoots = magg;
            //print("4");
        }

        auxWeaponEquipedStr = (auxWeaponEquipedStrArma + auxWeaponEquipedStrArmadura + auxWeaponEquipedStrHelm + auxWeaponEquipedStrBoots) - 3;
        auxWeaponEquipedVit = (auxWeaponEquipedVitArma + auxWeaponEquipedVitArmadura + auxWeaponEquipedVitHelm + auxWeaponEquipedVitBoots) - 3;
        auxWeaponEquipedMag = (auxWeaponEquipedMagArma + auxWeaponEquipedMagArmadura + auxWeaponEquipedMagHelm + auxWeaponEquipedMagBoots) - 3;


        str = Mathf.CeilToInt((baseStr) * auxWeaponEquipedStr);
        strAuxBasicAtk = str;
        vit = Mathf.CeilToInt((baseVit) * auxWeaponEquipedVit);
        mag = Mathf.CeilToInt((baseMag) * auxWeaponEquipedMag);
        magAuxBasicAtk = mag;

        contParaAtualizarStatus++;

        if (contParaAtualizarStatus >= 4)
        {

            controleRotParaMana.GetComponent<controleROT>().mana = mag * 14;
            controleMobParaVida.GetComponent<controleMOB>().life = vit * 15;

            controleRotParaMana.GetComponent<controleROT>().auxMana();
            controleMobParaVida.GetComponent<controleMOB>().auxVida();
            strText.text = baseStr.ToString() + " + " + (str - baseStr).ToString();
            vitText.text = baseVit.ToString() + " + " + (vit - baseVit).ToString();
            magText.text = baseMag.ToString() + " + " + (mag - baseMag).ToString();
            //print(controleMobParaVida.GetComponent<controleMOB>().life);
        }
    }

    public void onUpLVL ()
    {
        

        PlayerPrefs.SetInt("statusPoints", PlayerPrefs.GetInt("statusPoints") + 2);
        buttonUpLvl.SetActive(true);
        Instantiate(efeitoUpLvl, transform.position, efeitoUpLvl.transform.rotation);
        lvl++;
        PlayerPrefs.SetInt("lvl", lvl);
        expProxLvl = varBaseXp * Mathf.Pow(lvl, 1.3f);
        expProxLvlOLD = varBaseXp * Mathf.Pow((lvl - 1), 1.3f);
        if (PlayerPrefs.GetInt("foco") == 1)
        {
            baseStr = PlayerPrefs.GetInt("baseStr") + Mathf.FloorToInt(lvl * 0.9f);
            baseVit = PlayerPrefs.GetInt("baseVit") + Mathf.FloorToInt(lvl * 0.7f);
            baseMag = PlayerPrefs.GetInt("baseMag") + Mathf.FloorToInt(lvl * 0.2f);
        }
        else if (PlayerPrefs.GetInt("foco") == 2)
        {
            baseStr = PlayerPrefs.GetInt("baseStr") + Mathf.FloorToInt(lvl * 0.3f);
            baseVit = PlayerPrefs.GetInt("baseVit") + Mathf.FloorToInt(lvl * 0.5f);
            baseMag = PlayerPrefs.GetInt("baseMag") + Mathf.FloorToInt(lvl * 1.1f);

        }
        
        
        /*
        str = Mathf.CeilToInt((lvl * 0.7f) + 7);
        strAuxBasicAtk = str;
        vit = Mathf.CeilToInt((lvl * 0.9f) + 10);
        mag = Mathf.CeilToInt((lvl * 0.5f) + 4);
        magAuxBasicAtk = mag;
        */
        controleRotParaMana.GetComponent<controleROT>().mana = mag * 14;
        controleMobParaVida.GetComponent<controleMOB>().life = vit * 15;
        controleRotParaMana.GetComponent<controleROT>().onUpLVL();
        controleMobParaVida.GetComponent<controleMOB>().onUpLVL();
        lvlText.text = lvl.ToString();
        alteraStatus(auxWeaponEquipedStr, auxWeaponEquipedVit, auxWeaponEquipedMag,0);
        expSoma(0);

    }

    public void auxAlteraStatus ()
    {
        alteraStatus(auxWeaponEquipedStr, auxWeaponEquipedVit, auxWeaponEquipedMag,0);
        buttonUpLvl.SetActive(false);
    }


    public void expSoma (float expRecebida) {

        //if (expText == null)
        //{
        //    expText = GameObject.FindGameObjectWithTag("expText");
        // }
        //imgExp.fillAmount = (expAtual - expProxLvlOLD) / expProxLvl;

        imgExp.fillAmount = (expAtual - expProxLvlOLD) / (expProxLvl - expProxLvlOLD);
        expAtual += expRecebida;
        textExp = expAtual.ToString("F0") + "/" + expProxLvl.ToString("F0");
        expText.text = textExp;
        PlayerPrefs.SetFloat("expAtual", expAtual);
        if (expAtual >= expProxLvl)
        {
            //print("?");
            if (PlayerPrefs.GetInt("lockXP") == 3)
            {
                onUpLVL();
            }
            else if(PlayerPrefs.GetInt("lockXP") == 0)
            {
                PlayerPrefs.SetInt("lockXP", 1);
            }

        }

    }

    public void ativaTelaDeStatus ()
    {
        telaDeColocarStatus.SetActive(true);
        telaDeColocarStatus.GetComponent<atualizaStatusUpLvl>().onInstant();
    }

    public void pontoStr()
    {
        PlayerPrefs.SetInt("baseStr", PlayerPrefs.GetInt("baseStr") + 1);
        PlayerPrefs.SetInt("statusPoints", PlayerPrefs.GetInt("statusPoints") -1);
        telaDeColocarStatus.GetComponent<atualizaStatusUpLvl>().onInstant();
    }
    public void pontoVit()
    {
        PlayerPrefs.SetInt("baseVit", PlayerPrefs.GetInt("baseVit") + 1);
        PlayerPrefs.SetInt("statusPoints", PlayerPrefs.GetInt("statusPoints") -1);
        telaDeColocarStatus.GetComponent<atualizaStatusUpLvl>().onInstant();
    }
    public void pontoMag()
    {
        PlayerPrefs.SetInt("baseMag", PlayerPrefs.GetInt("baseMag") + 1);
        PlayerPrefs.SetInt("statusPoints", PlayerPrefs.GetInt("statusPoints") -1);
        telaDeColocarStatus.GetComponent<atualizaStatusUpLvl>().onInstant();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "dinheiroDrop")
        {
            auxMostraDinheiro = Instantiate(mostraDinheiro, other.transform.position, Quaternion.identity) as GameObject;
            auxMostraDinheiro.GetComponent<auxMostraDanos>().restoTextGold(other.GetComponent<dropGeral>().quant);
            auxMostraDinheiro.GetComponent<auxMostraDanos>().danos.color = new Color(1, 1, 0);
            other.GetComponent<dropGeral>().instEfeito();
            dinheiro += other.GetComponent<dropGeral>().quant;
            dinheiroText.text = dinheiro.ToString() + " G";
            PlayerPrefs.SetInt("dinheiro", dinheiro);
            Destroy(other.gameObject);
        }

       /* if (other.tag == "itemDrop")
        {
            auxMostraDinheiro = Instantiate(mostraDinheiro, other.transform.position, Quaternion.identity) as GameObject;
            auxMostraDinheiro.GetComponent<auxMostraDanos>().itemText(); ;
            auxMostraDinheiro.GetComponent<auxMostraDanos>().danos.color = new Color(1, 0, 1);
            other.GetComponent<dropGeral>().instEfeito();
            Destroy(other.gameObject);
        }*/
        else if (other.tag == "itemDrop")
        {
            if (other.GetComponent<dropItem>().tipo == 0)
            {
                if (transform.GetComponent<inventWeapons>().slotVazios > 0)
                {
                    transform.GetComponent<inventWeapons>().getArmas(other.GetComponent<dropItem>().nomeDropItem);
                    auxMostraDinheiro = Instantiate(mostraDinheiro, other.transform.position, Quaternion.identity) as GameObject;
                    auxMostraDinheiro.GetComponent<auxMostraDanos>().itemText(other.GetComponent<dropItem>().nomeDropItem);
                    auxMostraDinheiro.GetComponent<auxMostraDanos>().danos.color = new Color(1, 0, 1);
                    other.GetComponent<dropItem>().instEfeito();
                    Destroy(other.gameObject);
                }
            }
            else if (other.GetComponent<dropItem>().tipo == 1)
            {

            }
            else if (other.GetComponent<dropItem>().tipo == 2)
            {

            }
            else if (other.GetComponent<dropItem>().tipo == 3)
            {
                if (transform.GetComponent<inventWeapons>().slotVazios > 0)
                {
                    transform.GetComponent<inventWeapons>().getArmas(other.GetComponent<dropItem>().nomeDropItem);
                    auxMostraDinheiro = Instantiate(mostraDinheiro, other.transform.position, Quaternion.identity) as GameObject;
                    auxMostraDinheiro.GetComponent<auxMostraDanos>().itemText(other.GetComponent<dropItem>().nomeDropItem);
                    auxMostraDinheiro.GetComponent<auxMostraDanos>().danos.color = new Color(1, 0, 1);
                    other.GetComponent<dropItem>().instEfeito();
                    Destroy(other.gameObject);
                }
            }
            else if (other.GetComponent<dropItem>().tipo == 4)
            {
                if (transform.GetComponent<inventWeapons>().slotVazios > 0)
                {
                    transform.GetComponent<inventWeapons>().getArmas(other.GetComponent<dropItem>().nomeDropItem);
                    auxMostraDinheiro = Instantiate(mostraDinheiro, other.transform.position, Quaternion.identity) as GameObject;
                    auxMostraDinheiro.GetComponent<auxMostraDanos>().itemText(other.GetComponent<dropItem>().nomeDropItem);
                    auxMostraDinheiro.GetComponent<auxMostraDanos>().danos.color = new Color(1, 0, 1);
                    other.GetComponent<dropItem>().instEfeito();
                    Destroy(other.gameObject);
                }
            }

            else if (other.GetComponent<dropItem>().tipo == 5)
            {
                PlayerPrefs.SetInt(other.GetComponent<dropItem>().nomeDropItem, 1);
                PlayerPrefs.SetInt("contTP", PlayerPrefs.GetInt("contTP") + 1);
                PlayerPrefs.SetString("nomeProxTP" + PlayerPrefs.GetInt("contTP"), other.GetComponent<dropItem>().nomeDropItem);
                Destroy(other.gameObject);
            }
        }

    }

}
