using UnityEngine;
using UnityEngine.UI;

public class StateView : MonoBehaviour
{
    [SerializeField] Text _stateViewText;

    private PlayerController _playerController;

    void Start()
    {
            
    }
    void Update()
    {
        _stateViewText.text = _playerController.PlayerStateMachine.CurrentState.ToString();
    }
}
