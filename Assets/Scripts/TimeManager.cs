using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Image _timeFadeImage;
    Input _playerInput;
    bool _timeAltering = false;
    TimeAlterGauge _timeAlterGauge;
    public bool TimeAltering => _timeAltering;
    void Start()
    {
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<Input>();
        _timeAlterGauge = GetComponent<TimeAlterGauge>();
    }
    void Update()
    {
        if (_playerInput.TimeAlter && !_timeAlterGauge.TimeAlterOverHeat)
        {
            _timeAltering = true;
            Time.timeScale = 0.2f;
            TimeAlterFade();
        }
        else
        {
            _timeAltering = false;
            Time.timeScale = 1;
        }
    }
    void TimeAlterFade()
    {
        _timeFadeImage.gameObject.SetActive(true);
        _timeFadeImage.DOFade(1, _timeAlterGauge.TimeAlterLimit);
        if (!_timeAltering)
        {
            _timeFadeImage.DOKill();
            _timeFadeImage.DOFade(0, 2);
        }
    }
}
