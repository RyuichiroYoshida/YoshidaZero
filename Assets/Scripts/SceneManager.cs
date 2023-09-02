using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    [SerializeField] Image _fade;

    /// <summary>
    /// 引数のシーン名に遷移します
    /// </summary>
    /// <param name="sceneName">シーン名</param>
    public void SceneChange(string sceneName)
    {
        _fade.DOFade(0, 1f).onComplete = () => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}
