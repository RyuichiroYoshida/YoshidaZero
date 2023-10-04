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
        // �G�l�~�[���~�܂�̂́A(�|�[�Y���@�v���C���[������ł���@�ŏ��̏������I����Ă��Ȃ�)��
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
        if (collision.gameObject.CompareTag("Player"))
            GameManager.instance.PlayerDead();
    }
}
