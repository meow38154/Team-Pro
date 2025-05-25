using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    public void MasterChange()
    {
        SettingManagerr.Instance.Master = masterSlider.value;
    }
    public void BGMChange()
    {
        SettingManagerr.Instance.BGM = bgmSlider.value;
    }
    public void SFXChange()
    {
        SettingManagerr.Instance.SoundEffect = sfxSlider.value;
    }

}
