using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : MonoBehaviour
{
    public Tilemap destructableTilemap;
    public bool check = true;
    void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (check)
        {
            if (collision.gameObject.CompareTag("Player")) ;
            {
                Vector3 hitPosition = Vector3.zero;
                foreach (var hit in collision.contacts)
                {
                    hitPosition.x = hit.point.x - 0.01f * (hit.normal.x > 0 ? hit.normal.x : hit.normal.x * (-1));
                    hitPosition.y = hit.point.y - 0.01f * (hit.normal.y > 0 ? hit.normal.y : hit.normal.y * (-1));
                    check = false;
                    StartCoroutine(BreakTile(hitPosition));
                }
            }
        }
    }

    private IEnumerator BreakTile(Vector3 hitPosition)
    {
        yield return new WaitForSeconds(0.1f);
        check = true;
        yield return new WaitForSeconds(0.9f);
        destructableTilemap.SetTile(destructableTilemap.WorldToCell(hitPosition), null);
    }
}
