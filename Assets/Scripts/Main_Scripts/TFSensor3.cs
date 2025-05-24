using UnityEngine;

public class TFSensor3 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManagerr.Instance.Stage3Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = SettingManagerr.Instance.Stage3Open;
        }

        if (SettingManagerr.Instance.Stage3Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = SettingManagerr.Instance.Stage3Open;
        }
    }
}
