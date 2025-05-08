using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class ImageMove : MonoBehaviour
{
    [FormerlySerializedAs("_traget")] [SerializeField] GameObject traget;
    [FormerlySerializedAs("_moveSpeed")] [SerializeField] private float moveSpeed = 3f;
    private Vector3 _targetPos;
    private Vector3 _myPos;
    Vector3 _moveVec;
    bool _moving = false;

    public ImageMove(Vector3 targetPos, Vector3 moveVec)
    {
        this._targetPos = targetPos;
        _moveVec = moveVec;
    }

    void Start()
    {
        _targetPos = traget.transform.position;
        transform.position = _targetPos;
        _myPos = transform.position;
    }

    void Update()
    {
        _myPos = transform.position;
        _targetPos = traget.transform.position;
        if (_targetPos != _myPos)
        {
            if (_moving)
            {
                _moveVec = (_targetPos - _myPos);
                transform.position += _moveVec * Time.deltaTime * moveSpeed;
            }
            else
            {
                _moving = true;
            }
        }
        else
        {
            _moving = false;
        }
    }

    
    public void Disable()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Enable()
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
