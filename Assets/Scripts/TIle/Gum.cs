using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var player = col.gameObject.GetComponent<PlayerBehaviour>();
            player.jumpable = false;
            player.SetBallState(3.0f, 7.0f);
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var player = col.gameObject.GetComponent<PlayerBehaviour>();
            player.jumpable = true;
            player.SetBallState(5.0f, 10.0f);
        }
    }
}
