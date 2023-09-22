using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CreditText : MonoBehaviour
{
    Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
        _text.DOFade(1, 3).OnComplete(() => Destroy(this.gameObject)).SetLink(this.gameObject);
    }
}
