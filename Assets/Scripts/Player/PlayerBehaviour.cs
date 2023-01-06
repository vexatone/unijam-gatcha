using UnityEngine;

class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _doubleJumped;
    
    public void Jump()
    {
        if (!GetComponent<PlayerStatus>().isOnGround()) return;
        var boostedVelocity = new Vector3(_rigidbody.velocity.x, 10f, 0f);
        _rigidbody.velocity = boostedVelocity;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
}