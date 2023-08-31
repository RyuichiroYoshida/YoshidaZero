using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
