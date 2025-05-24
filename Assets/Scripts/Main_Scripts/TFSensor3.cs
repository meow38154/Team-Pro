using UnityEngine;

public class TFSensor3 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManager.Instance.Stage3Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = SettingManager.Instance.Stage3Open;
        }

        if (SettingManager.Instance.Stage3Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = SettingManager.Instance.Stage3Open;
        }
    }
}
