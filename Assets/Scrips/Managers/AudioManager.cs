using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Pool;

public enum AudioSourceType
{ 
    SFX,
    UI
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource sfxAudioSourcePrefab;
    [SerializeField] private AudioSource uiAudioSourcePrefab;
    [SerializeField] private bool collectionCheck = true;
    [SerializeField] private int defaultCapacity = 20;
    [SerializeField] private int maxSize = 100;

    private AudioSource _musicAudioSource;
    private IObjectPool<AudioSource> _sfxPool;
    private IObjectPool<AudioSource> _uiPool;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _musicAudioSource = GetComponent<AudioSource>();

        _sfxPool = new ObjectPool<AudioSource>(
            CreateSfxAudioSource, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            collectionCheck, defaultCapacity, maxSize);

        _uiPool = new ObjectPool<AudioSource>(
            CreateUiAudioSource, OnGetFromPool, OnReleaseToPool, OnDestroyPooledObject,
            collectionCheck, defaultCapacity, maxSize);

    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    public void PlayMusic()
    {
        _musicAudioSource.Play();
    }

    public void PauseMusic()
    {
        _musicAudioSource.Pause();
    }

    public void StopMusic()
    {
        _musicAudioSource.Stop();
    }


    public void PlayClip(AudioClip clip, AudioSourceType type)
    {
        switch (type)
        {
            case AudioSourceType.SFX:
                {
                    AudioSource sfxAudioSource = _sfxPool.Get();
                    sfxAudioSource.clip = clip;
                    sfxAudioSource.Play();
                    StartCoroutine(ReleaseSfxAudioSourceIfFinish(sfxAudioSource));
                }
                break;
            case AudioSourceType.UI:
                {
                    AudioSource uiAudioSource = _uiPool.Get();
                    uiAudioSource.clip = clip;
                    uiAudioSource.Play();
                    StartCoroutine(ReleaseUiAudioSourceIfFinish(uiAudioSource));
                }
                break;
        }
    }

    private IEnumerator ReleaseSfxAudioSourceIfFinish(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        _sfxPool.Release(audioSource);
    }

    private IEnumerator ReleaseUiAudioSourceIfFinish(AudioSource audioSource)
    {
        yield return new WaitForSecondsRealtime(audioSource.clip.length);
        _uiPool.Release(audioSource);
    }


    private AudioSource CreateSfxAudioSource()
    {
        AudioSource sfxAudioSource = Instantiate(sfxAudioSourcePrefab);
        return sfxAudioSource;
    }

    private AudioSource CreateUiAudioSource()
    {
        AudioSource uiAudioSource = Instantiate(uiAudioSourcePrefab);
        return uiAudioSource;
    }

    private void OnReleaseToPool(AudioSource pooledObject)
    {
        pooledObject.enabled = false;
    }

    private void OnGetFromPool(AudioSource pooledObject)
    {
        pooledObject.enabled = true;
        pooledObject.Stop();
    }

    private void OnDestroyPooledObject(AudioSource pooledObject)
    {
        Destroy(pooledObject);
    }

    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Utils.LinearToDecibel(volume));
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Utils.LinearToDecibel(volume));
    }

    public void SetSfxVolume(float volume)
    {
        audioMixer.SetFloat("SfxVolume", Utils.LinearToDecibel(volume));
    }

    public void SetUiVolume(float volume)
    {
        audioMixer.SetFloat("UiVolume", Utils.LinearToDecibel(volume));
    }
}
