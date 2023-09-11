using UnityEngine;
public class TimeManager : MonoBehaviour
{
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
        }
        else
        {
            _timeAltering = false;
            Time.timeScale = 1;
        }
    }
}
