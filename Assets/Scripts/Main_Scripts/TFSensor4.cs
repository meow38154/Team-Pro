using UnityEngine;

public class TFSensor4 : MonoBehaviour
{
    private void Update()
    {
        if (SettingManagerr.Instance.Copper >= 20 && SettingManagerr.Instance.Iron >= 18 && SettingManagerr.Instance.Gold >= 10)
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
