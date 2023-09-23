using DG.Tweening;
using UnityEngine;

public class EnemyController : EnemyBase
{
    void Start()
    {
        transform.DOMoveX(-5, 5).SetLoops(-1, LoopType.Yoyo).SetLink(this.gameObject);
    }
}
