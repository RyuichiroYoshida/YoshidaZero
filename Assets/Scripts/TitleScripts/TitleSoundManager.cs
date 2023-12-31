using UnityEngine;

public class TitleSoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _buttonSound;
    AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    public void ButtonSound()
    {
        _audioSource.PlayOneShot(_buttonSound);
    }
}
