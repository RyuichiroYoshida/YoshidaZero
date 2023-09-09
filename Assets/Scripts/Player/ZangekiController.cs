using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ZangekiController : MonoBehaviour
{
    [SerializeField] float _zangekiSpeed = 5f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Transform _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (_playerTransform.localScale.x == 1)
        {
            _rb.velocity = Vector2.right * _zangekiSpeed;
        }
        else
        {
            _rb.velocity = Vector2.left * _zangekiSpeed;
        }
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameManager.instance.KillCount();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Bullet")
        {
            EnemyBulletController enemyBullet = collision.gameObject.GetComponent<EnemyBulletController>();
            enemyBullet.FlipX *= -1;
            enemyBullet.Reflection = true;
        }
    }
}
