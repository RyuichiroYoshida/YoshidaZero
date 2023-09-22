using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _jumpVoice;
    [SerializeField] AudioClip _attackVoice;
    [SerializeField] AudioClip _deadVoice;
    public static SoundManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {

    }
}
