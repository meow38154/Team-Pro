using UnityEngine;
using TMPro;

public class SoundUI : MonoBehaviour
{
    public void MasterUp()
    {
        if (VolumeManager.Instance.Master < 10)
        {
            VolumeManager.Instance.Master += 1;
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (VolumeManager.Instance.Master).ToString();
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MasterDown()
    {
        if (VolumeManager.Instance.Master > 0)
        {
            VolumeManager.Instance.Master -= 1;
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = (VolumeManager.Instance.Master).ToString();
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MusicUp()
    {
        if (VolumeManager.Instance.BGM < 10)
        {
            VolumeManager.Instance.BGM += 1;
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = (VolumeManager.Instance.BGM).ToString();
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void MusicDown()
    {
        if (VolumeManager.Instance.BGM > 0)
        {
            VolumeManager.Instance.BGM -= 1;
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(2).gameObject.GetComponent<TextMeshProUGUI>().text = (VolumeManager.Instance.BGM).ToString();
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void SoundUp()
    {
        if (VolumeManager.Instance.SoundEffect < 10)
        {
            VolumeManager.Instance.SoundEffect += 1;
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (VolumeManager.Instance.SoundEffect).ToString();
            AudioManager.Instance.PlayUICilck();
        }
    }
    public void SoundDown()
    {
        if (VolumeManager.Instance.SoundEffect > 0)
        {
            VolumeManager.Instance.SoundEffect -= 1;
            transform.GetChild(0).transform.GetChild(4).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text = (VolumeManager.Instance.SoundEffect).ToString();
            AudioManager.Instance.PlayUICilck();
        }
    }
}
