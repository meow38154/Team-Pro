using UnityEngine;

public class CrackCountMove : MonoBehaviour
{
    [SerializeField] Transform imageTraget;

    private void Update()
    {
        transform.position = imageTraget.position;
    }


}
