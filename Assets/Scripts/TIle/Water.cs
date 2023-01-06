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
        CheckWaterState();
    }

    public void SetCollider()
    {
        col.isTrigger = false;
    }

    public void SetTrigger()
    {
        col.isTrigger = true;
    }

    private void CheckWaterState()
    {
        if(GameManager.Instance.Coins >= 10)
        {
            SetTrigger();
        }
        else
        {
            SetCollider();
        }
    }
}
