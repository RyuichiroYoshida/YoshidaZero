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
    [SerializeField] bool _isAttackReady = false;
    Rigidbody2D _rb;
    AnimController _playerAnimController;
    public AnimController PlayerAnimController => _playerAnimController;
    Attack _playerAttack;
    Input _playerInput;
    public Input PlayerInput => _playerInput;
    public bool IsGround => _isGround;
    public bool IsAttackReady { get => _isAttackReady; set => _isAttackReady = value; }

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

    /// <summary>Jump�����Ǘ����\�b�h</summary>
    void Jump()
    {
        _playerAnimController.PlayerJumpAnim(false);
        _jumpCoolTimer -= Time.deltaTime;
        if (_isGround == true && PlayerInput.IsJumping == true && _jumpCoolTimer <= 0) // �ڒn���Ă���A�W�����v���͂�����A�N�[���_�E���^�C�}�[��0�ȉ�
        {
            _jumpCoolTimer = _jumpCoolTime;
            _rb.velocity = new Vector2(0, _jumpPower);
            _playerAnimController.PlayerJumpAnim(true);
        }
    }

    /// <summary>�����ړ��Ǘ����\�b�h</summary>
    void Move()
    {
        // �v���C���[�̍U���A�j���[�V�������I�����Ă���Ƃ��ړ��������s��
        // �v���C���[�̍U���A�j���[�V���������s���͕����������~�߂�
        if (_playerAttack.AttackEnd)
        {
            _rb.velocity = new Vector2(_moveSpeed * _playerInput.XInput, _rb.velocity.y);
            // �v���C���[��X�����͂��󂯎�����Ƃ��A�j���[�^�[��bool��؂�ւ���
            if (_playerInput.XInput != 0)
                _playerAnimController.PlayerMoveAnim(true);
            else
                _playerAnimController.PlayerMoveAnim(false);
        }
        else
            _rb.Sleep();
        if (GameManager.instance.IsDead)
            _rb.Sleep();
    }
    /// <summary>
    /// �v���C���[�U���������䃁�\�b�h
    /// </summary>
    private void Attack()
    {
        _attackCoolTimer -= Time.deltaTime;
        // �v���C���[���U���{�^���������Ă��邩�A�N�[���^�C����0���A�U���A�j���[�V�������I�����Ă��鎞�ɍU���������s��
        if (PlayerInput.IsAttack && _attackCoolTimer <= 0 && _playerAttack.AttackEnd)
        {
            _attackCoolTimer = _attackCoolTime;
            _isAttackReady = true;
            PlayerAnimController.PlayerAttackAnim(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            return;
        _isGround = true;
        _playerAnimController.PlayerAirAnim(true);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ground"))
            return;
        _isGround = false;
        _playerAnimController.PlayerAirAnim(false);
    }
}
