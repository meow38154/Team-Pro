using UnityEngine;
using TMPro;

public class SoundUI : MonoBehaviour
{
    private void Update()
    {
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (SettingManagerr.Instance.Master).ToString();
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = (SettingManagerr.Instance.BGM).ToString();
        
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (SettingManagerr.Instance.SoundEffect).ToString();
    }

    public void MasterUp()
    {
        if (SettingManagerr.Instance.Master < 10)
        {
            SettingManagerr.Instance.Master += 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MasterDown()
    {
        if (SettingManagerr.Instance.Master > 0)
        {
            SettingManagerr.Instance.Master -= 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MusicUp()
    {
        if (SettingManagerr.Instance.BGM < 10)
        {
            SettingManagerr.Instance.BGM += 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MusicDown()
    {
        if (SettingManagerr.Instance.BGM > 0)
        {
            SettingManagerr.Instance.BGM -= 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void SoundUp()
    {
        if (SettingManagerr.Instance.SoundEffect < 10)
        {
            SettingManagerr.Instance.SoundEffect += 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void SoundDown()
    {
        if (SettingManagerr.Instance.SoundEffect > 0)
        {
            SettingManagerr.Instance.SoundEffect -= 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
}
