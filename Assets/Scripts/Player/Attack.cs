using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject _zangekiPrefab;
    [SerializeField] float _attackDamage = 10;
    [SerializeField] float _debugMoveSpeed = 100;

    [SerializeField] float _dashAttackTimer = 0;
    [SerializeField] float _dashAttackCoolTime = 5;

    [SerializeField] bool _isHitting = false;
    [SerializeField] bool _isAttacking = false;
    [SerializeField] float _doMoveRange = 5;
    [SerializeField] float _doMoveTime = 3;
    bool _attackEnd = false;
    Rigidbody2D _rb;
    Transform _playerTransform;
    Vector2 _mousePosition;
    Vector2 _target;
    PlayerController _playerController;
    Input _playerInput;
    public bool AttackEnd { get => _attackEnd; set => _attackEnd = value; }
    public Vector2 MousePosition => _mousePosition;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
        _playerInput = GetComponent<Input>();
    }
    void Update()
    {
        // DashAttackのクールタイム計測用
        _dashAttackTimer -= Time.deltaTime;

        if (UnityEngine.Input.GetButton("Fire3") && _dashAttackTimer <= 0)
        {
            StartCoroutine(DashAttack());
        }

        float testDistanceX = _target.x - _playerTransform.position.x;
        float testDistanceY = _target.y - _playerTransform.position.y;
        Vector2 testDistance = new Vector2(testDistanceX, testDistanceY);

        PlayerMousePosition();
        if (UnityEngine.Input.GetButton("Fire2"))
        {
            DebugMove();
        }
        else
        {
            _isAttacking = false;
        }

        PlayerZangeki();
    }

    /// <summary>
    /// 左クリック入力を受け取り、向いている方向に斬撃を飛ばす
    /// </summary>
    public void PlayerZangeki()
    {
        if (_playerController.IsAttacking)
        {
            if (_playerTransform.localScale.x == 1)
            {
                Instantiate(_zangekiPrefab, new Vector2(_playerTransform.position.x + 1, _playerTransform.position.y), Quaternion.identity);
                _rb.Sleep();
                StartCoroutine(AttackWait());
            }
            else
            {
                Instantiate(_zangekiPrefab, new Vector2(_playerTransform.position.x - 1, _playerTransform.position.y), Quaternion.Euler(0, 0, 180));
                _rb.Sleep();
                StartCoroutine(AttackWait());
            }
        }
        _playerController.IsAttacking = false;
    }

    /// <summary>
    /// プレイヤーを右クリックの座標に戻す（デバッグ用）
    /// </summary>
    public void DebugMove()
    {
        if (_isHitting)
        {
            _playerTransform.position = Vector3.zero;
            _isHitting = false;
        }
        else
        {
            _isAttacking = true;
            float distance = Vector2.Distance(this.transform.position, _target);
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _target, _debugMoveSpeed * Time.deltaTime);
        }
    }

    public void PlayerMousePosition()
    {
        _mousePosition = UnityEngine.Input.mousePosition;
        _target = Camera.main.ScreenToWorldPoint(_mousePosition);
    }

    public void AttackAnimEnd()
    {
        AttackEnd = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isAttacking)
        {
            _isHitting = true;
        }
    }

    IEnumerator DashAttack()
    {
        _dashAttackTimer = _dashAttackCoolTime;
        _isAttacking = true;
        this.transform.DOLocalMoveX(_doMoveRange * _playerInput.XInput, _doMoveTime).SetRelative(true).SetEase(Ease.OutCirc);
        yield return new WaitForSeconds(_doMoveTime);
        _isAttacking = false;
    }

    IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(1);
        _rb.WakeUp();
    }
}
