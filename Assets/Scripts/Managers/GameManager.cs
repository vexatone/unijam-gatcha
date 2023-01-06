using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;
        
        DontDestroyOnLoad(this);
    }
}