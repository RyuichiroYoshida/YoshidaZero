using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] float _playerHp = 10;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }
}
