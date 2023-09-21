using UnityEngine;
using DG.Tweening;

public class TitleEffect : MonoBehaviour
{
    void Start()
    {
        this.gameObject.transform.DOMove(new Vector2(-1, 1), 1).SetLoops(-1, LoopType.Yoyo);
    }
}
