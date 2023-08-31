using UnityEngine;

public class StageManagerBase : MonoBehaviour
{
    [SerializeField] bool _stageClaer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _stageClaer = true;
        }
    }
}
