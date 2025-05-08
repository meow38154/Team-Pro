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
    [SerializeField] int _blockNumber;
    
    public static bool _goalSignal;


    public bool _wall { get; set; }
    public bool _pushingGa { get; set; }
    public string Type { get; set; }
    public int BlockNumber { get; set; }

    float _x, _y, _rayDistance = 100f;
    SpriteRenderer _spren;
    GameObject _playerGameObject;
    Vector2 _vec2Abs, _rotion, _vec2Clamp, _positionYea, _distance, YoungJumSix, _savePosition;
    bool _interationPossible, _break;
    Blocks _goalSensor, _wallSensor;
    PlayerMovement _playerVector;
    bool _movein;
    public bool _destroy;
    int _saveNumber;
    GameObject _childGo, _Parents;
    ImageMove _imageMove;
    Vector3 oldPos;
    bool DestroyMiss = false;

    private void Awake()
    {
        if (_pushing)
        {
            _Parents = transform.parent.gameObject;

            _childGo = _Parents.transform.GetChild(1).gameObject;

            _imageMove = _childGo.GetComponent<ImageMove>();
        }

        _saveNumber = _blockNumber;
        _savePosition = transform.position;
<<<<<<< HEAD
        _playerVector = GameManager.Instance.player;
        Spren = GetComponent<SpriteRenderer>();
=======
        _playerGameObject = GameObject.Find("Player");
        _playerVector = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _spren = GetComponent<SpriteRenderer>();
>>>>>>> parent of 4ef4e39 (Fixed: code)
    }

    void ReStart()
    {
        if (_pushing)
        {
            _blockNumber = _saveNumber;
            transform.position = _savePosition;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Blocks>()._pushing = true;
            gameObject.GetComponent<Blocks>()._wallBlock = true;

            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            _destroy = false;
            StopCoroutine(ArrivalTrriger());
        }
    }





    private void Update()
    {
        BlockNumber = _blockNumber;

        Goalin();


        //임시 리셋 코드
        if (Keyboard.current.rKey.wasPressedThisFrame && Keyboard.current.fKey.isPressed)
        {
            ReStart();
        }



        {
            _wall = _wallBlock;

            _pushingGa = _pushing;
        }

        if (_pushing)
        {
            {
<<<<<<< HEAD
                _vec2Abs = GameManager.Instance.trm.position - transform.position;
=======
                _vec2Abs = _playerGameObject.transform.position - transform.position;
>>>>>>> parent of 4ef4e39 (Fixed: code)

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
                if (_interationPossible == true)
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
            oldPos = transform.position;
            transform.position = _positionYea + _vec2Abs;
            
        }
    }
    public void KeyMove()
    {
        if (_pushing == true)
        {
            if (_interationPossible == true && _movein == true && Keyboard.current.spaceKey.wasPressedThisFrame && 
                (_playerVector.LeftKeySensor == true || _playerVector.RightKeySensor == true || 
                _playerVector.UpKeySensor == true || _playerVector.DownKeySensor == true)){
                transform.position = _positionYea + _vec2Abs;
                oldPos = transform.position;
            }
        }
    }
    void Goalin()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, _GoalinType);
        if (hit.collider != null && !_destroy && _pushing && !DestroyMiss)
        {
            StartCoroutine(ArrivalTrriger());
        }
    }

    IEnumerator ArrivalTrriger()
    {
        Debug.Log("21313");
        _destroy = true;
        yield return new WaitForSeconds(0.5f);
        if(!DestroyMiss)
        {
            _wallBlock = false;
            _pushing = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, -200);
        }
    }

    public void UnDestroy()
    {
        StartCoroutine(DestroyMissTime());
        _destroy = false;
        _wallBlock = true;
        _pushing = true;
        
    }

    IEnumerator DestroyMissTime()
    {
        DestroyMiss = true;
        yield return new WaitForSeconds(0.5f);
        DestroyMiss = false;
    }
}
