using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Water water;

    private int coins;
    public int Coins
    {
        get => coins;

        set
        {
            coins = value;
            //player speed check
            //player sprite check
            //UI check
            if(coins >= 10)
            {
                water.SetTrigger();
            }
            else
            {
                water.SetCollider();
            }
        }
    }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;
        
        DontDestroyOnLoad(this);
    }
}