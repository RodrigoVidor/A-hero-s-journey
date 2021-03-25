using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class controleMOB : MonoBehaviour
{

    GameObject _mainCameraTransform, auxMostraVida, efeitoHit;
    Collider col;
    Rigidbody rig;
    public GameObject controleRot, mostraVida, interfac, interfacDie;
    public Animator anim;
    //public CharacterController _characterController;
    public Image vidaImg;
    public Text vidaText;
    public float life, speed, speedAuxMovAtk;
    float vidaReal, XP, auxResetSpeed, auxSpeedPassive;
    RaycastHit hit;
    Vector3 posAtual;
    public float iceBarrierSkill;

    // Use this for initialization
    void Start()
    {

        if (PlayerPrefs.GetInt("skill" + "4") == 2)
        {
            controleRot.GetComponent<controleROT>().poderPassiva(15);
            auxSpeedPassive = speed * 2;
        }
        else
        {
            auxSpeedPassive = speed;
        }

        iceBarrierSkill = 1;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
        auxResetSpeed = auxSpeedPassive;
        transform.parent = null;
        speedAuxMovAtk = 1;



        /* if (PlayerPrefs.GetInt("startParaVida") != 500)
         {
             vidaReal = PlayerPrefs.GetFloat("vidaAtual");
         }
         else
         {
             vidaReal = life;
             PlayerPrefs.SetInt("startParaVida", 0);
             PlayerPrefs.SetFloat("vidaAtual", vidaReal);
         }*/

        vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
        vidaImg.fillAmount = vidaReal / life;
        col = transform.GetComponent<CapsuleCollider>();
        rig = transform.GetComponent<Rigidbody>();
        _mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera");
        //print(transform.GetComponent<heroBase>().vit);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(transform.GetComponent<heroBase>().vit);
        if (!skillQueMoveHero.algumPowerQueMovimenta)
        {
            var inputVector = new Vector3(CrossPlatformInputManager.GetAxisRaw("Horizontal"), CrossPlatformInputManager.GetAxisRaw("Vertical"));
            Vector3 movementVector = Vector3.zero;

            // If we have some input
            if (inputVector.sqrMagnitude > 0.001f)
            {
                anim.SetBool("W", true);
                movementVector = _mainCameraTransform.transform.TransformDirection(inputVector);
                movementVector.y = 0f;
                movementVector.Normalize();
                transform.forward = movementVector;
            }
            else
            {
                anim.SetBool("W", false);
            }

            //movementVector += Physics.gravity;
            rig.MovePosition(transform.position + (movementVector * (inputVector.sqrMagnitude * (auxSpeedPassive * speedAuxMovAtk))) * Time.deltaTime);
            // _characterController.Move(movementVector * ((inputVector.sqrMagnitude * (speed * speedAuxMovAtk)) * Time.deltaTime));
        }

    }

    public void atualizaPassiva()
    {
        if (PlayerPrefs.GetInt("skill" + "4") == 2)
        {
            Destroy(controleRot.GetComponent<controleROT>().passivaEfect);
            controleRot.GetComponent<controleROT>().poderPassiva(15);
            auxSpeedPassive = speed * 2;
            auxResetSpeed = auxSpeedPassive;
        }
        else
        {
            auxSpeedPassive = speed;
            auxResetSpeed = auxSpeedPassive;
        }
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void resetSpeed()
    {
        speed = auxResetSpeed;
    }

    public void onUpLVL()
    {
        vidaReal = life;
        PlayerPrefs.SetFloat("vidaAtual", vidaReal);
        vidaImg.fillAmount = vidaReal / life;
        vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
    }

    public void auxVida()
    {
        // print(vidaReal);
        //print(life);
        //print(PlayerPrefs.GetFloat("vidaAtual"));
        if (PlayerPrefs.GetInt("startParaVida") != 500)
        {
            vidaReal = PlayerPrefs.GetFloat("vidaAtual");
        }
        else
        {
            vidaReal = life;
            PlayerPrefs.SetInt("startParaVida", 0);
            PlayerPrefs.SetFloat("vidaAtual", vidaReal);
        }
        if(vidaReal > life)
        {
            vidaReal = life;
            PlayerPrefs.SetFloat("vidaAtual", vidaReal);
        }
        vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
        vidaImg.fillAmount = vidaReal / life;
    }

    public void danoAux(float dano)
    {
        vidaReal -= dano;
        vidaImg.fillAmount = vidaReal / life;
        PlayerPrefs.SetFloat("vidaAtual", vidaReal);
        vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
    }
    void dieHero ()
    {
        // vidaSprite.transform.localScale = Vector3.zero;
        anim.SetBool("die", true);
        //col.enabled = false;
        interfac.SetActive(false);
        interfacDie.SetActive(true);
        PlayerPrefs.SetInt("morreuSalva", 1);
        //Destroy(col);
        //Destroy(rig);
        // Destroy(this);
    }
    public void revivePorVideo()
    {
        // vidaSprite.transform.localScale = Vector3.zero;
        anim.SetBool("die", false);
        //col.enabled = false;
        interfac.SetActive(true);
        interfacDie.SetActive(false);
        PlayerPrefs.SetInt("morreuSalva", 0);
        vidaReal = life;
        vidaImg.fillAmount = vidaReal / life;
        PlayerPrefs.SetFloat("vidaAtual", vidaReal);
        vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
        controleRot.GetComponent<controleROT>().manaRevive();
        //Destroy(col);
        //Destroy(rig);
        // Destroy(this);
    }
    void OnParticleCollision(GameObject other)
    {
        if (other.transform.tag == "hitMonster")
        {
            //hit = true;
            if (efeitoHit != null)
            {
                Instantiate(efeitoHit, transform.position, transform.rotation);
            }
            vidaReal -= (other.transform.GetComponent<danoAtaques>().dano * iceBarrierSkill);
            anim.SetTrigger("dmg");
            vidaImg.fillAmount = vidaReal / life;
            PlayerPrefs.SetFloat("vidaAtual", vidaReal);
            vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
            if (vidaReal <= 0)
            {
                dieHero();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "hitMonster")
        {
            //hit = true;
            efeitoHit = other.GetComponent<danoAtaques>().efeito;
            if (efeitoHit != null)
            {
                Instantiate(efeitoHit, transform.position, transform.rotation);
            }
            vidaReal -= (other.GetComponent<danoAtaques>().dano * iceBarrierSkill);
            anim.SetTrigger("dmg");
            vidaImg.fillAmount = vidaReal / life;
            PlayerPrefs.SetFloat("vidaAtual", vidaReal);
            vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
            if (vidaReal <= 0)
            {
                dieHero();
            }
        }
        if (other.tag == "vidaDrop")
        {
            if (vidaReal < life)
            {
                if(other.GetComponent<dropGeral>().porcentagem)
                {
                    vidaReal += Mathf.CeilToInt((life * other.GetComponent<dropGeral>().quant) / 100);
                }
                else
                {
                    vidaReal += other.GetComponent<dropGeral>().quant;
                }
                
                if (vidaReal > life)
                {
                    vidaReal = life;
                }
                Destroy(other.gameObject);
                vidaImg.fillAmount = vidaReal / life;
                vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
                PlayerPrefs.SetFloat("vidaAtual", vidaReal);
                auxMostraVida = Instantiate(mostraVida, other.transform.position, Quaternion.identity) as GameObject;
                auxMostraVida.GetComponent<auxMostraDanos>().restoText(Mathf.CeilToInt((life * other.GetComponent<dropGeral>().quant) / 100));
                auxMostraVida.GetComponent<auxMostraDanos>().danos.color = new Color(0, 255, 0);
                other.GetComponent<dropGeral>().instEfeito();
            }
        }
        else if (other.tag == "manaDrop")
        {
            controleRot.GetComponent<controleROT>().manaDrop(other.GetComponent<dropGeral>().quant, other.gameObject, other.GetComponent<dropGeral>().porcentagem);
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "regen")
        {
            if (vidaReal < life)
            {
                vidaReal += 2;
                if (vidaReal > life)
                {
                    vidaReal = life;
                }
                vidaImg.fillAmount = vidaReal / life;
                vidaText.text = vidaReal.ToString("F0") + "/" + life.ToString("F0");
                PlayerPrefs.SetFloat("vidaAtual", vidaReal);
            }
            controleRot.GetComponent<controleROT>().manaRegenSafeZone();
        }
    }
}
