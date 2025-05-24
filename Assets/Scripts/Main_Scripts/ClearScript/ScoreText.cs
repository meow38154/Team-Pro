using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshPro _c;
    [SerializeField] TextMeshPro _i;
    [SerializeField] TextMeshPro _g;
    [SerializeField] TextMeshPro _h;

    private void Update()
    {
        _c.text = "����: " + SettingManagerr.Instance.Copper;
        _i.text = "ö: " + SettingManagerr.Instance.Iron;
        _g.text = "��: " + SettingManagerr.Instance.Gold;
        _h.text = "�ձ�: " + SettingManagerr.Instance.HapGold;
    }
}
