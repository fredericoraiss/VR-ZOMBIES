using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour {

    #region Encapsulamento/Singleton
    private static GameController instance;
    public static GameController Instance { get; private set; }

    public bool StartGame
    {
        get
        {
            return startGame;
        }

        set
        {
            startGame = value;
        }
    }

    public bool ChangedScreen
    {
        get
        {
            return changedScreen;
        }

        set
        {
            changedScreen = value;
        }
    }

    public string SceneName
    {
        get
        {
            return sceneName;
        }

        set
        {
            sceneName = value;
        }
    }

    public int NumberZombiesDestroied
    {
        get
        {
            return numberZombiesDestroied;
        }

        set
        {
            numberZombiesDestroied = value;
        }
    }

    #endregion



    [SerializeField]    private bool startGame = false;
    [SerializeField]    private bool changedScreen = false;

    [SerializeField]    private string sceneName = "";

    [SerializeField]
    private int numberZombiesDestroied = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("Novo GameController");
            Instance = this;
            ChangedScreen = true;
        }
        else
        {
            Debug.Log("Destruiu GameController");
            Instance.ChangedScreen = true;
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }


    // Use this for initialization
    void Start () {
        ChangedScreen = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (ChangedScreen)
        {
            SceneName = SceneManager.GetActiveScene().name;
        }
        
        #region GAME SCENE

        if (SceneName.Equals("Game"))
        {
            if (ChangedScreen)
            {
                //i_PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
                StartCoroutine(IE_StartGame());

                ChangedScreen = false;
            }
        }
        
        #endregion 



    }

    private IEnumerator IE_StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        StartGame = true;
    }
}
