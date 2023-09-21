using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.UI;

public class StartTextImage : MonoBehaviour
{
    Image _image;
    void Start()
    {
        _image = GetComponent<Image>();
        StartCoroutine(StartImage());
    }

    IEnumerator StartImage()
    {
        transform.DOMoveX(-2000, 1).SetRelative(true);
        yield return new WaitForSeconds(2);
        _image.DOFade(0, 1).OnComplete(() => Destroy(this)).OnComplete(() => GameManager.instance.StageTextEnd = true);
    }
}
