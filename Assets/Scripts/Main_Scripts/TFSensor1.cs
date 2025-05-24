using UnityEngine;

public class TFSensor1 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManager.Instance.Stage1Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = SettingManager.Instance.Stage1Open;
        }

        if (SettingManager.Instance.Stage1Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = SettingManager.Instance.Stage1Open;
        }
    }
}
