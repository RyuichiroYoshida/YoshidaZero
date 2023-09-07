using UnityEngine;

public class PlayerReverse : MonoBehaviour
{
    Transform _playerTransform;
    Input _playerInput;
    void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _playerInput = GetComponent<Input>();
    }

    void Update()
    {
        if (_playerInput.XInput == -1)
        {
            _playerTransform.localScale = new Vector2(-1, 1);
        }
        if (_playerInput.XInput == 1)
        {
            _playerTransform.localScale = new Vector2(1, 1);
        }
    }
}
