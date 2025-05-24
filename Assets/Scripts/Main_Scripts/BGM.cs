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
        _audio.volume = SettingManager.Instance.BGM / 10 * SettingManager.Instance.Master / 10;
    }
}
