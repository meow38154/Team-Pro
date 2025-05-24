using UnityEngine;

public class TFSensor1 : MonoBehaviour
{
    private void Update()
    {
        if (DoorOC.Instance.Stage1Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.Stage1Open;
        }

        if (DoorOC.Instance.Stage1Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.Stage1Open;
        }
    }
}
