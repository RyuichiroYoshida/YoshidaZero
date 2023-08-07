using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpPower = 5;
    [SerializeField] float _jumpCoolTime = 2;
     
    [SerializeField] bool _isGround = true;

    Rigidbody2D _rb;

    private Input _playerInput;
    public Input PlayerInput => _playerInput;
    private StateMachine _playerStateMachine;
    public StateMachine PlayerStateMachine => _playerStateMachine;
    public bool IsGruound => _isGround;

    private void Awake()
    {
        _playerStateMachine = new StateMachine(this);
    }
    void Start()
    {
        _playerStateMachine.Initialize(PlayerStateMachine.idleState);
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<Input>();

    }

    void Update()
    {
        _playerStateMachine?.Update();
        Move();
        Jump();
    }

    void Jump()
    {
        if (_isGround == true && PlayerInput.IsJumping == true)
        {
            _rb.velocity = new Vector2(0, _jumpPower);
            _playerStateMachine.Initialize(PlayerStateMachine.jumpState);
        }
    }

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
