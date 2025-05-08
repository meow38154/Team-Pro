using UnityEngine;

namespace CYS_Scripts
{
    public class CubeCubeCube : MonoBehaviour
    {
        float speed = 500;
        // Update is called once per frame
        void Update()
        {
            transform.Rotate(0, -1 * Time.deltaTime * speed, 0);
        }
    }
}
