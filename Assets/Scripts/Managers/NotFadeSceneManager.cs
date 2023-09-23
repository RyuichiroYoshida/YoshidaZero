using UnityEngine;

public class NotFadeSceneManager : MonoBehaviour
{
    public void SeceneChange(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
}
