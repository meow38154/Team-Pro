using UnityEngine;
using TMPro;

public class SoundUI : MonoBehaviour
{
    private void Update()
    {
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (SettingManager.Instance.Master).ToString();
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = (SettingManager.Instance.BGM).ToString();
        
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (SettingManager.Instance.SoundEffect).ToString();
    }

    public void MasterUp()
    {
        if (SettingManager.Instance.Master < 10)
        {
            SettingManager.Instance.Master += 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MasterDown()
    {
        if (SettingManager.Instance.Master > 0)
        {
            SettingManager.Instance.Master -= 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MusicUp()
    {
        if (SettingManager.Instance.BGM < 10)
        {
            SettingManager.Instance.BGM += 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MusicDown()
    {
        if (SettingManager.Instance.BGM > 0)
        {
            SettingManager.Instance.BGM -= 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void SoundUp()
    {
        if (SettingManager.Instance.SoundEffect < 10)
        {
            SettingManager.Instance.SoundEffect += 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void SoundDown()
    {
        if (SettingManager.Instance.SoundEffect > 0)
        {
            SettingManager.Instance.SoundEffect -= 1;
            AudioManager.Instance.PlayUICilck();
        }
    }
}
