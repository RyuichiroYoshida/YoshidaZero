using UnityEngine;

public class Input : MonoBehaviour
{
    float _xInput = 0f;
    float _yInput = 0f;
    bool _isJumping = false;
    bool _isAttack = false;
    bool _timeAlter = false;
    bool _isPause = false;

    PlayerController _playerController;

    public float XInput => _xInput;
    public float YInput => _yInput;
    public bool IsJumping { get => _isJumping; set => _isJumping = value; }
    public bool IsAttack { get => _isAttack; set => _isAttack = value; }
    public bool TimeAlter => _timeAlter;
    public bool IsPause => _isPause;

    void Start()
    {
        _playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        Pause();
        if (!_isPause)
        {
            PlayerTimeAlter();
            if (!_playerController.IsAttacking)
            {
                PlayerMove();
                PlayerAction();
            }
        }
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

    public void PlayerTimeAlter()
    {
        _timeAlter = UnityEngine.Input.GetButton("Fire3");
    }

    public void Pause()
    {
        //print(IsPause);
        if (UnityEngine.Input.GetButton("Pause"))
        {
            _isPause = !_isPause;
        }
    }
}