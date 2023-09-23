using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioClip _damageVoice;
    [SerializeField] AudioClip _startVoice;
    [SerializeField] AudioClip _restartSound;
    [SerializeField] AudioClip _pauseButtonSound;
    [SerializeField] AudioClip _enemyDestroy;
    [SerializeField] AudioClip _bulletShot;
    [SerializeField] AudioClip _bulletReflection;
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
    public void ReatartSound()
    {
        _audioSource.PlayOneShot(_restartSound);
    }
    public void PanelButtonSound()
    {
        _bgm.Stop();
        _audioSource.PlayOneShot(_pauseButtonSound);
    }
    public void EnemyDestroy()
    {
        _audioSource.PlayOneShot(_enemyDestroy);
    }
    public void BulletShot()
    {
        _audioSource.PlayOneShot(_bulletShot);
    }
    public void BulletReflection()
    {
        _audioSource.PlayOneShot(_bulletReflection);
    }
}
