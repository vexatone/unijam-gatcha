using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

class MouseBehaviour : MonoBehaviour
{
    [SerializeField] private float wanderSpeed = 2.0f;
    [SerializeField] private float chaseSpeed = 4.0f;
    private Rigidbody2D _rigidbody;
    private MouseAnimator _animator;
    private GameObject _playerObject;
    private int _wanderDirection = 1;
    private bool _isEnraged = false;

    private void Start()
    {
        StartCoroutine("Wander");
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<MouseAnimator>();
    }

    private void Update()
    {
        UpdateEnragedState();

        // Maybe need improvement
        if (!_isEnraged)
        {
            _animator.direction = (_wanderDirection > 0) ? "right" : "left";
            var vel = new Vector3(_wanderDirection * wanderSpeed, _rigidbody.velocity.y, 0f);
            _rigidbody.velocity = vel;
        }
        else if (_playerObject.transform.position.x >= transform.position.x)
        {
            _animator.direction = "right";
            var vel = new Vector3(chaseSpeed, _rigidbody.velocity.y, 0f);
            _rigidbody.velocity = vel;
        }
        else if (_playerObject.transform.position.x < transform.position.x)
        {
            _animator.direction = "left";
            var vel = new Vector3(-chaseSpeed, _rigidbody.velocity.y, 0f);
            _rigidbody.velocity = vel;
        }
    }

    private void UpdateEnragedState()
    {
        if (!_isEnraged && Mathf.Abs(transform.position.x - _playerObject.transform.position.x) <= 4f
                        && Mathf.Abs(transform.position.y - _playerObject.transform.position.y) <= 1f)
        {
            _isEnraged = true;
            SoundManager.Instance.PlayEffect("Mouse");
        }
        else if (_isEnraged && Mathf.Abs(transform.position.x - _playerObject.transform.position.x) >= 4f)
        {
            _isEnraged = false;
        }
    }

    private IEnumerator Wander()
    {
        while (true)
        {
            _wanderDirection = 1;
            yield return new WaitForSeconds(1f);
            _wanderDirection = -1;
            yield return new WaitForSeconds(1f);
        }
    }
}