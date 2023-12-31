using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class StageTextManager : MonoBehaviour
{
    Text _text;
    void Start()
    {
        _text = GetComponent<Text>();
        StartCoroutine(StartText());
    }

    IEnumerator StartText()
    {
        transform.DOMoveX(-2000, 1).SetRelative(true);
        yield return new WaitForSeconds(2);
        _text.DOFade(0, 1).OnComplete(() => Destroy(this)).SetLink(this.gameObject);
    }
}
