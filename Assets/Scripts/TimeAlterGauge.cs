using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

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
        // �Q�[�W��0�ȉ��ɂȂ�ƃI�[�o�[�q�[�g��ԂɂȂ�
        if (_gaugeSlider.value <= 0)
            _timeAlterOverHeat = true;
        // �Q�[�W�������ȏ�񕜂���ƃI�[�o�[�q�[�g��Ԃ���������
        else if (_gaugeSlider.value >= _timeAlterLimit / 2)
            _timeAlterOverHeat = false;
        // �I�[�o�[�q�[�g��Ԃł͎��ԑ���͎g���Ȃ�
        if (_timeManager.TimeAltering && !_timeAlterOverHeat)
            GaugeValueDown();
        else
            GaugeValueUp();
    }
    /// <summary>
    /// ���ԑ���g�p���ԃQ�[�W�������\�b�h
    /// </summary>
    void GaugeValueUp()
    {
        DOTween.To(() => _gaugeSlider.value, newValue => _gaugeSlider.value = newValue, _timeAlterLimit, _changeValueInterval)
            .OnComplete(() => _timeAlterOverHeat = false);
    }
    /// <summary>
    /// ���ԑ���g�p���ԃQ�[�W�������\�b�h
    /// </summary>
    void GaugeValueDown()
    {
        DOTween.To(() => _gaugeSlider.value, newValue => _gaugeSlider.value = newValue, -_timeAlterLimit, _changeValueInterval)
            .OnComplete(() => _timeAlterOverHeat = true);
    }
}
