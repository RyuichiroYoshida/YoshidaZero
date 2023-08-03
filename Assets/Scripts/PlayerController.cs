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
    }

    void Update()
    {
        _playerStateMachine?.Update();
    }
}
