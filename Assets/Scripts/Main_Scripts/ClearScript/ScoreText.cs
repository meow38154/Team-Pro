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
        _c.text = "구리: " + SettingManagerr.Instance.Copper;
        _i.text = "철: " + SettingManagerr.Instance.Iron;
        _g.text = "금: " + SettingManagerr.Instance.Gold;
        _h.text = "합금: " + SettingManagerr.Instance.HapGold;
    }
}
