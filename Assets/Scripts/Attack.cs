using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject _zangekiPrefab;
    [SerializeField] float _attackDamage = 10;
    [SerializeField] float _dashSpeed = 100;
    [SerializeField] float _dashAttackSpeed = 10;
    [SerializeField] float _dashAttackTimer = 0;
    [SerializeField] float _dashAttackCoolTime = 5;
    [SerializeField] float _addDashTime = 2;
    [SerializeField] bool _isHitting = false;
    [SerializeField] bool _isAttacking = false;
    bool _attackEnd = false;
    Rigidbody2D _rb;
    Transform _playerTransform;
    Vector2 _mousePosition;
    Vector2 _target;
    PlayerController _playerController;
    public bool AttackEnd { get => _attackEnd; set { _attackEnd = value; } }
    public Vector2 MousePosition => _mousePosition;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
    }
    void Update()
    {
        _dashAttackTimer -= Time.deltaTime;
        if (UnityEngine.Input.GetButton("Fire3") && _dashAttackTimer <= 0)
        {
            PlayerDashAttack();
        }

        float testDistanceX = _target.x - _playerTransform.position.x;
        float testDistanceY = _target.y - _playerTransform.position.y;
        Vector2 testDistance = new Vector2(testDistanceX, testDistanceY);

        //print(testDistance);
        PlayerMousePosition();
        if (UnityEngine.Input.GetButton("Fire2"))
        {
            PlayerAttack();
        }
        else
        {
            _isAttacking = false;
        }

        PlayerZangeki();
    }

    public void PlayerZangeki()
    {
        if (_playerController.IsAttacking)
        {
            if (_playerTransform.localScale.x == 1)
            {
                Instantiate(_zangekiPrefab, new Vector2(_playerTransform.position.x + 1, _playerTransform.position.y), Quaternion.identity);
            }
            else
            {

                Instantiate(_zangekiPrefab, new Vector2(_playerTransform.position.x - 1, _playerTransform.position.y), Quaternion.Euler(180, 0, 0));
            }
        }
    }

    public void PlayerAttack()
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
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _target, _dashSpeed * Time.deltaTime);
        }
    }

    public void PlayerMousePosition()
    {
        _mousePosition = UnityEngine.Input.mousePosition;
        _target = Camera.main.ScreenToWorldPoint(_mousePosition);
    }

    public void PlayerDashAttack()
    {
        print("DashStart");
        //StartCoroutine(DashAttack(_addDashTime));
        if (_playerTransform.localScale.x == 1)
        {
            //_rb.AddForce(Vector2.right * _dashAttackSpeed, ForceMode2D.Impulse);
            Vector2 dashRange = new Vector2(_playerTransform.localPosition.x + 2, 0) * Time.deltaTime;
            _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, dashRange, _dashSpeed);
        }
        else
        {
            _rb.AddForce(Vector2.left * _dashAttackSpeed, ForceMode2D.Impulse);
        }
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

    IEnumerator DashAttack(float time)
    {
        _dashAttackTimer = _dashAttackCoolTime;
        if (_playerTransform.localScale.x == 1)
        {
            _rb.AddForce(Vector2.right * _dashAttackSpeed);
        }
        else
        {
            _rb.AddForce(Vector2.left * _dashAttackSpeed);
        }
        yield return new WaitForSeconds(time);
        _rb.velocity = Vector3.zero;
    }
}
