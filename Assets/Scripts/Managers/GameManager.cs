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
                playerBehaviour.SetBallState(3.0f, 7.0f, 1.5f);
            }
            else
            {
                water.SetCollider();
                playerBehaviour.SetBallState(5.0f, 10.0f);
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