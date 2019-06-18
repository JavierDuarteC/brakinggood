using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;



    public enum GameStates
    {
        PLAYING,
        WIN,
        LOSE
    }

    //Variables del juego
    [Header("Tiempo para jugar:")] public float tiempoInicial;
    [Header("Quimicos inicial:")] public float quimicosIni;

    [SerializeField] private HealthBar healthBar;

    private float _tiempo;
    private float _quimico;
    public float Quimico
    {
        get => _quimico;
        set => _quimico = value;
    }
    public float Tiempo
    {
        get => _tiempo;
        set => _tiempo = value;
    }

    private int _nivel;
    public int Nivel
    {
        get => _nivel;
        set => _nivel = value;
    }

    private Scene _gameScene;

    public Scene GameScene
    {
        get => _gameScene;
        set => _gameScene = value;
    }
    private GameStates gameState;

    public GameStates GameState
    {
        get => gameState;
        set => gameState = value;
    }



    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }


    // Start is called before the first frame update
    void Start()
    {
        Tiempo = tiempoInicial;
        Quimico = quimicosIni;

        healthBar.SetSize(0f);
        healthBar.SetColor(Color.cyan);
        GameScene = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update()
    {
        //check game states
        if (GameState.Equals(GameStates.LOSE))
        {
            Tiempo = 0f;
            Quimico = 0f;
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }

        // //Check Scenes
        // if (GameScene.name.Equals("Titulo"))
        //     Tiempo = 0f;
        print(_quimico);
        if (_quimico < 10)
            healthBar.SetSize(_quimico / 10);
        else if (_quimico == 10)
        {
            healthBar.SetColor(Color.green);
            healthBar.SetSize(_quimico / 10);
        }
        else if (_quimico == 11)
        {
            healthBar.SetColor(Color.red);
        }
        else if (_quimico == 12)
        {
            GameState = GameStates.LOSE;
        }

        if (GameState.Equals(GameStates.WIN))
        {
            Tiempo = 0f;
            Quimico = 0f;
            SceneManager.LoadScene("Win");
        }
        // if (_quimico > 0)
        // {
        //     healthBar.SetSize(_quimico / 10);
        // }
        // if (_quimico == 11)
        // {
        //     healthBar.SetColor(Color.red);
        // }


    }
}