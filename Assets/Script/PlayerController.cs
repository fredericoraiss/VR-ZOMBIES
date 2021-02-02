using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]    private string weapon = "";
    [SerializeField]    private float fireRate = 0f;
    [SerializeField]    private float damageWeapon;
    [SerializeField]    private float currentAmmo;
    [SerializeField]    private float maxAmmo;

    [SerializeField]
    private float lifeActual = 100f;
    [SerializeField]
    private float lifeMax = 100f;

    [SerializeField]
    private bool changedWeapon = true;

    #region Encapsulamento

    public string Weapon
    {
        get
        {
            return weapon;
        }

        set
        {
            weapon = value;
        }
    }

    public float FireRate
    {
        get
        {
            return fireRate;
        }

        set
        {
            fireRate = value;
        }
    }

    public float LifeActual
    {
        get
        {
            return lifeActual;
        }

        set
        {
            lifeActual = value;
        }
    }

    public float LifeMax
    {
        get
        {
            return lifeMax;
        }

        set
        {
            lifeMax = value;
        }
    }

    public bool ChangedWeapon
    {
        get
        {
            return changedWeapon;
        }

        set
        {
            changedWeapon = value;
        }
    }

    public float DamageWeapon
    {
        get
        {
            return damageWeapon;
        }

        set
        {
            damageWeapon = value;
        }
    }

    public float CurrentAmmo
    {
        get
        {
            return currentAmmo;
        }

        set
        {
            currentAmmo = value;
        }
    }

    public float MaxAmmo
    {
        get
        {
            return maxAmmo;
        }

        set
        {
            maxAmmo = value;
        }
    }

    #endregion

    // Use this for initialization
    void Start () {
        lifeActual = lifeMax;

        weapon = "Normal";
        fireRate = 0.5f;
        damageWeapon = 10;
        currentAmmo = 99;
        maxAmmo = 99;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}


    public void DescreaseLife(float value)
    {
        lifeActual -= value;
        
    }
   
    public float GetLife()
    {
        float auxLife = lifeActual / lifeMax;
        return auxLife;
    }

}
