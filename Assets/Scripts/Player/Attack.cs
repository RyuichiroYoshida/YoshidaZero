using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Attack : MonoBehaviour
{
    [SerializeField] GameObject _zangekiPrefab;
    [SerializeField] float _attackDamage = 10;
    [SerializeField] float _debugMoveSpeed = 100;
    [SerializeField] bool _isHitting = false;
    [SerializeField] bool _isAttacking = false;
    [SerializeField] bool _attackEnd = true;
    GameObject _zangekiObj;
    Rigidbody2D _rb;
    Transform _playerTransform;
    Vector2 _mousePosition;
    Vector2 _target;
    PlayerController _playerController;
    AnimController _animController;
    public bool AttackEnd => _attackEnd;
    public Vector2 MousePosition => _mousePosition;

    void Start()
    {
        _playerTransform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
        _animController = GetComponent<AnimController>();
    }
    void Update()
    {
        PlayerZangeki();
        //if (UnityEngine.Input.GetButton("Fire2"))
        //    DebugMove();
    }

    /// <summary>
    /// 左クリック入力を受け取り、向いている方向に斬撃を飛ばす
    /// </summary>
    public void PlayerZangeki()
    {
        if (_playerController.IsAttackReady && _attackEnd)
        {
            _animController.PlayerAttackAnim(false);
            _attackEnd = false;
            _playerController.IsAttackReady = false;
            if (_playerTransform.localScale.x == 1)
            {
                _zangekiObj = Instantiate(_zangekiPrefab, new Vector2(_playerTransform.position.x + 1, _playerTransform.position.y), Quaternion.identity);
                _zangekiObj.transform.parent = _playerTransform;
            }
            else
            {
                _zangekiObj = Instantiate(_zangekiPrefab, new Vector2(_playerTransform.position.x - 1, _playerTransform.position.y), Quaternion.Euler(0, 0, 180));
                _zangekiObj.transform.parent = _playerTransform;
            }
        }
    }

    /// <summary>
    /// プレイヤーを右クリックの座標に戻す（デバッグ用）
    /// </summary>
    //public void DebugMove()
    //{
    //    if (_isHitting)
    //    {
    //        _playerTransform.position = Vector3.zero;
    //        _isHitting = false;
    //    }
    //    else
    //    {
    //        _isAttacking = true;
    //        float distance = Vector2.Distance(this.transform.position, _target);
    //        _playerTransform.position = Vector3.MoveTowards(_playerTransform.position, _target, _debugMoveSpeed * Time.deltaTime);
    //    }
    //}
    /// <summary>
    /// アニメーションイベントで攻撃アニメーションの終了通知用メソッド
    /// </summary>
    public void AttackAnimEnd()
    {
        _attackEnd = true;
        _rb.WakeUp();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            Destroy(collision.gameObject);
    }
}
