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
        _audio.volume = SettingManagerr.Instance.BGM / 10 * SettingManagerr.Instance.Master / 10;
    }
}
