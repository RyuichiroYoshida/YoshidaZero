using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    StateMachine _gameState;
    public StateMachine GameState => _gameState;

    private void Awake()
    {
        _gameState = new StateMachine(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
