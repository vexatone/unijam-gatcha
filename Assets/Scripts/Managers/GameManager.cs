using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Water water;
    public PlayerBehaviour playerBehaviour;

    private int coins;
    public int Coins
    {
        get => coins;

        set
        {
            coins = value;
            //player sprite check
            //UI check
            if(coins >= 10)
            {
                water.SetTrigger();
                playerBehaviour.SetFullBall();
            }
            else
            {
                water.SetCollider();
                playerBehaviour.SetEmptyBall();
            }
        }
    }

    private void Awake()
    {
        // Singleton
        if (Instance != null && Instance != this) Destroy(this);
        Instance = this;
        coins = 0;
        DontDestroyOnLoad(this);
    }
}