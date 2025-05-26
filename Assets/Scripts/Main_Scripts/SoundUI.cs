using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SoundUI : MonoBehaviour
{
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider sfxSlider;

    private void OnEnable()
    {
        masterSlider.value = SettingManagerr.Instance.Master;
        bgmSlider.value = SettingManagerr.Instance.BGM;
        sfxSlider.value = SettingManagerr.Instance.SoundEffect;
    }

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
