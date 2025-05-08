using DG.Tweening;
using System;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Main_PlayerMovementDetect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rend;
    [SerializeField] private GameObject _player;
    [SerializeField] private Main_Manager _manager;
    [SerializeField] private string _playerName = "RWS_Player";
    [SerializeField] private string _managerName = "RWS_Manager";
    [SerializeField] private bool _isBlocking;
    [SerializeField] private bool _isPushable;
    [SerializeField] private PushableObject _pushableObject;
    private string[] _blockTagArr;
    private string[] _pushableTagArr;

    private void Awake()
    {
        
        _player = GameObject.Find(_playerName);
        _manager = GameObject.Find(_managerName).GetComponent<Main_Manager>();
        _rend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _blockTagArr = _manager.GetBlockTagArr();
        _pushableTagArr = _manager.GetPushableTagArr();
    }

    public void OnClick()
    {
        if (_isBlocking == false)
        {
            Vector3 newPosition = _player.transform.position;
            newPosition += transform.localPosition;
            _player.transform.position = newPosition;
            
        }
        else if (_isPushable == true)
        {
            _pushableObject?.MoveIt(gameObject);
        }
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        _pushableObject = collision.gameObject.GetComponent<PushableObject>();
        foreach (string btag in _blockTagArr)
        {
            if (collision.gameObject.CompareTag(btag))
            {
                foreach (string ptag in _pushableTagArr)
                {
                    if (collision.gameObject.CompareTag(ptag))
                    {
                        _rend.color = Color.yellow;
                        _isPushable = true;
                    }
                    else
                    {
                        _rend.color = Color.red;
                        _isPushable = false;
                    }
                    _isBlocking = true;
                }
            }
            else
            {
                foreach (string ptag in _pushableTagArr)
                {
                    if (collision.gameObject.CompareTag(ptag))
                    {
                        _rend.color = Color.yellow;
                        _isPushable = true;
                    }
                    else
                    {
                        _isPushable = false;
                    }
                    _isBlocking = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        _isBlocking = false;
        _isPushable = false;
        _rend.color = Color.green;
    }
}
