using UnityEngine;
using UnityEngine.Serialization;

public class GunEnemyController : EnemyBase
{
    [SerializeField] float _detectionRange;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _gunCoolTime;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] LayerMask _wallLayer;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField, Tooltip("�f�o�b�O�p")] float _flipValue = 1;
    [SerializeField] RaycastHit2D _groundHit;
    [SerializeField, Tooltip("�f�o�b�O�p")] RaycastHit2D _wallHit;
    [SerializeField, Tooltip("�f�o�b�O�p")] RaycastHit2D _playerHit;
    Rigidbody2D _rb;
    SpriteRenderer _spriteRenderer;
    float _timer = 0;

    public float FlipValue => _flipValue;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (_playerInput.IsPause || GameManager.instance.IsDead || !GameManager.instance.StageTextEnd)
        {
            _rb.Sleep();
            return;
        }
        else
            _rb.WakeUp();

        _timer += Time.deltaTime;
        if (_wallHit || _groundHit == false)
        {
            print("Wall Hit");
            _flipValue *= -1;
            _spriteRenderer.flipX = !_spriteRenderer.flipX;
        }
        EnemyMove(_flipValue);
        EnemyAttack(_flipValue);
    }

    /// <summary>
    /// �G�l�~�[�̕ǌ��m���C���L���X�g�ƈړ��Ǘ�
    /// </summary>
    /// <param name="value">�ړ������̓]���̈���</param>
    void EnemyMove(float value)
    {
        // �ǌ��m�p���C���L���X�g
        var pos = this.transform.position;
        var wallLineEnd = new Vector2(pos.x + (3 * value), pos.y - 0.5f);
        var groundLineEnd = new Vector2(pos.x + value, pos.y - 0.7f);
        _wallHit = Physics2D.Linecast(pos, wallLineEnd, _wallLayer);
        _groundHit = Physics2D.Linecast(pos, groundLineEnd, _groundLayer);
        _rb.velocity = Vector2.right * value * _moveSpeed;
        // ���C���L���X�g������
        Debug.DrawLine(pos, wallLineEnd, Color.blue);
        Debug.DrawLine(pos, groundLineEnd, Color.yellow);
    }

    void EnemyAttack(float value)
    {
        // �v���C���[���m�p���C���L���X�g
        var pos = this.transform.position;
        var playerLineEnd = new Vector2(pos.x + (_detectionRange * value), pos.y);
        _playerHit = Physics2D.Linecast(pos, playerLineEnd, _playerLayer);
        // �v���C���[���m���ɂ��̏�ɒ�~����
        if (_playerHit)
        {
            this._rb.velocity = Vector2.zero;
            if (_timer >= _gunCoolTime)
            {
                Instantiate(_bulletPrefab, pos, Quaternion.identity);
                _timer = 0;
            }
        }
        Debug.DrawLine(pos, playerLineEnd, Color.red);
    }
}
