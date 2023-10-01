using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _killCounter = 0;
    [SerializeField] float _timer = 300;
    [SerializeField] bool _isDead = false;
    [SerializeField] bool _stageTextEnd = false;
    [SerializeField] bool _godMode = false;
    [SerializeField] Text _timerText;
    [SerializeField] GameObject _restartButton;
    [SerializeField] GameObject _deadImage;
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
        if (_playerinput.IsPause || IsDead || !StageTextEnd)
            return;
        _timer -= Time.unscaledDeltaTime;
        if (_timer <= 0)
            PlayerDead();
        _timerText.text = _timer.ToString("000");
    }
    public void PlayerDead()
    {
        if (_godMode)
            return;
        _isDead = true;
        _playerAnim.PlayerDeadAnim(true);
        _restartButton.SetActive(true);
        _deadImage.SetActive(true);

    }
    public void KillCount() => _killCounter++;
}
