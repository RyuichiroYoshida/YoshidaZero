using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float _attackDamage = 10;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PLayerAttack()
    {
        Vector2 mousePosition = UnityEngine.Input.mousePosition;
        Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition);
        float distance = Vector2.Distance(this.transform.position, target);
    }

    public bool AttackEnd()
    {
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }
}
