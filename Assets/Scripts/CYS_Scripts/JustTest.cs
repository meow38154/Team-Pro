using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class JustTest : MonoBehaviour
{
    private Rigidbody2D _rb;
    Vector2 _moveDir;
    float speed = 10f;


    private void Start()
    {
      _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       _rb.linearVelocity = _moveDir * speed;
    }



    void OnMove(InputValue value)
    {
        _moveDir = value.Get<Vector2>();
    }

}
