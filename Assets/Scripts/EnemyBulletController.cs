using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
    [SerializeField] bool _reflection = false;
    [SerializeField, Tooltip("デバッグ用")] float _flip = 0;
    GunEnemyController _enemyController;
    Rigidbody2D _rb;
    Input _playerInput;
    GameObject _player;
    public float FlipX { get => _flip; set => _flip = value; }
    public bool Reflection { get => _reflection; set => _reflection = value; }
    void Start()
    {
        _enemyController = GetComponent<GunEnemyController>();
        _rb = GetComponent<Rigidbody2D>();
        _enemyController = GameObject.Find("GunEnemy").GetComponent<GunEnemyController>();
        _flip = _enemyController.FlipValue;
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerInput = _player.GetComponent<Input>();
    }

    void Update()
    {
        _rb.velocity = Vector2.right * _bulletSpeed * _flip;
        if (_playerInput.IsPause)
            _rb.Sleep();
        else
            _rb.WakeUp();
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        Destroy(this.gameObject);
    //        GameManager.instance.PlayerDead();
    //    }
    //    else if (collision.gameObject.tag == "Wall")
    //        Destroy(this.gameObject);
    //    else if (collision.gameObject.tag == "Enemy" && Reflection)
    //    {
    //        GameManager.instance.KillCount();
    //        Destroy(collision.gameObject);
    //        Destroy(this.gameObject);
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            GameManager.instance.PlayerDead();
        }
        else if (collision.gameObject.tag == "Wall")
            Destroy(this.gameObject);
        else if (collision.gameObject.tag == "Enemy" && Reflection)
        {
            GameManager.instance.KillCount();
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
