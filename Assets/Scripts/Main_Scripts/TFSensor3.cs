using UnityEngine;

public class TFSensor3 : MonoBehaviour
{
    private void Update()
    {
        if (DoorOC.Instance.stage3Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.stage3Open;
        }

        if (DoorOC.Instance.stage3Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.stage3Open;
        }
    }
}
