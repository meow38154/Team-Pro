using UnityEngine;

public class TFSensor2 : MonoBehaviour
{
    private void Update()
    {
        if (DoorOC.Instance.stage2Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.stage2Open;
        }

        if (DoorOC.Instance.stage2Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.stage2Open;
        }
    }
}
