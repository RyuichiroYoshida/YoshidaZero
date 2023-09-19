using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultManager : MonoBehaviour
{
    [SerializeField] float _killCounter;
    [SerializeField] float _timer;
    [SerializeField] Text _killCounterText;
    [SerializeField] Text _timerText;
    void Start()
    {
        _killCounter = GameManager.instance.KillCounter;
        _timer = GameManager.instance.Timer;
    }
    void Update()
    {

    }
    void DoKillCounter(float endValue, float endTime)
    {
        //DOTween.To(() => _killCounterText.text, newText => _killCounterText.text = newText, endValue.ToString,);
    }
    void DoKillTimer()
    {

    }
}
