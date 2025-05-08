using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask _ignore;

    private RaycastHit2D upHitData;
    private RaycastHit2D downHitData;
    private RaycastHit2D leftHitData;
    private RaycastHit2D rightHitData;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upHitData = Physics2D.Raycast(transform.position, Vector2.up, 1, ~_ignore);
        downHitData = Physics2D.Raycast(transform.position, Vector2.down, 1, ~_ignore);
        leftHitData = Physics2D.Raycast(transform.position, Vector2.left, 1, ~_ignore);
        rightHitData = Physics2D.Raycast(transform.position, Vector2.right, 1, ~_ignore);
        Debug.DrawRay(transform.position, Vector2.left * 1, Color.red);
        Debug.DrawRay(transform.position, Vector2.right * 1, Color.red);
        Debug.DrawRay(transform.position, Vector2.up * 1, Color.red);
        Debug.DrawRay(transform.position, Vector2.down * 1, Color.red);
    }

    public RaycastHit2D GetRay(Vector2 vector2)
    {
        if (vector2 == Vector2.up)
            return upHitData;
        else if (vector2 == Vector2.down)
            return downHitData;
        else if (vector2 == Vector2.left)
            return leftHitData;
        else
            return rightHitData;
    }
}
