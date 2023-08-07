using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input : MonoBehaviour
{
    bool _isJumping = false;
    float _xInput = 0f;
    float _yInput = 0f;

    public float XInput => _xInput;
    public float YInput => _yInput;
    public bool IsJumping { get => _isJumping; set { _isJumping = value;} }

    void Update()
    {
        PlayerMove();
        PlayerAction();
    }

    public void PlayerMove()
    {
        _xInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        _yInput = UnityEngine.Input.GetAxisRaw("Vertical");
        IsJumping = UnityEngine.Input.GetButton("Jump");
    }

    public void PlayerAction()
    {

    }
}
