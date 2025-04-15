using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsWall;

    private Rigidbody2D _rb;
    private BoxCollider2D _boxColl;
    private Vector2 _detecterPos;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _boxColl = GetComponent<BoxCollider2D>();
    }


    public void MoveIt(GameObject detector)
    {
        _detecterPos = detector.transform.localPosition;
        RaycastHit2D hitData = Physics2D.Raycast(transform.position + (Vector3)_detecterPos, _detecterPos, 30, _whatIsWall);

        Debug.DrawRay(transform.position + (Vector3)_detecterPos, _detecterPos * 30, Color.red);

        if (hitData)
        {
            Debug.Log("Push");
            if (hitData.collider.gameObject.layer == LayerMask.NameToLayer("Goal"))
            {
                transform.DOMove(hitData.transform.position, 1).SetEase(Ease.OutQuart).OnComplete(() => Destroy(gameObject));
                Debug.Log("Push1");
            }
            else
            {
                transform.DOMove(hitData.transform.position - (Vector3)_detecterPos, 1).SetEase(Ease.OutQuart);
                Debug.Log("Push2");
            }
        }
    }
}
