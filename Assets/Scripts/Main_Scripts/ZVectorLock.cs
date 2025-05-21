using UnityEngine;

public class ZVectorLock : MonoBehaviour
{
    [SerializeField] float Vectorz = -2f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Vectorz);
    }
}
