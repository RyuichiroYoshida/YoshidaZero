using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] bool _stageClear = false;
    public bool StageClear => _stageClear;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _stageClear = true;
        }
    }
}
