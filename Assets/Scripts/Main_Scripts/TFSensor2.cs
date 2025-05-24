using UnityEngine;

public class TFSensor2 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManager.Instance.Stage2Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = SettingManager.Instance.Stage2Open;
        }

        if (SettingManager.Instance.Stage2Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = SettingManager.Instance.Stage2Open;
        }
    }
}
