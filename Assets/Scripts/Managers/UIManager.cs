using UnityEngine;

class UIManager : MonoBehaviour
{
    private bool _paused;
    [SerializeField] private GameObject uiCanvasPanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pausePopup;

    public void Pause()
    {
        Time.timeScale = 0f;
        _paused = true;
        // TODO: 스테이지명, 동전 개수, 남은 시간 업데이트
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

    // TODO: 나머지 버튼 OnClick 함수 만들기

    private void Start()
    {
        Resume();
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