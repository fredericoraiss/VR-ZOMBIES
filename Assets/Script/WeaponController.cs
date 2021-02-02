using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Collider))]

public class WeaponController : MonoBehaviour, ICardboardGazeResponder {

    public PlayerController playerController;

    public string nameWeapon = "";
    public float fireRate = 0.5f;
    public float damage = 15;

    public int currentAmmo = 0;
    public int maxAmmo = 100;

    public float timeDestroy = 5f;
    public float rotateVelocity = 40f;

	// Use this for initialization
	void Start () {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        currentAmmo = maxAmmo;

        StartCoroutine(Destroy());
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, rotateVelocity * Time.deltaTime, 0);
	}

    public void OnGazeEnter()
    {
        throw new NotImplementedException();
    }

    public void OnGazeExit()
    {
        throw new NotImplementedException();
    }

    public void OnGazeTrigger()
    {
        playerController.Weapon = nameWeapon;
        playerController.FireRate = fireRate;
        playerController.DamageWeapon = damage;
        playerController.CurrentAmmo = currentAmmo;
        playerController.MaxAmmo = maxAmmo;

        Destroy(gameObject);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);
    }
}
