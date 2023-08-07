using UnityEngine;
using UnityEngine.Windows;

public class Input : MonoBehaviour
{
    float _xInput = 0f;
    float _yInput = 0f;
    bool _isJumping = false;
    bool _isAttacking = false;

    public float XInput => _xInput;
    public float YInput => _yInput;
    public bool IsJumping { get => _isJumping; set { _isJumping = value;} }
    public bool IsAttacking { get => _isAttacking; set { _isAttacking = value;} }

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
        IsAttacking = UnityEngine.Input.GetButton("Fire1");
    }
}
