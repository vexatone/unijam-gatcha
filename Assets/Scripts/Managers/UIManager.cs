using UnityEngine;

class UIManager : MonoBehaviour
{
    private bool _paused;
    [SerializeField] private GameObject button;
    
    public void ShowPause()
    {
        button.SetActive(true);
    }

    public void HidePause()
    {
        button.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        if (_paused)
        {
            Time.timeScale = 1f;
            _paused = false;
        }
        else
        {
            Time.timeScale = 0f;
            _paused = true;
        }
    }

    private void Start()
    {
        _paused = false;
    }
}