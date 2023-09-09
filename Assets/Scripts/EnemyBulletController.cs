using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float _bulletSpeed;
    [SerializeField, Tooltip("デバッグ用")] float _flip = 0;
    GunEnemyController _enemyController;
    Rigidbody2D _rb;
    void Start()
    {
        _enemyController = GetComponent<GunEnemyController>();
        _rb = GetComponent<Rigidbody2D>();
        _enemyController = GameObject.Find("GunEnemy").GetComponent<GunEnemyController>();
        _flip = _enemyController.FlipValue;
        _rb.velocity = Vector2.right * _bulletSpeed * _flip;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Wall")
            Destroy(this.gameObject);
    }
}
