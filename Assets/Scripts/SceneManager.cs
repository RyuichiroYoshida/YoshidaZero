using UnityEngine;

public class SceneManager : MonoBehaviour
{
    /// <summary>
    /// �����̃V�[�����ɑJ�ڂ��܂�
    /// </summary>
    /// <param name="sceneName">�V�[����</param>
    public void SceneChange(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
