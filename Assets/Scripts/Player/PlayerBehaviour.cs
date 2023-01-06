using UnityEngine;

class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private PlayerStatus _statusJudge;
    private bool _doubleJumped;

    public float maxVelocityX = 5f;
    public float alpha = 10f;
    
    public void Jump()
    {
        if (_statusJudge.isOnGround)
        {
            var boostedVelocity = new Vector3(_rigidbody.velocity.x, 7f, 0f);
            _rigidbody.velocity = boostedVelocity;
        }
        else if (!_doubleJumped)
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
        _doubleJumped = false;
    }

    private void Update()
    {
        if (_statusJudge.isOnGround) _doubleJumped = false;
        //print(_rigidbody.velocity.x);
        GameManager.Instance.playerBehaviour = this;
        CheckPlayerState();
    }

    public void SetEmptyBall()
    {
        maxVelocityX = 5f;
        alpha = 10f;
    }

    public void SetFullBall()
    {
        maxVelocityX = 3f;
        alpha = 7f;
    }

    private void CheckPlayerState()
    {
        if (GameManager.Instance.Coins >= 10)
        {
            SetFullBall();
        }
        else
        {
            SetEmptyBall();
        }
    }
}