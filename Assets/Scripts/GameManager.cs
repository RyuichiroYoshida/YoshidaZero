using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _killCount = 0;
    [SerializeField] bool _isDead = false;
    GameObject _player;
    AnimController _playerAnim;
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

    }
    public void PlayerDead()
    {
        _isDead = true;
        _playerAnim.PlayerDeadAnim(true);
    }
    public void KillCount()
    {
        _killCount++;
    }
}
