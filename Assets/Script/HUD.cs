using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {


    public PlayerController playerController;
    public Canvas CanvasEsquerdo;
    public Camera cameraDireita;
    public Text[] info_t;

    public Image[] ammoImg, healthImg;

    Canvas CanvasDireito;

    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>(); ;

       // WE NEED TO DUPLICATE CANVAS BUT ATTACHED TO THE RIGHT CANVAS
        CanvasDireito = GameObject.Instantiate(CanvasEsquerdo) as Canvas;
        CanvasDireito.worldCamera = cameraDireita;
        CanvasDireito.transform.parent = transform;
        CanvasDireito.name = "HUDRight";

        healthImg[1] = CanvasDireito.transform.GetChild(1).GetComponent<Image>();
        info_t[1] = CanvasDireito.transform.GetChild(3).GetComponent<Text>();
    }

    void Start()
    {
        

    }

    void Update()
    {
        for (int i = 0; i < 2; i++)
        {
            info_t[i].text = " Kills: " + GameController.Instance.NumberZombiesDestroied.ToString() +
                "\n Weapon: " + playerController.Weapon +
                "\n Ammo: " + playerController.CurrentAmmo + "/" + playerController.MaxAmmo +
                "\n Fire Rate: " + playerController.FireRate + "s" +
                "\n Damage: " + playerController.DamageWeapon;

        }
    }

    void FixedUpdate()
    {
        UpdateHealth();
    }
    
    public void UpdateHealth()
    {
        for (int jj = 0; jj < 2; jj++)
        {
            healthImg[jj].fillAmount = playerController.GetLife();
           
        }
    }

    public void UpdateMunition()
    {
        for (int jj = 0; jj < 2; jj++)
        {
            //ammoImg[jj].fillAmount = ammoSLD.value;
        }
    }

}
