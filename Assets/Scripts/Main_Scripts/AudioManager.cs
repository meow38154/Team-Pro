using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Block")]
    [SerializeField] AudioClip meltSound;
    [SerializeField] AudioClip pushSound;
    [SerializeField] AudioClip doorSound;
    [SerializeField] AudioClip portalSound;

    [Header("Step")]
    [SerializeField] AudioClip[] stepSounds;

    [Header("UI")]
    [SerializeField] AudioClip uiCilck;
    [SerializeField] AudioClip resetPlay;

    [Header("Clear")]
    [SerializeField] AudioClip _clear;
    [SerializeField] AudioClip _su;

    AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            Debug.LogError("AudioManager: AudioSource가 없습니다!");
        }
    }
    public void PlayStep()
    {
        _audioSource.PlayOneShot(stepSounds[UnityEngine.Random.Range(0, stepSounds.Length)], SettingManagerr.Instance.SoundEffect / 10 * SettingManagerr.Instance.Master / 10);
    }
    public void PlayUICilck()
    {
        _audioSource.PlayOneShot(uiCilck, SettingManagerr.Instance.SoundEffect / 10 * SettingManagerr.Instance.Master / 10);
    }

    public void PlayResetPlay()
    {
        _audioSource.PlayOneShot(resetPlay, SettingManagerr.Instance.SoundEffect / 10 * SettingManagerr.Instance.Master / 10);
    }

    public void PlayOpenDoor()
    {
        _audioSource.PlayOneShot(doorSound, SettingManagerr.Instance.SoundEffect / 10 * SettingManagerr.Instance.Master / 10);
    }


    public void PlayMelt()
    {
        _audioSource.PlayOneShot(meltSound, SettingManagerr.Instance.SoundEffect / 10 * SettingManagerr.Instance.Master / 10);
        Debug.Log("Melted!");
    }

    public void PlayPush()
    {
        _audioSource.PlayOneShot(pushSound, SettingManagerr.Instance.SoundEffect / 10 * SettingManagerr.Instance.Master / 10);
        Debug.Log("Pushed!");
    }

    public void Clear()
    {
        _audioSource.PlayOneShot(_clear, SettingManagerr.Instance.BGM / 10 * SettingManagerr.Instance.Master / 10);
        Debug.Log("클리어소리");
    }

    public void SuChange()
    {
        _audioSource.PlayOneShot(_su, SettingManagerr.Instance.SoundEffect / 10 * SettingManagerr.Instance.Master / 10);
        Debug.Log("클리어소리");
    }
}
