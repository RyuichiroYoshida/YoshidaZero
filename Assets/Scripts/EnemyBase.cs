using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            Destroy(this.gameObject);
        }
    }
}