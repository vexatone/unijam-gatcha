using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class StorySceneManager : MonoBehaviour
{
    [SerializeField] private List<string> cutScenePaths;
    [SerializeField] private GameObject imageObject;

    private Image _image;
    private int _currentScene;

    private void Start()
    {
        _currentScene = 0;
        if (cutScenePaths.Count == 0)
        {
            SceneManager.LoadScene("Stage1");
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
            if (_currentScene == cutScenePaths.Count) SceneManager.LoadScene("Stage1");

            LoadCurrentImage();
        }
    }
}