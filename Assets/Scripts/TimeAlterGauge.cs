using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TimeAlterGauge : MonoBehaviour
{
    [SerializeField] float _timeAlterLimit = 10;
    [SerializeField] float _changeValueInterval = 0.5f;
    [SerializeField] bool _timeAlterOverHeat = false;
    [SerializeField] GameObject _image;
    Input _playerInput;
    Slider _gaugeSlider;
    TimeManager _timeManager;
    Tweener _gaugeValueUp;
    Tweener _gaugeValueDown;
    public float TimeAlterLimit => _timeAlterLimit;
    public bool TimeAlterOverHeat => _timeAlterOverHeat;


    void Start()
    {
        _gaugeSlider = GameObject.FindGameObjectWithTag("UI").GetComponent<Slider>();
        _timeManager = GetComponent<TimeManager>();
        _gaugeSlider.maxValue = _timeAlterLimit;
        _gaugeSlider.value = _timeAlterLimit;
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<Input>();
    }
    void Update()
    {
        if (_playerInput.IsPause)
        {
            _gaugeValueUp.Pause();
            _gaugeValueDown.Pause();
            _image.SetActive(true);
            return;
        }
        else
        {
            _gaugeValueUp.Play();
            _gaugeValueDown.Play();
            _image.SetActive(false);
        }
        // �Q�[�W��0�ȉ��ɂȂ�ƃI�[�o�[�q�[�g��ԂɂȂ�
        if (_gaugeSlider.value <= 0)
        {
            _timeAlterOverHeat = true;
        }
        // �Q�[�W�������ȏ�񕜂���ƃI�[�o�[�q�[�g��Ԃ���������
        else if (_gaugeSlider.value >= _timeAlterLimit / 2)
            _timeAlterOverHeat = false;
        // �I�[�o�[�q�[�g��Ԃł͎��ԑ���͎g���Ȃ�
        if (_timeManager.TimeAltering && !_timeAlterOverHeat)
            GaugeValueDown();
        else if (_gaugeSlider.value != _timeAlterLimit)
            GaugeValueUp();
    }
    /// <summary>
    /// ���ԑ���g�p���ԃQ�[�W�������\�b�h
    /// </summary>
    void GaugeValueUp()
    {
        _gaugeValueUp = DOTween.To(() => _gaugeSlider.value, newValue => _gaugeSlider.value = newValue, _timeAlterLimit, _changeValueInterval)
            .OnComplete(() => _timeAlterOverHeat = false);
    }
    /// <summary>
    /// ���ԑ���g�p���ԃQ�[�W�������\�b�h
    /// </summary>
    void GaugeValueDown()
    {
        _gaugeValueDown = DOTween.To(() => _gaugeSlider.value, newValue => _gaugeSlider.value = newValue, -_timeAlterLimit, _changeValueInterval)
            .OnComplete(() => _timeAlterOverHeat = true);
    }
}
