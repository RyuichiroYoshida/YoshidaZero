using System.Collections;
using UnityEngine;

public class GunEnemyController : EnemyBase
{
    [SerializeField] float _detectionRange;
    [SerializeField] float _moveSpeed;
    [SerializeField] float _gunCoolTime;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] LayerMask _wallLayer;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField, Tooltip("�f�o�b�O�p")] float _flipValue = 1;
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
        if (_wallHit)
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
        var wallLineEnd = new Vector2(transform.position.x + (3 * value), transform.position.y - 0.5f);
        _wallHit = Physics2D.Linecast(transform.position, wallLineEnd, _wallLayer);
        // �ړ��A�ǂɓ�����Ɣ��]
        _rb.velocity = Vector2.right * _moveSpeed * value;
        // ���C���L���X�g������
        Debug.DrawLine(transform.position, wallLineEnd, Color.blue);
    }

    void EnemyAttack(float value)
    {
        // �v���C���[���m�p���C���L���X�g
        Vector2 _playerLineEnd = new Vector2(transform.position.x + (_detectionRange * value), transform.position.y);
        _playerHit = Physics2D.Linecast(transform.position, _playerLineEnd, _playerLayer);
        // �v���C���[���m���ɂ��̏�ɒ�~����
        if (_playerHit)
        {
            this._rb.velocity = Vector2.zero;
            if (_timer >= _gunCoolTime)
            {
                Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
                _timer = 0;
            }
        }
        // ���C���L���X�g������
        Debug.DrawLine(transform.position, _playerLineEnd, Color.red);
    }
}
