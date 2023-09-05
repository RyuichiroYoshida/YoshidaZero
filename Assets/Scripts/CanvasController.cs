using UnityEngine;

public class CanvasController : MonoBehaviour
{
    Input _playerInput;
    GameObject _pausePanel;
    void Start()
    {
        _playerInput = GameObject.FindWithTag("Player").GetComponent<Input>();
        _pausePanel = transform.Find("PausePanel").gameObject;
    }

    void Update()
    {
        if (_playerInput.IsPause)
            _pausePanel.SetActive(true);
        else
            _pausePanel.SetActive(false);
    }
}
