using UnityEngine;
using System.Collections;

public class cameraFoco : MonoBehaviour
{

    GameObject hero;
    public float distanciaX, distanciaY, distanciaZ;
    float distanciaRealX, distanciaRealY, distanciaRealZ;
    Vector3 rotCam, posShop;
    private Vector3 velocity = Vector3.zero;
    public static int auxCamCont;
    bool camShop;

    // Use this for initialization
    void Start()
    {

        distanciaRealZ = distanciaZ;
        distanciaRealY = distanciaY;
        distanciaRealX = distanciaX;
        rotCam = new Vector3(45, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {

        if (hero == null)
        {
            hero = GameObject.FindGameObjectWithTag("hero");
        }

        if (!camShop)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(hero.transform.position.x + distanciaRealX, hero.transform.position.y + distanciaRealY, hero.transform.position.z - distanciaRealZ), ref velocity, 0.3f);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, rotCam, 3 * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(posShop.x, posShop.y, posShop.z), ref velocity, 0.3f);
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, rotCam, 3 * Time.deltaTime);
        }

        if(auxCamCont == 0)
        {
            camFocoGame();
            auxCamCont = 50;
        }
        if (auxCamCont == 1)
        {
            camFocoQuadro();
            auxCamCont = 50;
        }

    }

    public void camFocoQuadro()
    {
        distanciaRealZ = 11;
        distanciaRealY = 5.25f;
        distanciaRealX = 2.75f;
        rotCam = new Vector3(23, 25, 11);
    }

    public void camFocoGame()
    {
        camShop = false;
        distanciaRealZ = distanciaZ;
        distanciaRealY = distanciaY;
        distanciaRealX = distanciaX;
        rotCam = new Vector3(45, 0, 0);
    }

    public void camFocoShopIbi(Vector3 posParaCamera, Vector3 rotParaCamera)
    {
        auxCamCont = 50;
        camShop = true;
        posShop = posParaCamera;
        rotCam = rotParaCamera;
    }
}
