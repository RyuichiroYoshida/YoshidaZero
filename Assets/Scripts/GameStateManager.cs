using UnityEngine;

[RequireComponent (typeof(SceneManager), typeof(StageManager))]
public class GameStateManager : MonoBehaviour
{
    StateMachine _gameState;
    SceneManager _sceneManager;
    StageManager _stageManager;
    public StateMachine GameState => _gameState;
    public SceneManager SceneManager => _sceneManager;
    public StageManager StageManager => _stageManager;

    private void Awake()
    {
        _gameState = new StateMachine(this); // StateMachineインスタンス化
    }

    void Start()
    {
        _gameState.Initialize(GameState.gameStart); // 最初はGameStartステートから始まるので、初期値を入れる
        _sceneManager = GetComponent<SceneManager>();
        _stageManager = GetComponent<StageManager>();

    }

    void Update()
    {
        _gameState?.Update(); // GameStateMachineがNullではないときに、常時StateMachineを呼び出す
    }
}
