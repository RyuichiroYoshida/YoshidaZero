using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] float _killCounter = 0;
    [SerializeField] float _timer = 0;
    [SerializeField] bool _isDead = false;
    [SerializeField] Text _timerText;
    GameObject _player;
    AnimController _playerAnim;
    public float KillCounter => _killCounter;
    public float Timer => _timer;
    public bool IsDead => _isDead;
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
    }

    void Update()
    {
        _timer += Time.unscaledDeltaTime;
        _timerText.text ??= _timer.ToString();

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
