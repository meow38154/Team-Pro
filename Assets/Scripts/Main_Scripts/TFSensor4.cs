using UnityEngine;

public class TFSensor4 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManagerr.Instance.Stage3Open && SettingManagerr.Instance.Stage2Open && SettingManagerr.Instance.Stage1Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = true;
        }

        else
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = false;
        }
    }
}
