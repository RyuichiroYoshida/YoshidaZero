using UnityEngine;
using DG.Tweening;

public abstract class EnemyBase : MonoBehaviour
{
    protected Input _playerInput;
    void Awake()
    {
        _playerInput = GameObject.FindWithTag("Player").GetComponent<Input>();
    }
    void Update()
    {
        // エネミーが止まるのは、(ポーズ中　プレイヤーが死んでいる　最初の準備が終わっていない)時
        if (_playerInput.IsPause || GameManager.instance.IsDead || !GameManager.instance.StageTextEnd)
            transform.DOPause();
        else
            transform.DOPlay();
    }
    void OnDestroy()
    {
        SoundManager.instance.EnemyDestroy();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            GameManager.instance.PlayerDead();
    }
}
