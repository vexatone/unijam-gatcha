using UnityEngine;
using TMPro;

class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    private bool _paused;
    [SerializeField] private GameObject uiCanvasPanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePopup;
    [SerializeField] private TextMeshProUGUI stageText;
    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI pauseStageText;
    [SerializeField] private TextMeshProUGUI pauseCoinText;
    [SerializeField] private TextMeshProUGUI pauseTimerText;

    public void Pause()
    {
        Time.timeScale = 0f;
        _paused = true;
        // TODO: 스테이지명, 동전 개수, 남은 시간 업데이트
        pauseStageText.text = $"{GameManager.Instance.StageIndex}. {GameManager.Instance.StageName}";
        pauseCoinText.text = $"{GameManager.Instance.Coins} / {20}";
        pauseTimerText.text = $"{GameManager.Instance.TimeLeft}";
        uiCanvasPanel.SetActive(true);
        pausePopup.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        _paused = false;
        uiCanvasPanel.SetActive(false);
        pausePopup.SetActive(false);
    }

    public void ShowPause()
    {
        pauseButton.SetActive(true);
    }

    public void HidePause()
    {
        pauseButton.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        Pause();
    }

    public void OnPausePopupResumeButtonClick()
    {
        Resume();
    }

    public void OnPausePopupRestartButtonClick()
    {
        GameManager.Instance.Restart();
    }

    public void OnPausePopupMainMenuButtonClick()
    {
        GameManager.Instance.LoadScene("MainMenu");
    }

    public void OnPausePopupExitButtonClick()
    {
        GameManager.Instance.Quit();

    }

    public void UpdateStage(int? index, string? name)
    {
        int i = index ?? GameManager.Instance.StageIndex;
        string s = name ?? GameManager.Instance.StageName;
        stageText.text = $"{i}. {s}";
    }

    public void UpdateCoinCount(int coin)
    {
        if (coin < 10)
            coinText.text = $"<#FFFFFF>{coin}</color> / {GameManager.MaxCoinCount}";
        else if (coin < 15)
            coinText.text = $"<#C0C0C0>{coin}</color> / {GameManager.MaxCoinCount}";
        else
            coinText.text = $"<#FFD700>{coin}</color> / {GameManager.MaxCoinCount}";
    }

    public void UpdateTimeLeft(int timeLeft)
    {
        if (timeLeft >= 100)
            timerText.text = $"{timeLeft}";
        else if (timeLeft >= 50)
            timerText.text = $"<#FFE0E0>{timeLeft}</color>";
        else if (timeLeft >= 10)
            timerText.text = $"<#FFBABA>{timeLeft}</color>";
        else
            timerText.text = $"<#FF7070>{timeLeft}</color>";
    }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;
    }

    private void Start()
    {
        Resume();
        GameManager.Instance.Initialize();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_paused)
                Resume();
            else
                Pause();
        }
    }
}