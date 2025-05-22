using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Block")]
    [SerializeField] AudioClip meltSound;
    [SerializeField] AudioClip pushSound;
    [Header("Step")]
    [SerializeField] AudioClip[] stepSounds;

    AudioSource _audioSource;

    private void Awake()
    {
        if(Instance == null)
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
