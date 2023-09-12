using UnityEngine;
public class AttackController : MonoBehaviour
{
    [SerializeField] float _destroyTimer = 0.2f;
    void Start()
    {
        Destroy(this.gameObject, _destroyTimer);
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
