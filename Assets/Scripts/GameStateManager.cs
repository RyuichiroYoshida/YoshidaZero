using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(SceneManager), typeof(StageManager))]
public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject _pausePanel;
    StateMachine _gameState;
    SceneManager _sceneManager;
    StageManager _stageManager;
    Input _playerInput;
    public StateMachine GameState => _gameState;
    public SceneManager SceneManager => _sceneManager;
    public StageManager StageManager => _stageManager;
    public Input PlayerInput => _playerInput;

    private void Awake()
    {
        _gameState = new StateMachine(this); // StateMachineインスタンス化
    }

    void Start()
    {
        _pausePanel.SetActive(false);

        _gameState.Initialize(GameState.gameStart); // 最初はGameStartステートから始まるので、初期値を入れる
        _sceneManager = GetComponent<SceneManager>();
        _stageManager = GetComponent<StageManager>();
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<Input>();

    }

    void Update()
    {
        _gameState?.Update(); // GameStateMachineがNullではないときに、常時StateMachineを呼び出す
    }
}
