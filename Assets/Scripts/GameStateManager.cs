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
        _gameState = new StateMachine(this); // StateMachine�C���X�^���X��
    }

    void Start()
    {
        _gameState.Initialize(GameState.gameStart); // �ŏ���GameStart�X�e�[�g����n�܂�̂ŁA�����l������
        _sceneManager = GetComponent<SceneManager>();
        _stageManager = GetComponent<StageManager>();

    }

    void Update()
    {
        _gameState?.Update(); // GameStateMachine��Null�ł͂Ȃ��Ƃ��ɁA�펞StateMachine���Ăяo��
    }
}
