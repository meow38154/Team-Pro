using UnityEngine;
using System.Collections;

public class Lws_ImageMove : MonoBehaviour
{
    [SerializeField] GameObject _traget;
    [SerializeField] float _moveSpeed = 3f;
    Vector3 _tragetPos;
    Vector3 _myPos;
    Vector3 _moveVec;
    bool _moveing = false;
    void Start()
    {
        _tragetPos = _traget.transform.position;
        transform.position = _tragetPos;
        _myPos = transform.position;
    }

    void Update()
    {
        _myPos = transform.position;
        _tragetPos = _traget.transform.position;
        if (_tragetPos != _myPos)
        {
            if (_moveing)
            {
                _moveVec = (_tragetPos - _myPos);
                transform.position += _moveVec * Time.deltaTime * _moveSpeed;
            }
            else
            {
                _moveing = true;
            }
        }
        else
        {
            _moveing = false;
        }
    }
}
