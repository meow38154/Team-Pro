using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Blocks : MonoBehaviour
{
    [SerializeField] bool _pushing;
    [SerializeField] bool _wallBlock;
    [SerializeField] LayerMask _cloggedType;
    [SerializeField] LayerMask _GoalinType;
    


    public bool _wall { get; set; }
    public bool _pushingGa { get; set; }
    public string Type { get; set; }

    float _x, _y, _rayDistance = 100f;
    SpriteRenderer _spren;
    GameObject _playerGameObject;
    Vector2 _vec2Abs, _rotion, _vec2Clamp, _positionYea, _distance, YoungJumSix, _savePosition;
    bool _interationPossible, _break;
    Blocks _goalSensor, _wallSensor;
    PlayerMovement _playerVector;
    bool _movein;



    private void Awake()
    {
        _savePosition = transform.position;
        _playerGameObject = GameObject.Find("Player");
        _playerVector = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _spren = GetComponent<SpriteRenderer>();
    }

    void ReStart()
    {
        transform.position = _savePosition;
    }





    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame && Keyboard.current.fKey.isPressed)
        {
            ReStart();
        }



        {
            if (_wallBlock == true)
            {
                _wall = true;
            }

            if (_wallBlock == false)
            {
                _wall = false;
            }

            if (_pushing == true)
            {
                _pushingGa = true;
            }

            if (_pushing == false)
            {
                _pushingGa = false;
            }
        }

        if (_pushing)
        {
            {
                _vec2Abs = _playerGameObject.transform.position - transform.position;

                _x = Mathf.Abs(_vec2Abs.x);
                _y = Mathf.Abs(_vec2Abs.y);

                if ((_x == 1 && _y <= 0) || (_y == 1 && _x <= 0))
                {
                    _interationPossible = true;
                }

                else
                {
                    _interationPossible = false;
                }
            }

            {
                //if (_interationPossible == true)
                //{
                //    _spren.color = Color.yellow;
                //}

                //if (_interationPossible == false)
                //{
                //    _spren.color = Color.white;
                //}
            }

            {
                _distance = _playerGameObject.transform.position - transform.position;

                YoungJumSix = _distance;

                YoungJumSix.x = Mathf.Clamp(YoungJumSix.x, -0.6f, 0.6f);
                YoungJumSix.y = Mathf.Clamp(YoungJumSix.y, -0.6f, 0.6f);

                Vector2 origin = (Vector2)transform.position;

                RaycastHit2D hit = Physics2D.Raycast(origin - YoungJumSix, -_distance, _rayDistance, _cloggedType);
                Debug.DrawRay(origin - YoungJumSix, -_distance * _rayDistance, Color.red);
                if (hit)
                {
                    if (hit.collider.TryGetComponent(out Blocks _block))
                    {
                        _movein = true;
                        _positionYea = hit.collider.gameObject.transform.position;
                    }
                }
                else
                {
                    _movein = false;
                }
            }
        }
    }
    private void OnMouseDown()
    {
        Move();
    }
    public void Move()
    {
        _vec2Clamp.x = Mathf.Clamp(_vec2Abs.x, -1, 1);
        _vec2Clamp.y = Mathf.Clamp(_vec2Abs.y, -1, 1);

        if (_interationPossible == true && _movein == true)
        {
            transform.position = _positionYea + _vec2Abs;
        }
    }
    public void KeyMove()
    {
        if (_pushing == true)
        {
            if (_interationPossible == true && _movein == true &&
            ((_playerVector.LeftKeySensor == true && Keyboard.current.spaceKey.wasPressedThisFrame) ||
            (_playerVector.RightKeySensor == true && Keyboard.current.spaceKey.wasPressedThisFrame) ||
            (_playerVector.UpKeySensor == true && Keyboard.current.spaceKey.wasPressedThisFrame) ||
            (_playerVector.DownKeySensor == true && Keyboard.current.spaceKey.wasPressedThisFrame)))
            {
                transform.position = _positionYea + _vec2Abs;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (Physics2D.OverlapBox(transform.position, Vector2.one, 0f, _GoalinType))
        {
            StartCoroutine(ArrivalTrriger(collider.gameObject));
        }
    }

    IEnumerator ArrivalTrriger(GameObject _go)
    {
        yield return new WaitForSeconds(0.5f);
        _go.gameObject.SetActive(false);
    }
}
