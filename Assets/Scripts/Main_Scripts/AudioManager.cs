using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Melt")]
    [SerializeField] AudioClip meltSound;
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
}
