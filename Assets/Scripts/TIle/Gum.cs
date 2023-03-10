using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gum : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var player = col.gameObject.GetComponent<PlayerBehaviour>();
            player.jumpable = false;
            player.SetBallState(1.5f, 4.0f);
            player.SetDrag(2f);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            var player = col.gameObject.GetComponent<PlayerBehaviour>();
            player.jumpable = true;
            player.SetBallState(5.0f, 10.0f);
            player.SetDrag();
        }
    }
}
