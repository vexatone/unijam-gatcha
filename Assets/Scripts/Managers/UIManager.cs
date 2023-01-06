using UnityEngine;

class UIManager : MonoBehaviour
{
    private bool _paused;
    public void ShowPause()
    {
        
    }

    public void HidePause()
    {
        
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