using UnityEngine;

class PlayerStatus : MonoBehaviour
{
    public bool isOnGround()
    {
        var hit = Physics2D.Raycast(transform.position, Vector2.down);
        return (hit.collider == null);
    }
}