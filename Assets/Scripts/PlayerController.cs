using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 5;
    [SerializeField] float _jumpPower = 5;
    [SerializeField] float _jumpCoolTime = 2;
    [SerializeField] float _jumpCoolTimer = 0;
    [SerializeField] float _attackCoolTime = 1;
    [SerializeField] float _attackCoolTimer = 0;
    [SerializeField] float _comboTime1 = 3;
    [SerializeField] float _comboTimer1 = 0;
    [SerializeField] float _comboTime2 = 2;
    [SerializeField] float _comboTimer2 = 0;

    [SerializeField] bool _isGround = true;
    [SerializeField] bool _isAttacking = false;
    [SerializeField] bool _comboTrigger1 = false;
    [SerializeField] bool _comboTrigger2 = false;

    Rigidbody2D _rb;

    private AnimController _playerAnimController;
    public AnimController PlayerAnimController => _playerAnimController;
    private Attack _playerAttack;
    public Attack PlayerAttack => _playerAttack;
    private Input _playerInput;
    public Input PlayerInput => _playerInput;
    private StateMachine _playerStateMachine;
    public StateMachine PlayerStateMachine => _playerStateMachine;
    public bool IsGruound => _isGround;
    public bool IsAttacking { get => _isAttacking; set { _isAttacking = value;} }
    public bool ComboTrigger1 { get => _comboTrigger1; set { _comboTrigger1 = value;} }
    public bool ComboTrigger2 { get => _comboTrigger2; set { _comboTrigger2 = value;} }

    private void Awake()
    {
        _playerStateMachine = new StateMachine(this); // PlayerStateMachine初期化
    }
    void Start()
    {
        _playerStateMachine.Initialize(PlayerStateMachine.idleState); // 最初はIdleStateから始めるのでStartで呼ぶ
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<Input>();
        _playerAnimController = GetComponent<AnimController>();
        _playerAttack = GetComponent<Attack>();
    }

    void Update()
    {
        _playerStateMachine?.Update(); // PlayerStateMachineがNullではないときに、常時StateMachineを呼び出す
        Move();
        Jump();
        Attack();
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

    void Attack()
    {
        _attackCoolTimer -= Time.deltaTime;
        _comboTimer1 += Time.deltaTime;
        _comboTimer2 += Time.deltaTime;
        if (PlayerInput.IsAttack && _attackCoolTimer <= 0)
        {
            _attackCoolTimer = _attackCoolTime;
            _comboTimer1 = 0;
            _isAttacking = true;
            PlayerAnimController.PlayerAttackAnim(true);
            
            if (PlayerInput.IsAttack && _comboTimer1 <= _comboTime1)
            {
                _comboTrigger1 = true;
                _comboTimer2 = 0;
                if (PlayerInput.IsAttack && _comboTimer2 <= _comboTime2)
                {
                    _comboTrigger2 = true;
                }
            }
        }
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
