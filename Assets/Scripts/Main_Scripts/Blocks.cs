using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Main_Scripts;
using UnityEngine.Serialization;

public class Blocks : MonoBehaviour
{
    [FormerlySerializedAs("_pushing")] [SerializeField] private bool pushing;
    [FormerlySerializedAs("_wallBlock")] [SerializeField] private bool wallBlock;
    [FormerlySerializedAs("_cloggedType")] [SerializeField] private LayerMask cloggedType;
    [FormerlySerializedAs("_GoalinType")] [SerializeField] private LayerMask goalinType;
    [FormerlySerializedAs("_blockNumber")] [SerializeField] private int blockNumber;
    
    public static bool GoalSignal;


    public bool _wall { get; set; }
    public bool PushingGa { get; set; }
    public string Type { get; set; }
    public int BlockNumber { get; set; }

    private float _x, _y;
    readonly float _rayDistance = 100f;
    public SpriteRenderer Spren { get; private set; }
    Vector2 _vec2Abs, _rotion, _vec2Clamp, _positionYea, _distance, _youngJumSix, _savePosition;
    bool _interationPossible, _break;
    Blocks _goalSensor, _wallSensor;
    PlayerMovement _playerVector;
    bool _movein, _destory;
    int _saveNumber;
    bool _signal;
    GameObject _childGo, _Parents;
    ImageMove _imageMove;

    public Blocks(float y)
    {
        _y = y;
    }


    private void Awake()
    {
        if (pushing)
        {
            _Parents = transform.parent.gameObject;

            _childGo = _Parents.transform.GetChild(1).gameObject;

            _imageMove = _childGo.GetComponent<ImageMove>();
        }

        _saveNumber = blockNumber;
        _savePosition = transform.position;
        _playerVector = GameManager.Instance.player;
        Spren = GetComponent<SpriteRenderer>();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void ReStart()
    {
        if (pushing)
        {
            _imageMove.Enable();
            blockNumber = _saveNumber;
            transform.position = _savePosition;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Blocks>().pushing = true;
            gameObject.GetComponent<Blocks>().wallBlock = true;

            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            _destory = false;
            StopCoroutine(ArrivalTrriger());
        }
    }





    private void Update()
    {
        BlockNumber = blockNumber;

        Goalin();

        _signal = GoalSignal;

        //�ӽ� ���� �ڵ�
        if (Keyboard.current.rKey.wasPressedThisFrame && Keyboard.current.fKey.isPressed)
        {
            ReStart();
        }



        {
            _wall = wallBlock;

            PushingGa = pushing;
        }

        if (pushing)
        {
            {
                _vec2Abs = GameManager.Instance.trm.position - transform.position;

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
                    _distance = GameManager.Instance.trm.position - transform.position;

                _youngJumSix = _distance;

                _youngJumSix.x = Mathf.Clamp(_youngJumSix.x, -0.6f, 0.6f);
                _youngJumSix.y = Mathf.Clamp(_youngJumSix.y, -0.6f, 0.6f);

                Vector2 origin = (Vector2)transform.position;

                RaycastHit2D hit = Physics2D.Raycast(origin - _youngJumSix, -_distance, _rayDistance, cloggedType);
                Debug.DrawRay(origin - _youngJumSix, -_distance * _rayDistance, Color.red);
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
            transform.position = _positionYea + _vec2Abs;
        }
    }
    public void KeyMove()
    {
        if (pushing == true)
        {
            if (_interationPossible == true && _movein == true && Keyboard.current.spaceKey.wasPressedThisFrame && 
                (_playerVector.LeftKeySensor == true || _playerVector.RightKeySensor == true || 
                _playerVector.UpKeySensor == true || _playerVector.DownKeySensor == true)){
                transform.position = _positionYea + _vec2Abs;
            }
        }
    }
    void Goalin()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, goalinType);
        if (hit.collider != null)
        {
            StartCoroutine(ArrivalTrriger());
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator ArrivalTrriger()
    {
        if (pushing && _destory == false)
        {
            yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<Blocks>().wallBlock = false;
        transform.position = new Vector3(0, 0, 200);
        _imageMove.Disable();

        GoalSignal = true;
        blockNumber = 67893;
            _destory = true;
        }
    }

    public void Wall()
    {
        wallBlock = false;
    }

    public void WallTrue()
    {
        wallBlock = true;
    }
}
