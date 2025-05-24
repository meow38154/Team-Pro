using UnityEngine;

public class TFSensor2 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManagerr.Instance.Stage2Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = SettingManagerr.Instance.Stage2Open;
        }

        if (SettingManagerr.Instance.Stage2Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = SettingManagerr.Instance.Stage2Open;
        }
    }
}
