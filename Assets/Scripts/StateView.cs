using UnityEngine;
using UnityEngine.UI;

public class StateView : MonoBehaviour
{
    [SerializeField] Text _stateViewText;
    private GameObject _player;
    private PlayerController _playerController;
    private StateMachine _playerStateMachine;

    void Start()
    {
        _player = GameObject.FindWithTag("Player").gameObject;
        _playerController = _player.GetComponent<PlayerController>();
        _playerStateMachine = _playerController.PlayerStateMachine;
        _playerStateMachine.StateChanged += View;
    }

    void View(IState state)
    {
        _stateViewText.text = state?.GetType().Name;
    }
}
