using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int _killCount = 0;

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
        
    }

    void Update()
    {
        
    }

    public void KillCount()
    {
        _killCount++;
    }
}
