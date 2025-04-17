using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Analytics.IAnalytic;

public class PushableObject : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsWall;
    [SerializeField] private bool _isDestroy;
    [SerializeField] string _blockType;

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
            StartCoroutine(MoveAndDisable(hitData));
        }
    }

    IEnumerator MoveAndDisable(RaycastHit2D hit)
    {
        Tween tween;
        tween = transform.DOMove(hit.transform.position - (Vector3)_detecterPos, 1).SetEase(Ease.OutQuart);
        yield return tween.WaitForCompletion();
        if (_isDestroy)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_blockType == "Nab")
        {
            if (collision.gameObject.CompareTag("Nab_Goal"))
            {
                _isDestroy = true;
            }
            else
            {
                _isDestroy = false;
            }
        }

        if (_blockType == "Iron")
        {
            if (collision.gameObject.CompareTag("Iron_Goal"))
            {
                _isDestroy = true;
            }
            else
            {
                _isDestroy = false;
            }
        }

        if (_blockType == "Gold")
        {
            if (collision.gameObject.CompareTag("Gold_Goal"))
            {
                _isDestroy = true;
            }
            else
            {
                _isDestroy = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isDestroy = false;
    }
}
