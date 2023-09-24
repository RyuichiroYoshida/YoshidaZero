using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] bool _stageClear = false;
    [SerializeField] string _sceneName;
    public bool StageClear => _stageClear;
    /// <summary>
    /// 引数のシーン名に遷移します
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public void SceneChange(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _stageClear = true;
            PlayerPrefs.SetFloat("Kill", GameManager.instance.KillCounter);
            PlayerPrefs.SetFloat("Time", GameManager.instance.Timer);
            SceneChange(_sceneName);
        }
    }
}
