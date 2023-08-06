using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    bool _isJumping = false;
    float _xInput = 0f;
    float _yInput = 0f;

    public float XInput => _xInput;
    public float YInput => _yInput;
    public bool IsJumping { get => _isJumping; set { _isJumping = value;} }

    void Update()
    {
        PlayerAction();
    }

    public void PlayerAction()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
        _isJumping = Input.GetButton("Jump");
    }
}
