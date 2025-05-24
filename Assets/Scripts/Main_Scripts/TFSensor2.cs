using UnityEngine;

public class TFSensor2 : MonoBehaviour
{
    private void Update()
    {
        if (DoorOC.Instance.Stage2Open)
        {
            GetComponent<Blocks>().Wall();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.Stage2Open;
        }

        if (DoorOC.Instance.Stage2Open == false)
        {
            GetComponent<Blocks>().WallTrue();
            GetComponent<GoalIn>()._openClose = DoorOC.Instance.Stage2Open;
        }
    }
}
