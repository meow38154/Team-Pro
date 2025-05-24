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
    }
    public void PlayStep()
    {
        _audioSource.PlayOneShot(stepSounds[UnityEngine.Random.Range(0, stepSounds.Length)], VolumeManager.Instance.SoundEffect / 10 * VolumeManager.Instance.Master / 10);
    }
    public void PlayUICilck()
    {
        _audioSource.PlayOneShot(uiCilck, VolumeManager.Instance.SoundEffect / 10 * VolumeManager.Instance.Master / 10);
    }

    public void PlayResetPlay()
    {
        _audioSource.PlayOneShot(resetPlay, VolumeManager.Instance.SoundEffect / 10 * VolumeManager.Instance.Master / 10);
    }

    public void PlayOpenDoor()
    {
        _audioSource.PlayOneShot(doorSound, VolumeManager.Instance.SoundEffect / 10 * VolumeManager.Instance.Master / 10);
    }


    public void PlayMelt()
    {
        _audioSource.PlayOneShot(meltSound, VolumeManager.Instance.SoundEffect / 10 * VolumeManager.Instance.Master / 10);
        Debug.Log("Melted!");
    }

    public void PlayPush()
    {
        _audioSource.PlayOneShot(pushSound, VolumeManager.Instance.SoundEffect / 10 * VolumeManager.Instance.Master / 10);
        Debug.Log("Pushed!");
    }
}
