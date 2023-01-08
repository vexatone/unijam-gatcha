using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public struct StageInfo
{
    public StageInfo(int stageIndex, string stageName, int timeLeft)
    {
        StageIndex = stageIndex;
        StageName = stageName;
        TimeLeft = timeLeft;
    }
    public int StageIndex { get; }
    public string StageName { get; }
    public int TimeLeft { get; }

    public readonly static Dictionary<string, StageInfo> StageInformations = new Dictionary<string, StageInfo>()
    {
        { "MainMenu", new StageInfo(0, "메인 화면", 200) },
        { "Stage1", new StageInfo(1, "완구점", 200) },
        { "Stage2", new StageInfo(2, "푸드코트", 200) },
        { "Stage3", new StageInfo(3, "완구점", 200) },
    };
};

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
            if(value>coins)
            {
                SoundManager.Instance.PlayEffect("Coin1");
            }
            coins = value;
            //player sprite check
            UIManager.Instance.UpdateCoinCount(coins);

            if(coins<5)
            {
                if (water != null)
                    water.SetCollider();
                playerBehaviour.SetBallState(5.0f, 10.0f, 1.0f);
            }
            else if(coins < 10 && coins >=5)
            {
                if (water != null)
                    water.SetCollider();
                playerBehaviour.SetBallState(5.0f, 9.5f, 1.1f);
            }
            else if (coins < 15 && coins >= 10)
            {
                if (water != null)
                    water.SetTrigger();
                playerBehaviour.SetBallState(5.0f, 9.0f, 1.2f);
            }
            else if (coins < 20 && coins >= 15)
            {
                if (water != null)
                    water.SetTrigger();
                playerBehaviour.SetBallState(5.0f, 8.5f, 1.3f);
            }
            else
            {
                if (water != null)
                    water.SetTrigger();
                playerBehaviour.SetBallState(5.0f, 8.0f, 1.4f);
            }
        }
    }
    public int resetCoin;

    private bool _isGameOngoing = false;

    public void GameOver()
    {
        Restart();
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
        SoundManager.Instance.PlayBgm("MainMenu");
    }

    private void Update()
    {
        if (_isGameOngoing)
        {
            if (oneSecondBuffer >= 1f)
            {
                TimeLeft -= 1;
                oneSecondBuffer -= 1f;
            }
            oneSecondBuffer += Time.deltaTime;
        }
    }
    
    public void LoadScene(string nextScene)
    {
        if (nextScene == "Ending")
        {
            if (Coins > 10)
            {
                string ending = "HappyEnding";
                currentSceneName = ending;
                SoundManager.Instance.PlayEffect("NextScene");
                SceneManager.LoadScene(ending);
                SoundManager.Instance.PlayBgm(ending);
            }
            else
            {
                string ending = "BadEnding";
                currentSceneName = ending;
                SoundManager.Instance.PlayEffect("NextScene");
                SceneManager.LoadScene(ending);
                SoundManager.Instance.PlayBgm(ending);
            }
        }
        else
        {
            currentSceneName = nextScene;
            SoundManager.Instance.PlayEffect("NextScene");
            SceneManager.LoadScene(nextScene);
            SoundManager.Instance.PlayBgm(nextScene);
            resetCoin = Coins;
        }
    }

    public void Initialize()
    {
        StageInfo info = StageInfo.StageInformations[currentSceneName];
        StageIndex = info.StageIndex;
        StageName = info.StageName;
        TimeLeft = info.TimeLeft;
        oneSecondBuffer = 0;
        _isGameOngoing = true;
    }

    public void StopGame()
    {
        _isGameOngoing = false;
    }
    
    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(currentSceneName);
        SoundManager.Instance.PlayEffect("NextScene");
        Coins = resetCoin;
    }
}