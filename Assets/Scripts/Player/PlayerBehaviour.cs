using UnityEngine;
using UnityEngine.Serialization;

class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerStatus _statusJudge;
    public bool jumpable;
    private bool _doubleJumped;

    public float maxVelocityX = 5f;
    public float alpha = 10f;
    
    public void Jump()
    {
        if (_statusJudge.isOnGround && jumpable)
        {
            var boostedVelocity = new Vector3(_rigidbody.velocity.x, 7f, 0f);
            _rigidbody.velocity = boostedVelocity;
        }
        else if (!_doubleJumped && jumpable)
        {
            var boostedVelocity = new Vector3(_rigidbody.velocity.x * 0.3f, 5f, 0f);
            _rigidbody.velocity = boostedVelocity;
            _doubleJumped = true;
        }
    }

    public void Move(string direction)
    {
        float xVel = _rigidbody.velocity.x;

        if (direction == "left")
        {
            xVel = Mathf.Clamp(xVel - alpha * Time.deltaTime, -maxVelocityX, maxVelocityX);
        }
        else if (direction == "right")
        {
            xVel = Mathf.Clamp(xVel + alpha * Time.deltaTime, -maxVelocityX, maxVelocityX);
        }

        _rigidbody.velocity = new Vector2(xVel, _rigidbody.velocity.y);
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _statusJudge = GetComponent<PlayerStatus>();
        jumpable = true;
        _doubleJumped = false;
        GameManager.Instance.playerBehaviour = this;
        GameManager.Instance.Coins = GameManager.Instance.Coins;
    }

    private void Update()
    {
        if (_statusJudge.isOnGround) _doubleJumped = false;
        //print(_rigidbody.velocity.x);
    }

    public void SetBallState(float v, float a, float g = 1.0f)
    {
        maxVelocityX = v;
        alpha = a;
        _rigidbody.gravityScale = g;
    }

    public void SetDrag(float drag = 0f)
    {
        _rigidbody.drag = drag;
    }
}