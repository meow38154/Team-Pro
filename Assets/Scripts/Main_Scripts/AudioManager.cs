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
        _audioSource.PlayOneShot(stepSounds[UnityEngine.Random.Range(0, stepSounds.Length)]);
    }
    public void PlayUICilck()
    {
        _audioSource.PlayOneShot(uiCilck, 1);
    }

    public void PlayResetPlay()
    {
        _audioSource.PlayOneShot(resetPlay, 1);
    }

    public void PlayOpenDoor()
    {
        _audioSource.PlayOneShot(doorSound, 1);
    }


    public void PlayMelt()
    {
        _audioSource.PlayOneShot(meltSound, 1);
        Debug.Log("Melted!");
    }

    public void PlayPush()
    {
        _audioSource.PlayOneShot(pushSound, 1);
        Debug.Log("Pushed!");
    }
}
