using UnityEngine;

class PlayerStatus : MonoBehaviour
{
    public float Radius { get; private set; }
    public bool isOnGround { get; private set; }

    private void OnCollisionStay2D(Collision2D col)
    {
        /*
        float delta_y = transform.position.y - col.GetContact(0).point.y;
        // 70도보다 큰 벽은 벽 판정
        // print($"Delta_y = {delta_y}, Threshold = {Radius * Mathf.Cos(70 * Mathf.Deg2Rad)}");
        if (delta_y > Radius * Mathf.Cos(70 * Mathf.Deg2Rad))
        {
            isOnGround = true;
        }
        Debug.Log(delta_y);
        */

        bool groundContacts = false;
        foreach (ContactPoint2D colPoint in col.contacts)
        {
            float delta_y = transform.position.y - colPoint.point.y;
            if (delta_y > Radius * Mathf.Cos(70 * Mathf.Deg2Rad))
            {
                groundContacts = true;
                break;
            }
        }

        isOnGround = groundContacts;
    }

    private void OnCollisionExit2D()
    {
        isOnGround = false;
    }

    private void Start()
    {
        Radius = GetComponent<CircleCollider2D>().radius;
    }
}