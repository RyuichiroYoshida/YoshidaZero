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
        _gameState = new StateMachine(this); // StateMachine�C���X�^���X��
    }

    void Start()
    {
        _pausePanel.SetActive(false);

        _gameState.Initialize(GameState.gameStart); // �ŏ���GameStart�X�e�[�g����n�܂�̂ŁA�����l������
        _sceneManager = GetComponent<SceneManager>();
        _stageManager = GetComponent<StageManager>();
        _playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<Input>();

    }

    void Update()
    {
        _gameState?.Update(); // GameStateMachine��Null�ł͂Ȃ��Ƃ��ɁA�펞StateMachine���Ăяo��
    }
}
