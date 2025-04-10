using System;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovementDetect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rend;
    [SerializeField] private GameObject _player;
    [SerializeField] private Manager _manager;
    [SerializeField] private string _playerName = "RWS_Player";
    [SerializeField] private string _managerName = "RWS_Manager";
    [SerializeField] private bool _isBlocked;

    private float _playerX;
    private float _playerY;
    private string[] _tagArr;

    private void Awake()
    {
        _player = GameObject.Find(_playerName);
        _manager = GameObject.Find(_managerName).GetComponent<Manager>();
        _rend = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _tagArr = _manager._managerTagArr;
    }

    public void OnClick()
    {
        if (_isBlocked == false)
        {
            Vector3 newPosition = _player.transform.position;
            newPosition += transform.localPosition;
            _player.transform.position = newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (string elem in _tagArr)
        {
            if (collision.gameObject.CompareTag(elem))
            {
                _isBlocked = true;
                _rend.color = Color.red;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isBlocked = false;
        _rend.color = Color.green;
    }
}
