using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.Restart();
        }
    }
}
