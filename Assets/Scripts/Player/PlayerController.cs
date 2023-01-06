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

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _playerBehaviour.Move("left");
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _playerBehaviour.Move("right");
        }
    }
}