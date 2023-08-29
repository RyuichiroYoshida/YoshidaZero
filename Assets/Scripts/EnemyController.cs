using DG.Tweening;

public class EnemyController : EnemyBase
{
    void Start()
    {
        transform.DOLocalMoveX(5, 5)
         .SetLoops(-1, LoopType.Yoyo);
    }
}
