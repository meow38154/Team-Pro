using UnityEngine;
using System.Collections;

public class Lws_ImageMove : MonoBehaviour
{
    GameObject _parent;
    Vector3 _parentPos;
    Vector3 _myPos;
    Vector3 _moveVec;
    void Start()
    {
        _parent = transform.parent.gameObject;
        _parentPos = _parent.transform.position;
        transform.position = _parentPos;
        _myPos = transform.position;
    }

    void Update()
    {



    }



}
