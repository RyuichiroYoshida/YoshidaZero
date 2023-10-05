using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ZangekiController : MonoBehaviour
{
    [SerializeField] float _zangekiSpeed = 5f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.KillCount();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collision.gameObject.TryGetComponent<EnemyBulletController>(out var enemyBullet);
            enemyBullet.FlipX *= -1;
            enemyBullet.Reflection = true;
        }
    }
}
