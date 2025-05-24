using UnityEngine;

public class  VolumeManager : MonoBehaviour
{
    public static VolumeManager Instance;

    [Header("Volume")]
    [field: SerializeField] public float Master { get; set; }
    [field: SerializeField] public float BGM { get; set; }
    [field: SerializeField] public float SoundEffect { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
