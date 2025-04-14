using UnityEngine;
using UnityEngine.InputSystem;

public class PushableObject : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] private LayerMask _whatIsWall;
    private Vector2 _detecterPos;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    public void MoveIt(GameObject gameObject)
    {
        _detecterPos = gameObject.transform.localPosition;
        RaycastHit2D hitData = Physics2D.Raycast(transform.position, _detecterPos, 30, _whatIsWall);

        Debug.DrawRay(transform.position, _detecterPos * 30, Color.red);

        if (hitData)
        {
            Debug.DrawRay(transform.position, _detecterPos.normalized * 30, Color.red);
            transform.position = (hitData.transform.position - (Vector3)_detecterPos);
            Debug.Log("Push");
        }
    }


}
