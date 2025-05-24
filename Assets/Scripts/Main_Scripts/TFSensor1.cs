using UnityEngine;

public class TFSensor1 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManagerr.Instance.Stage1Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = SettingManagerr.Instance.Stage1Open;
        }

        if (SettingManagerr.Instance.Stage1Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = SettingManagerr.Instance.Stage1Open;
        }
    }
}
