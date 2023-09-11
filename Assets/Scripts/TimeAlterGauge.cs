using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections;
using Unity.VisualScripting;

public class TimeAlterGauge : MonoBehaviour
{
    [SerializeField] float _timeAlterLimit = 10;
    [SerializeField] float _changeValueInterval = 0.5f;
    [SerializeField] bool _timeAlterOverHeat = false;
    Slider _gaugeSlider;
    TimeManager _timeManager;
    public bool TimeAlterOverHeat => _timeAlterOverHeat;
    void Start()
    {
        _gaugeSlider = GameObject.FindGameObjectWithTag("UI").GetComponent<Slider>();
        _timeManager = GetComponent<TimeManager>();
        _gaugeSlider.maxValue = _timeAlterLimit;
        _gaugeSlider.value = _timeAlterLimit;
    }
    void Update()
    {
        if (_gaugeSlider.value <= 0)
            _timeAlterOverHeat = true;
        else
            _timeAlterOverHeat = false;
        if (_timeManager.TimeAltering)
            GaugeValueDown();
        else
            GaugeValueUp();
    }
    /// <summary>
    /// 時間操作使用時間ゲージ増加メソッド
    /// </summary>
    /// <param name="value">ゲージを減少 or 増加させる</param>
    /// <param name="time">ゲージがマックスになるまでにかかる時間</param>
    void GaugeValueUp()
    {
        DOTween.To(() => _gaugeSlider.value, newValue => _gaugeSlider.value = newValue, _timeAlterLimit, _changeValueInterval)
            .OnComplete(() => _timeAlterOverHeat = false);
    }
    void GaugeValueDown()
    {
        DOTween.To(() => _gaugeSlider.value, newValue => _gaugeSlider.value = newValue, -_timeAlterLimit, _changeValueInterval)
            .OnComplete(() => _timeAlterOverHeat = true);
    }
    IEnumerator ValueChange()
    {

        yield return new WaitForSeconds(_changeValueInterval);
    }
}
