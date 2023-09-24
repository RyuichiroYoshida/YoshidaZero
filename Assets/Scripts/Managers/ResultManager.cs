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
    [SerializeField] GameObject _gameManager;
    [SerializeField] GameObject _button;
    //[SerializeField] AudioClip _drumRoll;
    [SerializeField] AudioClip _drumRollEnd;
    AudioSource _audioSource;
    float _killCount = 0;
    float _timeCount = 0;
    bool _countEnd = false;
    void Awake()
    {

    }
    void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _killCounter = GameManager.instance.KillCounter;
        _timer = GameManager.instance.Timer;
        _gameManager.SetActive(false);
        DoTimer();
        DoKillCounter();
    }
    void DoKillCounter()
    {
        string str = "ƒLƒ‹";
        _audioSource.Play();
        DOTween.To(() => _killCount, newValue =>
        {
            _killCount = newValue;
            _killCounterText.text = str + _killCount.ToString("000000");
        }, _killCounter, _endTime)
            .OnComplete(() =>
            {
                _audioSource.Stop();
                _audioSource.PlayOneShot(_drumRollEnd);
            });
    }
    void DoTimer()
    {
        string str = "ƒ^ƒCƒ€";
        DOTween.To(() => _timeCount, newValue =>
        {
            _timeCount = newValue;
            _timerText.text = str + _timeCount.ToString("000000");
        }, _timer, _endTime)
            .OnComplete(() => _button.SetActive(true));
    }
}
