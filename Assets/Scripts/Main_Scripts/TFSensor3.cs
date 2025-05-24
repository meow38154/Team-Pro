using UnityEngine;

public class TFSensor3 : MonoBehaviour
{
    private void Update()
    {
        if (DoorOC.Instance.Stage3Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.Stage3Open;
        }

        if (DoorOC.Instance.Stage3Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.Stage3Open;
        }
    }
}
