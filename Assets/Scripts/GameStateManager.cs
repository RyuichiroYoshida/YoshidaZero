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
        _gameState.Initialize(GameState.gameStart);
    }

    void Update()
    {
        _gameState?.Update(); // GameStateMachine��Null�ł͂Ȃ��Ƃ��ɁA�펞StateMachine���Ăяo��
    }
}
