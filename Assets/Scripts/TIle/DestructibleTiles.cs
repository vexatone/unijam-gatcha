using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTiles : MonoBehaviour
{
    public Tilemap destructableTilemap;
    public bool check = true;
    private GameObject _brokenTile;

    void Start()
    {
        destructableTilemap = GetComponent<Tilemap>();
        _brokenTile = transform.GetChild(0).gameObject;
        _brokenTile.SetActive(false);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (check)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                Vector3 hitPosition = Vector3.zero;
                foreach (var hit in collision.contacts)
                {
                    hitPosition.x = hit.point.x - 0.01f * (hit.normal.x > 0 ? hit.normal.x : hit.normal.x * (-1));
                    hitPosition.y = hit.point.y - 0.01f * (hit.normal.y > 0 ? hit.normal.y : hit.normal.y * (-1));
                    check = false;
                    StartCoroutine(BreakTile(hitPosition));
                    break;
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
        StartCoroutine(BreakTileAnimation(hitPosition));
        yield return null;
    }

    private IEnumerator BreakTileAnimation(Vector3 hitPosition)
    {
        GameObject newBrokenTile = Instantiate(_brokenTile, hitPosition, Quaternion.identity);
        newBrokenTile.SetActive(true);
        SpriteRenderer brokenTileRenderer = newBrokenTile.GetComponent<SpriteRenderer>();
        yield return new WaitForEndOfFrame();
        for (int i = 0; i < 10; i++)
        {
            newBrokenTile.transform.position -= new Vector3(0, 0.1f, 0);
            Color color = brokenTileRenderer.color;
            color.a -= 0.09f;
            brokenTileRenderer.color = color;
            yield return new WaitForEndOfFrame();
        }
        Destroy(newBrokenTile);
        yield return null;
    }
}
