using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _damageVoice;
    [SerializeField] AudioClip _startVoice;
    [SerializeField] AudioSource _bgm;
    AudioSource _audioSource;
    bool _isPlaying = false;
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
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(VoiceStart());
    }
    void Update()
    {
        if (GameManager.instance.IsDead && !_isPlaying)
        {
            _audioSource.PlayOneShot(_damageVoice);
            _isPlaying = true;
            _bgm.Stop();
        }
    }
    IEnumerator VoiceStart()
    {
        yield return new WaitForSeconds(1.5f);
        _audioSource.PlayOneShot(_startVoice);
    }
}
