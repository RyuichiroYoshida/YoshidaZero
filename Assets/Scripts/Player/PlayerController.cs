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
    [SerializeField] float _attackWait = 0.5f;
    [SerializeField] bool _isGround = true;
    [SerializeField] bool _isAttacking = false;

    Rigidbody2D _rb;

    private AnimController _playerAnimController;
    public AnimController PlayerAnimController => _playerAnimController;
    private Attack _playerAttack;
    public Attack PlayerAttack => _playerAttack;
    private Input _playerInput;
    public Input PlayerInput => _playerInput;
    public bool IsGruound => _isGround;
    public bool IsAttacking { get => _isAttacking; set => _isAttacking = value; }

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<Input>();
        _playerAnimController = GetComponent<AnimController>();
        _playerAttack = GetComponent<Attack>();
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    /// <summary>Jump挙動管理メソッド</summary>
    void Jump()
    {
        _playerAnimController.PlayerJumpAnim(false);
        _jumpCoolTimer -= Time.deltaTime;
        if (_isGround == true && PlayerInput.IsJumping == true && _jumpCoolTimer <= 0) // 接地している、ジャンプ入力がある、クールダウンタイマーが0以下
        {
            _jumpCoolTimer = _jumpCoolTime;
            _rb.velocity = new Vector2(0, _jumpPower);
            _playerAnimController.PlayerJumpAnim(true);
        }
    }

    /// <summary>水平移動管理メソッド</summary>
    void Move()
    {
        _rb.velocity = new Vector2(_moveSpeed * _playerInput.XInput, _rb.velocity.y);
        if (_playerInput.XInput != 0)
            _playerAnimController.PlayerMoveAnim(true);
        else
            _playerAnimController.PlayerMoveAnim(false);
    }

    void Attack()
    {
        PlayerAnimController.PlayerAttackAnim(false);
        _attackCoolTimer -= Time.deltaTime;
        if (PlayerInput.IsAttack && _attackCoolTimer <= 0)
        {
            _attackCoolTimer = _attackCoolTime;
            _isAttacking = true;
            PlayerAnimController.PlayerAttackAnim(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = true;
            _playerAnimController.PlayerAirAnim(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGround = false;
            _playerAnimController.PlayerAirAnim(false);
        }
    }
}
