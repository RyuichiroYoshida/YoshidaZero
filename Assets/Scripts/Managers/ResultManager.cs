using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class ResultManager : MonoBehaviour
{
    [SerializeField] float _killCounter;
    [SerializeField] float _timer;
    [SerializeField] float _endTime = 0;
    [SerializeField] Text _killCounterText;
    [SerializeField] Text _timerText;
    float _killCount = 0;
    float _timeCount = 0;
    void Start()
    {
        _killCounter = GameManager.instance.KillCounter;
        _timer = GameManager.instance.Timer;
        StartCoroutine(Counter());
    }
    IEnumerator Counter()
    {
        DoKillCounter();
        yield return new WaitForSeconds(_endTime);
        DoTimer();
        StartCoroutine(Counter());
    }
    void DoKillCounter()
    {
        string str = "ƒLƒ‹";
        DOTween.To(() => _killCount, newValue =>
        {
            _killCount = newValue;
            _killCounterText.text = str + _killCount.ToString("000000");
        }, _killCounter, _endTime);
    }
    void DoTimer()
    {
        string str = "ƒ^ƒCƒ€";
        DOTween.To(() => _timeCount, newValue =>
        {
            _timeCount = newValue;
            _timerText.text = str + _timeCount.ToString("000000");
        }, _timer, _endTime);
    }
}
