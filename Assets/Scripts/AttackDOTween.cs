using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D)),
RequireComponent(typeof(CircleCollider2D))]
public class AttackDOTween : MonoBehaviour
{
    [SerializeField] float _moveRange = 10;
    [SerializeField] float _moveTime = 0.5f;
    [SerializeField] float _moveSpeed = 10;
    bool _isHitting = false;
    bool _isAttacking = false;
    Rigidbody2D _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (UnityEngine.Input.GetButton("Fire3"))
        {
            StartCoroutine(Attack());
            //DOTweenAttack();
        }
        PlayerMove();
    }

    void PlayerMove()
    {
        float xInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(_rb.velocity.x * _moveSpeed * xInput, _rb.velocity.y);
    }

    void DOTweenAttack()
    {
        DOTween.To(() => transform.position, x
                      => transform.position = x,
                      new Vector3(_moveRange, 0, 0), _moveTime)
                      .SetRelative(true)
                      .SetEase(Ease.OutCirc);
        // this.transform.DOLocalMoveX(_moveRange, _moveTime).SetEase(Ease.OutCirc);
    }

    IEnumerator Attack()
    {
        _isAttacking = true;
        DOTweenAttack();
        yield return new WaitForSeconds(_moveTime);
        _isAttacking = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isHitting = true;
    }
}
