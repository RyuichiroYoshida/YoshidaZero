using UnityEngine;

public class PauseAudioManager : MonoBehaviour
{
    [SerializeField] AudioClip _panelSound;
    AudioSource _audioSource;
    void OnEnable()
    {
        _audioSource = SoundManager.instance.GetComponent<AudioSource>();
        _audioSource.PlayOneShot(_panelSound);
    }
}
