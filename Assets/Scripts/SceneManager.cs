using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Image _fade;

    /// <summary>
    /// �����̃V�[�����ɑJ�ڂ��܂�
    /// </summary>
    /// <param name="sceneName">�V�[����</param>
    public void SceneChange(string sceneName)
    {
        _fade.DOFade(0, 1f).onComplete = () => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
