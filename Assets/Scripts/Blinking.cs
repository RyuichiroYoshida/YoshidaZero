using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Blinking : MonoBehaviour
{
    [SerializeField] Text _text;
    void Start()
    {
        _text.DOFade(0.3f, 1f).SetLoops(-1, LoopType.Yoyo).SetLink(this.gameObject);
    }
}
