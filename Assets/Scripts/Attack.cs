using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float _attackDamage = 10;
    bool _attackEnd = false;
    public bool AttackEnd { get => _attackEnd; set { _attackEnd = value; } }

    public void PLayerAttack()
    {
        Vector2 mousePosition = UnityEngine.Input.mousePosition;
        Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition);
        float distance = Vector2.Distance(this.transform.position, target);
    }

    public void AttackAnimEnd()
    {
        AttackEnd = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
