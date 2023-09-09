using UnityEngine;

public class GunEnemyController : EnemyBase
{
    [SerializeField] float _detectionRange;
    [SerializeField] float _moveSpeed;
    [SerializeField] GameObject _bulletPrefab;
    [SerializeField] LayerMask _wallLayer;
    [SerializeField] LayerMask _playerLayer;
    [SerializeField, Tooltip("デバッグ用")] float _flipValue = 1;
    [SerializeField, Tooltip("デバッグ用")] RaycastHit2D _wallHit;
    [SerializeField, Tooltip("デバッグ用")] RaycastHit2D _playerHit;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
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

    /// <summary>
    /// エネミーの壁検知ラインキャストと移動管理
    /// </summary>
    /// <param name="value">移動方向の転換の引数</param>
    void EnemyMove(float value)
    {
        // 壁検知用ラインキャスト
        Vector2 _wallLineEnd = new Vector2(transform.position.x + (2 * value), transform.position.y - 0.5f);
        _wallHit = Physics2D.Linecast(transform.position, _wallLineEnd, _wallLayer);
        // 移動、壁に当たると反転
        _rb.velocity = Vector2.right * _moveSpeed * value;
        // ラインキャストを可視化
        Debug.DrawLine(transform.position, _wallLineEnd, Color.blue);
    }

    void EnemyAttack(float value)
    {
        Vector2 _playerLineEnd = new Vector2(transform.position.x + (_detectionRange * value), transform.position.y);
        _playerHit = Physics2D.Linecast(transform.position, _playerLineEnd, _playerLayer);
        if (_playerHit)
            this._rb.velocity = Vector2.zero;
        Debug.DrawLine(transform.position, _playerLineEnd, Color.red);
    }
}
