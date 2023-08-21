using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float _attackDamage = 10;
    [SerializeField] float _dashSpeed = 100;
    bool _attackEnd = false;
    [SerializeField] bool _isHitting = false;
    [SerializeField] bool _isAttacking = false;
    Transform _playerTransform;
    Vector2 _mousePosition;
    Vector2 _target;
    public bool AttackEnd { get => _attackEnd; set { _attackEnd = value; } }
    public Vector2 MousePosition => _mousePosition;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
    }
    void Update()
    {
        float testDistanceX = _target.x - _playerTransform.position.x;
        float testDistanceY = _target.y - _playerTransform.position.y;
        Vector2 testDistance = new Vector2(testDistanceX, testDistanceY);

        print(testDistance);
        PlayerMousePosition();
        if (UnityEngine.Input.GetButton("Fire2"))
        {
            PlayerAttack();
        }
        else
        {
            _isAttacking = false;
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
}
