using DG.Tweening;
using System;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovementDetect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rend;
    [SerializeField] private GameObject _player;
    [SerializeField] private Manager2 _manager;
    [SerializeField] private string _playerName = "RWS_Player";
    [SerializeField] private string _managerName = "RWS_Manager";
    [SerializeField] private bool _isBlocking;
    [SerializeField] private bool _isPushable;
    [SerializeField] private PushableObject _pushableObject;
    [SerializeField] private Vector2 _dir;

    private RaycastHit2D hitData;
    private string[] _blockTagArr;
    private string[] _pushableTagArr;
    private GameObject lastHitObject = null;

    private void Awake()
    {
        _player = GameObject.Find(_playerName);
        _manager = GameObject.Find(_managerName).GetComponent<Manager2>();
    }

    private void Start()
    {
        _blockTagArr = _manager.GetBlockTagArr();
        _pushableTagArr = _manager.GetPushableTagArr();
        _rend = GetComponent<SpriteRenderer>();
        _dir = transform.localPosition;
    }

    public void OnClick()
    {
        if (_isBlocking == false)
        {
            Vector2 newPosition = _player.transform.position;
            newPosition += _dir;
            _player.transform.position = newPosition;
        }
        else if (_isPushable == true)
        {
            _pushableObject?.MoveIt(gameObject);
        }
    }
    private void Update()
    {
        RaycastHit2D hitData = _player.GetComponent<Player>().GetRay(_dir);

        if (hitData.collider != null)
        {
            if (lastHitObject != hitData.collider.gameObject)
            {
                print("in");
            }

            _pushableObject = hitData.collider.gameObject.GetComponent<PushableObject>();

            bool isBlocking = false;
            bool isPushable = false;

            foreach (string btag in _blockTagArr)
            {
                if (hitData.collider.CompareTag(btag))
                {
                    isBlocking = true;

                    foreach (string ptag in _pushableTagArr)
                    {
                        if (hitData.collider.CompareTag(ptag))
                        {
                            isPushable = true;
                            break;
                        }
                    }
                    break;
                }
            }

            _isBlocking = isBlocking;
            _isPushable = isPushable;

            if (_isPushable)
            {
                _rend.color = Color.yellow;
            }
            else if (_isBlocking)
            {
                _rend.color = Color.red;
            }

            lastHitObject = hitData.collider.gameObject;
        }
        else if (lastHitObject != null)
        {
            print("out");
            _isBlocking = false;
            _isPushable = false;
            _rend.color = Color.green;
            lastHitObject = null;
        }
    }
    //private void Update()
    //{
    //    if(_player.GetComponent<Player>().GetRay(_dir))
    //        hitData = _player.GetComponent<Player>().GetRay(_dir);
    //    if(hitData.collider != null)
    //    {
    //        _pushableObject = hitData.collider.gameObject.GetComponent<PushableObject>();
    //        print("in");
    //        foreach (string btag in _blockTagArr)
    //        {
    //            if (hitData.collider.gameObject.CompareTag(btag))
    //            {
    //                foreach (string ptag in _pushableTagArr)
    //                {
    //                    if (hitData.collider.gameObject.CompareTag(ptag))
    //                    {
    //                        _rend.color = Color.yellow;
    //                        _isPushable = true;
    //                    }
    //                    else
    //                    {
    //                        _rend.color = Color.red;
    //                        _isPushable = false;
    //                    }
    //                    _isBlocking = true;
    //                }
    //            }
    //            else
    //            {
    //                foreach (string ptag in _pushableTagArr)
    //                {
    //                    if (hitData.collider.gameObject.CompareTag(ptag))
    //                    {
    //                        _rend.color = Color.yellow;
    //                        _isPushable = true;
    //                    }
    //                    else
    //                    {
    //                        _isPushable = false;
    //                    }
    //                    _isBlocking = true;
    //                }
    //            }
    //        }
    //        lastHitObject = hitData.collider.gameObject;
    //    }
    //    if (hitData.collider == null && lastHitObject != null)
    //    {
    //        print("out");
    //        _isBlocking = false;
    //        _isPushable = false;
    //        _rend.color = Color.green;
    //        lastHitObject = null;
    //    }
    //}

    //    private void OnTriggerEnter2D(Collider2D collision)
    //    {
    //        print("in");
    //        _pushableObject = collision.gameObject.GetComponent<PushableObject>();
    //        foreach (string btag in _blockTagArr)
    //        {
    //            if (collision.gameObject.CompareTag(btag))
    //            {
    //                foreach (string ptag in _pushableTagArr)
    //                {
    //                    if (collision.gameObject.CompareTag(ptag))
    //                    {
    //                        _rend.color = Color.yellow;
    //                        _isPushable = true;
    //                    }
    //                    else
    //                    {
    //                        _rend.color = Color.red;
    //                        _isPushable = false;
    //                    }
    //                    _isBlocking = true;
    //                }
    //            }
    //            else
    //            {
    //                foreach (string ptag in _pushableTagArr)
    //                {
    //                    if (collision.gameObject.CompareTag(ptag))
    //                    {
    //                        _rend.color = Color.yellow;
    //                        _isPushable = true;
    //                    }
    //                    else
    //                    {
    //                        _isPushable = false;
    //                    }
    //                    _isBlocking = true;
    //                }
    //            }
    //        }
    //    }
    //    private void OnTriggerExit2D(Collider2D collision)
    //    {
    //        print("out");
    //        _isBlocking = false;
    //        _isPushable = false;
    //        _rend.color = Color.green;
    //    }
}
