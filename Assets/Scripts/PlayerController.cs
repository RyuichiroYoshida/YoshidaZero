using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpPower = 5;
    [SerializeField] float _jumpCoolTime = 2;
    [SerializeField] float _jumpCoolTimer = 0;
     
    [SerializeField] bool _isGround = true;

    Rigidbody2D _rb;

    private Input _playerInput;
    public Input PlayerInput => _playerInput;
    private StateMachine _playerStateMachine;
    public StateMachine PlayerStateMachine => _playerStateMachine;
    public bool IsGruound => _isGround;

    private void Awake()
    {
        _playerStateMachine = new StateMachine(this); // PlayerStateMachine初期化
    }
    void Start()
    {
        _playerStateMachine.Initialize(PlayerStateMachine.idleState); // 最初はIdleStateから始めるのでStartで呼ぶ
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<Input>();

    }

    void Update()
    {
        _playerStateMachine?.Update(); // PlayerStateMachineがNullではないときに、常時StateMachineを呼び出す
        Move();
        Jump();
    }

    /// <summary>Jump挙動管理メソッド</summary>
    void Jump()
    {
        _jumpCoolTimer -= Time.deltaTime;
        if (_isGround == true && PlayerInput.IsJumping == true && _jumpCoolTimer <= 0) // 接地している、ジャンプ入力がある、クールダウンタイマーが0以下
        {
            _jumpCoolTimer = _jumpCoolTime;
            _rb.velocity = new Vector2(0, _jumpPower);
        }
    }

    /// <summary>水平移動管理メソッド</summary>
    void Move()
    {
        _rb.velocity = new Vector2(_moveSpeed * _playerInput.XInput, _rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
        }
    }
}
