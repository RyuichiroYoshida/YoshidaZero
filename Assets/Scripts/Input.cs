using UnityEngine;

public class Input : MonoBehaviour
{
    float _xInput = 0f;
    float _yInput = 0f;
    bool _isJumping = false;
    bool _isAttack = false;
    bool _isDashing = false;
    bool _isPause = false;

    public float XInput => _xInput;
    public float YInput => _yInput;
    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public bool IsAttack { get => _isAttack; set => _isAttack = value; }
    public bool IsDashing => _isDashing;
    public bool IsPause => _isPause;

    void Update()
    {
        if (_isPause)
            return;
        PlayerMove();
        PlayerAction();
        Pause();
    }

    public void PlayerMove()
    {
        _xInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        _yInput = UnityEngine.Input.GetAxisRaw("Vertical");
        IsJumping = UnityEngine.Input.GetButton("Jump");
    }

    public void PlayerAction()
    {
        IsAttack = UnityEngine.Input.GetButton("Fire1");
    }

    public void PlayerDash()
    {
        _isDashing = UnityEngine.Input.GetButton("Fire3");
    }

    public void Pause()
    {
        if (UnityEngine.Input.GetButton("Pause"))
            _isPause = !_isPause;
    }
}
