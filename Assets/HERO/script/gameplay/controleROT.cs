using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class controleROT : MonoBehaviour
{

    GameObject _mainCameraTransform;

    public Animator anim;
    public Rigidbody rig;

    public GameObject parent, efeitBasicAttack, auxEfeitoBasicAttack, auxPoderRot1, auxPoderRot2,/* poderObj1, poderObj2, */ mostraMana, passivaEfect;
    public GameObject[] poderGeral;
    public GameObject[] consumGeral;
    GameObject auxMostraMana;

    public CharacterController _characterController;

    public float speed, mana, delayParaMov;
    public GameObject heroBaseAux, weapon;
    float manaReal;
    //public GameObject manaSprite;
    public Image manaImg;
    public Text manaText;
    public bool castSkill;
    public int numeroSkill;
    bool auxSlowMov, manaRegen;
    float delay, delayManaReg, passiveAtkSpeed;




    // Use this for initialization
    void Start()
    {

        if(PlayerPrefs.GetInt("skill" + "4") == 1)
        {
            manaRegen = true;
        }

        if (PlayerPrefs.GetInt("skill" + "4") == 3)
        {
            anim.SetFloat("atkSpeed",1.5f);
            poderPassiva(14);
        }

        /* if (PlayerPrefs.GetInt("startParaMana") != 500)
         {
             manaReal = PlayerPrefs.GetFloat("manaAtual");
         }
         else
         {
             manaReal = mana;
             PlayerPrefs.SetInt("startParaMana", 0);
             PlayerPrefs.SetFloat("manaAtual", manaReal);
         }*/

        manaImg.fillAmount = manaReal / mana;
        manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
        _mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera");

    }

    // Update is called once per frame
    void Update()
    {
        if(manaRegen)
        {
            delayManaReg += Time.deltaTime;
            if(delayManaReg >= 5)
            {
                poder1(13);
                delayManaReg = 0;
            }
        }
        if(castSkill)
        {
            var inputVector = new Vector3(CrossPlatformInputManager.GetAxisRaw("HorizontalROTSkill"+numeroSkill), CrossPlatformInputManager.GetAxisRaw("VerticalROTSkill"+numeroSkill));
            Vector3 movementVector = Vector3.zero;

            // If we have some input
            if (inputVector.sqrMagnitude > 0.001f)
            {
                movementVector = _mainCameraTransform.transform.TransformDirection(inputVector);
                movementVector.y = 0f;
                movementVector.Normalize();
                transform.forward = movementVector;
            }

        }

        if (!skillQueMoveHero.algumPowerQueMovimenta && castSkill == false)
        {
            var inputVector = new Vector3(CrossPlatformInputManager.GetAxisRaw("HorizontalROT"), CrossPlatformInputManager.GetAxisRaw("VerticalROT"));
            Vector3 movementVector = Vector3.zero;

            // If we have some input
            if (inputVector.sqrMagnitude > 0.001f)
            {
                anim.SetBool("AA", true);
                movementVector = _mainCameraTransform.transform.TransformDirection(inputVector);
                movementVector.y = 0f;
                movementVector.Normalize();
                transform.forward = movementVector;
                if (auxSlowMov == false)
                {
                    slowMovAtk();
                }
            }
            else
            {
                anim.SetBool("AA", false);
                transform.rotation = parent.transform.rotation;
                //////AAAAAAAAA
            }
            //print(delay);
            if (auxSlowMov)
            {
                delay += Time.deltaTime;
                if (delay > delayParaMov)
                {
                    parent.GetComponent<controleMOB>().speedAuxMovAtk = 1;
                    //print("certo");
                    //transform.rotation = parent.transform.rotation;
                    ///AAAAAA
                    auxSlowMov = false;
                }
            }
        }


       // movementVector += Physics.gravity;
        //rig.AddForce(movementVector);
        //_characterController.Move(movementVector * ((inputVector.sqrMagnitude * speed) * Time.deltaTime));

    }

    public void atualizaPassiva()
    {
        if (PlayerPrefs.GetInt("skill" + "4") == 1)
        {
            manaRegen = true;
            Destroy(passivaEfect);
        }
        else
        {
            manaRegen = false;
        }

        if (PlayerPrefs.GetInt("skill" + "4") == 3)
        {
            anim.SetFloat("atkSpeed", 1.5f);
            Destroy(passivaEfect);
            poderPassiva(14);
        }
        else
        {
            anim.SetFloat("atkSpeed", 1);
        }
    }

    public void onUpLVL()
    {
        manaReal = mana;
        PlayerPrefs.SetFloat("manaAtual", manaReal);
        manaImg.fillAmount = manaReal / mana;
        manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
    } 

    public void manaDrop (int quantDeMana, GameObject drop, bool porcent)
    {
        if (manaReal < mana)
        {
            if(porcent)
            {
                quantDeMana = Mathf.CeilToInt((mana * quantDeMana) / 100);
            }
            manaReal += quantDeMana;
            if (manaReal > mana)
            {
                manaReal = mana;
            }
            Destroy(drop);
            manaImg.fillAmount = manaReal / mana;
            manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
            PlayerPrefs.SetFloat("manaAtual", manaReal);
            auxMostraMana = Instantiate(mostraMana, drop.transform.position, Quaternion.identity) as GameObject;
            auxMostraMana.GetComponent<auxMostraDanos>().restoText(quantDeMana);
            auxMostraMana.GetComponent<auxMostraDanos>().danos.color = new Color(0, 213, 255);
            drop.GetComponent<dropGeral>().instEfeito();
        }
    }
    public void manaRevive()
    {

        manaReal = mana;
        manaImg.fillAmount = manaReal / mana;
        manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
        PlayerPrefs.SetFloat("manaAtual", manaReal);

    }
    public void manaRegenSafeZone()
    {
        if (manaReal < mana)
        {
            manaReal += 2;
            if (manaReal > mana)
            {
                manaReal = mana;
            }
            manaImg.fillAmount = manaReal / mana;
            manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
            PlayerPrefs.SetFloat("manaAtual", manaReal);
        }
    }

    public void slowMovAtk ()
    {
        parent.GetComponent<controleMOB>().speedAuxMovAtk = 0.3f;
        delay = 0;
        auxSlowMov = true;
       // print("au");
    }


    public void auxMana ()
    {
        manaImg.fillAmount = manaReal / mana;
        manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
        if (PlayerPrefs.GetInt("startParaMana") != 500)
        {
            manaReal = PlayerPrefs.GetFloat("manaAtual");
        }
        else
        {
            manaReal = mana;
            PlayerPrefs.SetInt("startParaMana", 0);
            PlayerPrefs.SetFloat("manaAtual", manaReal);
        }
    }

    public void efeitoAttack()
    {
       Instantiate(efeitBasicAttack, auxEfeitoBasicAttack.transform.position, auxEfeitoBasicAttack.transform.rotation);
    }

    public void poder1(int numeroPoder)
    {
        //anim.SetTrigger("power");
        if (manaReal > poderGeral[numeroPoder].GetComponent<manaCost>().mana)
        {
            Instantiate(poderGeral[numeroPoder], auxPoderRot1.transform.position, auxPoderRot1.transform.rotation);
            if (poderGeral[numeroPoder].GetComponent<manaCost>().manaInteiraParaCura)
            {
                manaReal = 0;
            }
            else
            {
                manaReal -= poderGeral[numeroPoder].GetComponent<manaCost>().mana;
            }
            //anim.SetTrigger("hit");
            manaImg.fillAmount = manaReal / mana;
            PlayerPrefs.SetFloat("manaAtual", manaReal);
            manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
        }
    }

    public void poderPassiva(int numeroPoder)
    {
        passivaEfect = Instantiate(poderGeral[numeroPoder], auxPoderRot1.transform.position, auxPoderRot1.transform.rotation) as GameObject;
    }

    public void consum(int numeroConsum)
    {
       // anim.SetTrigger("power");
        if (manaReal > poderGeral[numeroConsum].GetComponent<manaCost>().mana)
        {
            Instantiate(consumGeral[numeroConsum], auxPoderRot1.transform.position, auxPoderRot1.transform.rotation);
            //manaReal -= consumGeral[numeroConsum].GetComponent<manaCost>().mana;
            //anim.SetTrigger("hit");
           // manaImg.fillAmount = manaReal / mana;
            //PlayerPrefs.SetFloat("manaAtual", manaReal);
            //manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
        }
    }

    /*  public void poder2()
      {
          anim.SetTrigger("power");
          if (manaReal > poderObj2.GetComponent<manaCost>().mana)
          {
              Instantiate(poderObj2, auxPoderRot1.transform.position, auxPoderRot2.transform.rotation);
              manaReal -= poderObj2.GetComponent<manaCost>().mana;
              anim.SetTrigger("hit");
              manaImg.fillAmount = manaReal / mana;
              PlayerPrefs.SetFloat("manaAtual", manaReal);
              manaText.text = manaReal.ToString("F0") + "/" + mana.ToString("F0");
          }
      }*/


}
