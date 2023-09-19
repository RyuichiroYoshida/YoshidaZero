using UnityEngine;
using UnityEngine.UI;

public class ResultManager : MonoBehaviour
{
    Text _killCounterText;
    Text _timerText;
    void Start()
    {

    }
    void Update()
    {
        _killCounterText.text = GameManager.instance.KillCounter.ToString();
        _timerText.text = GameManager.instance.Timer.ToString();
    }
}
