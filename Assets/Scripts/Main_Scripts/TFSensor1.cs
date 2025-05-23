using UnityEngine;

public class TFSensor1 : MonoBehaviour
{
    private void Update()
    {
        if (DoorOC.Instance.stage1Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.stage1Open;
        }

        if (DoorOC.Instance.stage1Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.stage1Open;
        }
    }
}
