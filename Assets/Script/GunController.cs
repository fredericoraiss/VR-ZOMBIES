using UnityEngine;
using System;
using System.Collections;

public class GunController : MonoBehaviour {

    public event Action<RaycastHit> OnRaycasthit;
    
    public Transform mainCamera;
    public GameObject Projetil;
    public GameObject gunFireLocal;

    public PlayerController playerController;

    public GameObject target;

    [SerializeField] private LayerMask m_LayerExclude;

    [SerializeField]    private float m_rayLenght = 500f;
    [SerializeField]    private Reticle m_Reticle;
    
    public float _fireRate = 0f;                        //fire rate da arma.
    public float _lastShoot = 0;


    #region Encapslamento
    public float FireRate
    {
        get
        {
            return _fireRate;
        }

        set
        {
            _fireRate = value;
        }
    }

    public float LastShoot
    {
        get
        {
            return _lastShoot;
        }

        set
        {
            _lastShoot = value;
        }
    }
    #endregion


    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }
    // Use this for initialization
    void Start () {
        if(playerController != null)
            FireRate = playerController.FireRate;
    }
	
	// Update is called once per frame
	void Update () {
        if (playerController.ChangedWeapon)
            FireRate = playerController.FireRate;

        RayCastTest();

        if (target != null)
        {
            if (target.GetComponent<EnemyController>().CanShoot)
            {
                Shoot();
            }
        }
    }

    private void RayCastTest()
    {
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_rayLenght, ~m_LayerExclude))
        {
            target = hit.collider.gameObject;

          /*  if (m_Reticle)
                m_Reticle.SetPosition(hit);*/

            if (OnRaycasthit != null)
                OnRaycasthit(hit);

            
        }
        else
        {
            target = null;
           /* if(m_Reticle)
                m_Reticle.SetPosition(hit);*/

            if (OnRaycasthit != null)
                OnRaycasthit(hit);
        }

        
    }

    void Shoot()
    {
        
        if (Time.time > _fireRate + _lastShoot)
        {
            if (playerController.Weapon.Equals("Normal"))
            {
                GameObject hitPlayer;
                hitPlayer = Instantiate(Projetil, transform.position, Quaternion.identity) as GameObject;
                //hitPlayer.gameObject.transform.LookAt(this.transform);

                Vector3 toTarget = (target.transform.position - transform.position).normalized;

                hitPlayer.GetComponent<Rigidbody>().velocity = toTarget * (Time.deltaTime * Projetil.gameObject.GetComponent<BulletManager>().velocity);//transform.TransformDirection(0, 0, 1 * -bulletSpeed);

                _lastShoot = Time.time;
            }
            else
            {
                if (playerController.CurrentAmmo > 0)
                {
                    GameObject hitPlayer;
                    hitPlayer = Instantiate(Projetil, transform.position, Quaternion.identity) as GameObject;
                    //hitPlayer.gameObject.transform.LookAt(this.transform);

                    Vector3 toTarget = (target.transform.position - transform.position).normalized;

                    hitPlayer.GetComponent<Rigidbody>().velocity = toTarget * (Time.deltaTime * Projetil.gameObject.GetComponent<BulletManager>().velocity);//transform.TransformDirection(0, 0, 1 * -bulletSpeed);

                    _lastShoot = Time.time;
                    playerController.CurrentAmmo--;
                }
                else
                {
                    playerController.Weapon = "Normal";
                }

            }

            Debug.Log("SHOOT");
        }


    }
}
