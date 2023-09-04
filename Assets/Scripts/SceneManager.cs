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
        this.gameObject.SetActive(false);
        _fade.DOFade(1, 5f).OnComplete(() => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName));
    }
}
