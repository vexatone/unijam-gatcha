using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class StorySceneManager : MonoBehaviour
{
    [SerializeField] private List<string> cutScenePaths;
    [SerializeField] private GameObject imageObject;
    [SerializeField] private bool isEnding;

    private Image _image;
    private int _currentScene;

    private void Start()
    {
        _currentScene = 0;
        if (cutScenePaths.Count == 0)
        {
            if (isEnding)
            {
                GameManager.Instance.Quit();
            }
            else
            {
                GameManager.Instance.LoadScene("Stage1");
            }
        }

        _image = imageObject.GetComponent<Image>();
        LoadCurrentImage();
    }

    public void LoadCurrentImage()
    {
        _image.sprite = Resources.Load<Sprite>(cutScenePaths[_currentScene]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentScene++;
            if (_currentScene == cutScenePaths.Count)
            {
                if (isEnding)
                {
                    GameManager.Instance.Quit();
                }
                else
                {
                    GameManager.Instance.LoadScene("Stage1");
                }
            }

            LoadCurrentImage();
        }
    }
}