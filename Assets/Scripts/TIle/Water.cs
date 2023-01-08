using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private CompositeCollider2D col;
    
    void Start()
    {
        col = GetComponent<CompositeCollider2D>();
        GameManager.Instance.water = this;
        GameManager.Instance.Coins = GameManager.Instance.Coins;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //SoundManager.Instance.PlayEffect("Water");
    }

    public void SetCollider()
    {
        if(col != null)
            col.isTrigger = false;
    }

    public void SetTrigger()
    {
        if (col != null)
            col.isTrigger = true;
    }
}
