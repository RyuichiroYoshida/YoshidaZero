using UnityEngine;

public class FlipXController : MonoBehaviour
{
    SpriteRenderer _sr;
    Input _playerInput;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _playerInput = GetComponent<Input>();
    }

    void Update()
    {
        if (_playerInput.XInput == 1)
        {
            _sr.flipX = true;
        }
        else
        {
            _sr.flipX = false;
        }
    }
}
