using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Collider))]
public class EnemyController : MonoBehaviour, ICardboardGazeResponder
{
    private PlayerController playerController;
    private Animator anim;

    public GameObject[] weaponBox;
    public GameObject lifeBar;
    public float currentLife = 0f;
    public float maxLife = 100f;
    

    [SerializeField]
    private bool isDamaged = false;                     //verifica se levou dano
    [SerializeField]
    private bool canShoot = false;                      //sistema de fire rate, libera o tiro.
    [SerializeField]
    private float fireRate = 0f;                        //fire rate da arma.
    [SerializeField]
    private float lastShoot = 0;                        //verifica quando foi dado o ultimo tiro.
    [SerializeField]
    private float damageValue = 20; 
    private bool configure = true;



    public GameObject localTiro;
    public Rigidbody Projetil;

    public bool CanShoot
    {
        get
        {
            return canShoot;
        }

        set
        {
            canShoot = value;
        }
    }

    void Awake()
    {
        configure = true;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();

        localTiro = GameObject.Find("LocalTiro");
    }

    // Use this for initialization
    void Start()
    {
        transform.LookAt(GameObject.Find("Player").transform);                      //olha para o player.

        currentLife = maxLife;
        anim.SetFloat("Vida", currentLife);



    }

    // Update is called once per frame
    void Update()
    {

        if (GameController.Instance.StartGame)
        {
            transform.position += transform.forward * Time.deltaTime * 2;
        }
        

    
        //Debug.DrawRay(principal.transform.position, transform.position, Color.red);

    }

    public void SetGazedAt(bool gazedAt)
    {
        CanShoot = gazedAt;
    }

    #region Implementacao GAZE

    public void OnGazeEnter()
    {

        SetGazedAt(true);



        Debug.Log("Pode Atirar");
    }

    public void OnGazeExit()
    {
        SetGazedAt(false);

    }

    public void OnGazeTrigger()
    {
        
    }

    #endregion



    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Bala"))
        {
            if (!isDamaged)
            {
                isDamaged = true;
                anim.SetBool("Dano", isDamaged);
            }

            Destroy(col.gameObject);
            DescreaseLife(playerController.DamageWeapon);
        }
        if (col.gameObject.CompareTag("Player"))
        {

            playerController.DescreaseLife(damageValue);
            Destroy(gameObject);

        }
    }

    #region Sistem de Vida

    void DescreaseLife(float value)
    {
        currentLife -= value;
        float auxLife = currentLife / maxLife;

        UpdateLifeBar(auxLife);

        anim.SetFloat("Vida", currentLife);
    }
    void UpdateLifeBar(float mylife)
    {
        lifeBar.transform.localScale = new Vector3(Mathf.Clamp(mylife, 0f, 1f), lifeBar.transform.localScale.y, lifeBar.transform.localScale.z);
    }

    #endregion


    public void DamageFalse()
    {
        isDamaged = false;
        anim.SetBool("Dano", isDamaged);
    }

    public void Destroy()
    {
        GerateWeapon();
        Destroy(this.gameObject);
        GameController.Instance.NumberZombiesDestroied++;

    }
    void GerateWeapon()
    {
        float rool;
        float roolW;
        
        rool = Random.Range(0,100);
        roolW = Random.Range(0, 100);

        Debug.Log(rool.ToString() + "  " + roolW.ToString());
       // yield return new WaitForSeconds(0.5f);

        if(playerController.LifeActual > 80)
        {
            Debug.Log("Maior que 80");
            if (rool <  15)
            {
                Debug.Log("Gerou Arma");
                if (roolW < 5) { Instantiate(weaponBox[2], transform.position, Quaternion.identity); }
                else if (roolW >= 5 && roolW < 30) { Instantiate(weaponBox[1], transform.position, Quaternion.identity); }
                else if (roolW >= 30) { Instantiate(weaponBox[1], transform.position, Quaternion.identity); }
                
            }
            else { Debug.Log("Não Gerou Arma"); }
        }
        else if(playerController.LifeActual <= 80 && playerController.LifeActual > 40)
        {
            Debug.Log("Maior que 40 e m 80");
            if (rool < 30)
            {
                Debug.Log("Gerou Arma");

                if (roolW < 10) { Instantiate(weaponBox[2], transform.position, Quaternion.identity); }
                else if (roolW >= 10 && roolW < 50) { Instantiate(weaponBox[1], transform.position, Quaternion.identity); }
                else if (roolW >= 50) { Instantiate(weaponBox[1], transform.position, Quaternion.identity); }

            }else
            {
                Debug.Log("Não Gerou Arma");
            }
        }
        else if(playerController.LifeActual <= 40)
        {
            Debug.Log("Menor que 40");
            if (rool < 50)
            {
                Debug.Log("Gerou Arma");
                if (roolW < 15) { Instantiate(weaponBox[2], transform.position, Quaternion.identity); }
                else if (roolW >= 15 && roolW < 80) { Instantiate(weaponBox[1], transform.position, Quaternion.identity); }
                else if (roolW >= 80) { Instantiate(weaponBox[1], transform.position, Quaternion.identity); }

            }
            else
            {
                Debug.Log("Não Gerou Arma");
            }
        }

    }
}
