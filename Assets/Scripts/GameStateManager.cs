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
        _gameState = new StateMachine(this);
    }

    void Start()
    {
        _gameState.Initialize(GameState.gameStart);
        _sceneManager = GetComponent<SceneManager>();
        _stageManager = GetComponent<StageManager>();

    }

    void Update()
    {
        _gameState?.Update(); // GameStateMachine‚ªNull‚Å‚Í‚È‚¢‚Æ‚«‚ÉAíStateMachine‚ğŒÄ‚Ño‚·
    }
}
