using UnityEngine;

public class BGM : MonoBehaviour
{
    AudioSource _audio;

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        _audio.volume = VolumeManager.Instance.BGM / 10 * VolumeManager.Instance.Master / 10;
    }
}
