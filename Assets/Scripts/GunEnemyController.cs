using UnityEngine;

public class GunEnemyController : EnemyBase
{
    [SerializeField] float _detectionRange;
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] LayerMask _wallLayer;
    [SerializeField] LayerMask _playerLayer;
    float _flipValue = 1;
    RaycastHit2D _wallHit;
    RaycastHit2D _playerHit;
    void Start()
    {

    }

    void Update()
    {
        if (_wallHit)
        {
            print("Wall Hit");
            _flipValue *= -1;
        }
        EnemyMove(_flipValue);
        EnemyAttack(_flipValue);
    }

    void EnemyMove(float value)
    {
        Vector2 _wallLineStart = new Vector2(transform.position.x * value, transform.position.y - 0.5f);
        Vector2 _wallLineEnd = new Vector2((transform.position.x + 3) * value, transform.position.y - 0.5f);
        _wallHit = Physics2D.Linecast(_wallLineStart, _wallLineEnd, _wallLayer);
        if (_wallHit)
            print("Wall Hit");
        Debug.DrawLine(_wallLineStart, _wallLineEnd, Color.blue);
    }

    void EnemyAttack(float value)
    {
        Vector2 _playerLineStart = new Vector2((transform.position.x + 1) * value, transform.position.y);
        Vector2 _playerLineEnd = new Vector2((transform.position.x + _detectionRange) * value, transform.position.y);
        _playerHit = Physics2D.Linecast(_playerLineStart, _playerLineEnd, _playerLayer);
        if (_playerHit)
            print("Player Hit");
        Debug.DrawLine(_playerLineStart, _playerLineEnd, Color.red);
    }
}
