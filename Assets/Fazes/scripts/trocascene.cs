using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class trocascene : MonoBehaviour
{
    public string scene;
    public int saida;
    int aux;
    public bool semStart;
    bool criouCaixaDeTexto;
    public float fadeInt;
    float delay;
    public GameObject hero, GUI, pontoDeInst, PAIDETODOS;
    public GameObject fade;


    // Use this for initialization
    void Start()
    {
        if (saida == PlayerPrefs.GetInt("saidaScene") && semStart == false)
        {
            // Instantiate(hero, pontoDeInst.transform.position, hero.transform.rotation);
            Instantiate(PAIDETODOS, pontoDeInst.transform.position, hero.transform.rotation);
            // Instantiate(GUI, Vector3.zero, Quaternion.identity);
        }
        fade = GameObject.FindGameObjectWithTag("fade");
        fade.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, 1);
        delay = 0.7f;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (aux == 1)
        {
            fade.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, fadeInt);
            delay += Time.deltaTime;
            fadeInt = delay;
            musicOverScene.musicTime.volume = (delay * -1) + 0.7f;
           // print((delay * -1) + 0.7f);
            if (delay >= 0.7f)
            {
                PlayerPrefs.SetInt("saidaScene", saida);
               // print(musicOverScene.musicaAux.name);
               // print(musicOverScene.musicTime.time);
                PlayerPrefs.SetFloat("tempoMusica" + musicOverScene.musicaAux.name, musicOverScene.musicTime.time);
                //Application.LoadLevel(scene.name);
                SceneManager.LoadScene(scene);

            }
        }
        if (aux == 0 && delay >= 0)
        {
            fade.GetComponent<MeshRenderer>().material.color = new Color(0, 0, 0, fadeInt);
            delay -= Time.deltaTime;
            fadeInt = delay;
           // print((delay * -1) - 0.7f);
            musicOverScene.musicTime.volume = (delay * -1) + 0.7f;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.tag == "hero")
        {
           // PlayerPrefs.SetInt("saidaScene", saida);
            //SceneManager.LoadScene(scene);
            aux = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (delay < 0.7f)
        {
            aux = 0;
        }
    }
}
