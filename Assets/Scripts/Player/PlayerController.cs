using UnityEngine;

class PlayerController : MonoBehaviour
{
    private PlayerBehaviour _playerBehaviour;

    private void Start()
    {
        _playerBehaviour = GetComponent<PlayerBehaviour>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _playerBehaviour.Jump();
        }

        if (Input.GetKey(KeyCode.A))
        {
            _playerBehaviour.Move("left");
        }

        if (Input.GetKey(KeyCode.D))
        {
            _playerBehaviour.Move("right");
        }
    }
}