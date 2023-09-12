using UnityEngine;
using DG.Tweening;

public abstract class EnemyBase : MonoBehaviour
{
    Input _playerInput;
    void Awake()
    {
        _playerInput = GameObject.FindWithTag("Player").GetComponent<Input>();
    }
    void Update()
    {
        if (_playerInput.IsPause && GameManager.instance.IsDead)
            transform.DOPause();
        else
            transform.DOPlay();
    }

    void OnDestroy()
    {
        DOTween.KillAll();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.PlayerDead();
        }
    }
}
