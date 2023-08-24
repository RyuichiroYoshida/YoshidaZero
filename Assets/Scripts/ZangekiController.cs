using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class ZangekiController : MonoBehaviour
{
    [SerializeField] float _zangekiSpeed = 5f;
    Rigidbody2D _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = Vector2.right * _zangekiSpeed;
    }
}
