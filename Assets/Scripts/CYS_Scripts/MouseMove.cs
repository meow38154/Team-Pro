using UnityEngine;

public class MouseMove : MonoBehaviour
{
    [field:SerializeField] public bool _start { get; set; }
    void Update()
    {
        if (_start == false)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;
            transform.position = new Vector3(mousePosition.x, mousePosition.y - 3, mousePosition.z);
        }

        else
        {
            transform.position = new Vector3(3.8f, -5.5f, 0);
        }

    }
}
