using UnityEngine;
public class AttackController : MonoBehaviour
{
    [SerializeField] float _destroyTimer = 0.2f;
    private void Start()
    {
        Destroy(this.gameObject, _destroyTimer);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.KillCount();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            SoundManager.instance.BulletReflection();
            collision.TryGetComponent(out EnemyBulletController enemyBullet);
            enemyBullet.FlipX *= -1;
            enemyBullet.Reflection = true;
        }
    }
}
