using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _killCounter = 0;
    [SerializeField] float _timer = 0;
    [SerializeField] bool _isDead = false;
    [SerializeField] Text _timerText;
    [SerializeField] bool _stageTextEnd = false;
    GameObject _player;
    AnimController _playerAnim;
    Input _playerinput;
    public float KillCounter => _killCounter;
    public float Timer => _timer;
    public bool IsDead => _isDead;
    public bool StageTextEnd { get => _stageTextEnd; set => _stageTextEnd = value; }
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerAnim = _player.GetComponent<AnimController>();
        _playerinput = _player.GetComponent<Input>();
    }

    void Update()
    {
        if (_playerinput.IsPause)
            return;
        _timer += Time.unscaledDeltaTime;
        if (_timerText != null)
            _timerText.text = _timer.ToString("000");
    }
    public void PlayerDead()
    {
        _isDead = true;
        _playerAnim.PlayerDeadAnim(true);
    }
    public void KillCount()
    {
        _killCounter++;
    }
}
