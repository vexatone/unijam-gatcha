using UnityEngine;

class PlayerStatus : MonoBehaviour
{
    public bool isOnGround { get; private set; }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.GetContact(0).point.y < transform.position.y)
        {
            isOnGround = true;
        }
    }

    private void OnCollisionExit2D()
    {
        isOnGround = false;
    }
}