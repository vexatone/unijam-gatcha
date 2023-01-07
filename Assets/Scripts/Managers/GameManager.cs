using UnityEngine;
using UnityEngine.SceneManagement;

class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Water water;
    public PlayerBehaviour playerBehaviour;

    public const int MaxCoinCount = 20;

    private int stageIndex;
    public int StageIndex
    {
        get => stageIndex;
        set
        {
            stageIndex = value;
            UIManager.Instance.UpdateStage(stageIndex, null);
        }
    }

    private string stageName;
    public string StageName
    {
        get => stageName;
        set
        {
            stageName = value;
            UIManager.Instance.UpdateStage(null, stageName);
        }
    }
    private string currentSceneName;

    private float oneSecondBuffer;
    private int timeLeft;
    public int TimeLeft
    {
        get => timeLeft;
        set
        {
            timeLeft = value;
            if (timeLeft < 0)
            {
                GameOver();
            }
            UIManager.Instance.UpdateTimeLeft(timeLeft);
        }
    }

    private int coins;
    public int Coins
    {
        get => coins;

        set
        {
            coins = value;
            //player sprite check
            UIManager.Instance.UpdateCoinCount(coins);

            if(coins >= 10)
            {
                water.SetTrigger();
                playerBehaviour.SetBallState(3.0f, 7.0f, 1.5f);
            }
            else
            {
                water.SetCollider();
                playerBehaviour.SetBallState(5.0f, 10.0f);
            }
        }
    }

    public void GameOver()
    {
        print("Game Over...");
    }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;
        coins = 0;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        // TODO: 임시 코드. 나중에 데이터 만들면 지워야 함
        StageIndex = 1;
        StageName = "완구점";
        TimeLeft = 200;
        oneSecondBuffer = 0;
    }

    private void Update()
    {
        // TODO: 테스트용 코드. 나중에 데이터 만들면 지워야 함
        /*
        TimeLeft = TimeLeft - 1;
        if (TimeLeft < 0)
            TimeLeft = 200;
        Coins = Coins + 1;
        if (Coins >= 20)
        {
            Coins = 0;
        }
        */
        print($"{oneSecondBuffer}");
        if (oneSecondBuffer >= 1f)
        {
            TimeLeft -= 1;
            oneSecondBuffer -= 1f;
        }
        oneSecondBuffer += Time.deltaTime;
    }
    
    public void LoadScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);
        currentSceneName = nextScene;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        LoadScene(currentSceneName);
    }
}