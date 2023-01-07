using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FootState
{
    Initial,
    Rising,
    Thwomp,
    Stay,
    Return
}

public class FootController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _initialPosition;
    private float _thwompClock;
    private FootState _thwompState;
    private bool _grounded;

    public float risingHeight;
    public float risingSpeed;
    public float thwompSpeed;
    public float returnSpeed;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            _grounded = true;
        }
    }
    private void OnCollisionExit2D()
    {
        _grounded = false;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
        _thwompClock = 0f;
        _thwompState = FootState.Initial;
    }

    void Update()
    {
        switch (_thwompState)
        {
            // 처음에는 가만히 있음
            case FootState.Initial:
            {
                if (_thwompClock < 0.5f)
                {
                    _rigidbody.velocity = new Vector2(0, 0);
                    _thwompClock += Time.deltaTime;
                }
                else
                {
                    _thwompClock = 0;
                    _thwompState = FootState.Rising;
                }
            }
            break;

            // 천천히 들어올림
            case FootState.Rising:
            {
                float riseHeight = transform.position.y - _initialPosition.y;
                if (riseHeight < risingHeight)
                {
                    _rigidbody.velocity = new Vector2(0, risingSpeed);
                }
                else
                {
                    _thwompState = FootState.Thwomp;
                }
            }
            break;

            // 내리찍음
            case FootState.Thwomp:
            {
                if (!_grounded)
                    _rigidbody.velocity = new Vector2(0, -thwompSpeed);
                else
                {
                    _rigidbody.velocity = new Vector2(0, 0);
                    _thwompState = FootState.Stay;
                }
            }
            break;

            // 찍은 상태에서 가만히 있음
            case FootState.Stay:
            {
                if (_thwompClock < 1.5f)
                {
                    _rigidbody.velocity = new Vector2(0, 0);
                    _thwompClock += Time.deltaTime;
                }
                else
                {
                    _thwompClock = 0;
                    _thwompState = FootState.Return;
                }
            }
            break;

            // 다시 천천히 올라감
            case FootState.Return:
            {
                if (transform.position.y < _initialPosition.y)
                    _rigidbody.velocity = new Vector2(0, returnSpeed);
                else
                    _thwompState = FootState.Initial;
            }
            break;
        }
    }
}
