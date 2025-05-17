using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Main_Scripts;
using UnityEngine.Events;
using TMPro;

public class Blocks : MonoBehaviour
{
    [Header("기본 설정\n")]
    [SerializeField] bool _wallBlock;
    [SerializeField] Color _particleColor;
    [SerializeField] float _particleLifeTimeee = 0.2f;

    [Header("미는게 가능 한 블록일때\n")]
    [SerializeField] bool _pushing;
    [SerializeField] LayerMask _cloggedType;
    [SerializeField] LayerMask _GoalinType;
    [SerializeField] int _blockNumber;

    [Header("미는게 제한이 있는 블록일때\n")]
    [SerializeField] bool _breakBlock;
    [SerializeField] int _breakCount;

    [Header("건드리지 마세요")]
    [SerializeField] GameObject _numberPrefabs;
    [SerializeField] GameObject _breakImage;
    [SerializeField] GameObject _particles;

    public static bool _goalSignal;

    public bool _wall { get; set; }
    public bool _pushingGa { get; set; }
    public string Type { get; set; }
    public int BlockNumber { get; set; }

    float _x, _y, _rayDistance = 100f;
    SpriteRenderer _spren;
    GameObject _playerGameObject;
    Vector2 _vec2Abs, _rotion, _vec2Clamp, _positionYea, _distance, YoungJumSix, _savePosition, _breakImageMove;
    bool _interationPossible, _break;
    bool _minCoolTime = true, _bug = true;
    Blocks _goalSensor, _wallSensor;
    PlayerMovement _playerVector;
    bool _movein, _destory;
    int _saveNumber, _saveBreak;
    bool _signal;
    GameObject _childGo, _Parents, _image;

    GameObject _block;

    [SerializeField] TextMeshPro _count;

    GameManager _gm;

    Coroutine arrivalCoroutine;
    bool isCoroutineRunning = false;

    ParticleSystem particleSystem;

    private void Awake()
    {
        _block = gameObject;
        _goalSignal = false;

        if (_pushing)
        {
            _Parents = transform.parent.gameObject;
            _saveBreak = _breakCount;
            _childGo = _Parents.transform.GetChild(1).gameObject;
            _saveNumber = _blockNumber;
            _savePosition = transform.position;
            _playerGameObject = GameObject.Find("Player");
            _playerVector = _playerGameObject.GetComponent<PlayerMovement>();
            _spren = GetComponent<SpriteRenderer>();

            if (_breakBlock)
            {
                _count = Instantiate(_numberPrefabs, _Parents.transform).GetComponent<TextMeshPro>();
                _image = Instantiate(_breakImage, _Parents.transform);
            }
        }
    }

    IEnumerator WaitForGameManager()
    {
        while (GameManager.Instance == null)
        {
            yield return null;
        }

        _gm = GameManager.Instance;
        _gm.ManagerEvent.AddListener(ReStart);
    }

    void Start()
    {
        StartCoroutine(WaitForGameManager());
    }

    void ReStart()
    {
        if (_pushing)
        {
            Debug.Log("리셋");
            _breakCount = _saveBreak;
            _blockNumber = _saveNumber;
            transform.position = _savePosition;
            _spren.enabled = true;
            _wallBlock = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            _destory = false;

            if (arrivalCoroutine != null)
            {
                StopCoroutine(arrivalCoroutine);
                arrivalCoroutine = null;
            }

            isCoroutineRunning = false;
        }
    }

    public void PlayParticle()
    {
        if (_bug)
        {
            StartCoroutine(ParticleCoolDown());
            _particleColor.a = 255;
            particleSystem = Instantiate(_particles).GetComponent<ParticleSystem>();
            particleSystem.startColor = _particleColor;
            particleSystem.transform.position = _block.transform.position;
        }
    }

    IEnumerator ParticleCoolDown()
    {
        _bug = false;
        yield return new WaitForSeconds(0.05f);
        _bug = true;
    }

    void TextMoveMSD()
    {
        if (_breakBlock)
        {
            _count.rectTransform.position = Vector3.Lerp(_count.rectTransform.position, transform.position, Time.deltaTime * 5);
            _count.text = _breakCount.ToString();

            if (_breakCount <= 0)
            {
                _spren.enabled = false;
                _wallBlock = false;
                transform.position = new Vector3(transform.position.x, 300, -200);
                _goalSignal = true;
                _destory = true;
            }
        }
    }

    void BIM()
    {
        if (_breakBlock)
        {
            _breakImageMove = new Vector3(_image.transform.position.x, _image.transform.position.y);
            _image.transform.position = Vector3.Lerp(_breakImageMove, transform.position, Time.deltaTime * 5);
        }
    }

    private void Update()
    {
        BIM();
        TextMoveMSD();
        BlockNumber = _blockNumber;
        Goalin();
        _signal = _goalSignal;

        _wall = _wallBlock;
        _pushingGa = _pushing;

        if (_pushing)
        {
            _vec2Abs = _playerGameObject.transform.position - transform.position;
            _x = Mathf.Abs(_vec2Abs.x);
            _y = Mathf.Abs(_vec2Abs.y);

            _interationPossible = (_x == 1 && _y <= 0) || (_y == 1 && _x <= 0);

            if (_interationPossible)
            {
                _distance = _playerGameObject.transform.position - transform.position;
                YoungJumSix = _distance;
                YoungJumSix.x = Mathf.Clamp(YoungJumSix.x, -0.6f, 0.6f);
                YoungJumSix.y = Mathf.Clamp(YoungJumSix.y, -0.6f, 0.6f);

                Vector2 origin = transform.position;
                RaycastHit2D hit = Physics2D.Raycast(origin - YoungJumSix, -_distance, _rayDistance, _cloggedType);
                Debug.DrawRay(origin - YoungJumSix, -_distance * _rayDistance, Color.red);
                if (hit && hit.collider.TryGetComponent(out Blocks _block))
                {
                    _movein = true;
                    _positionYea = hit.collider.transform.position;
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

        if (_interationPossible && _movein)
        {
            PlayParticle();
            transform.position = _positionYea + _vec2Abs;
            if (_minCoolTime)
            {
                StartCoroutine(CoolDown());
                _breakCount--;
            }
        }
    }

    public void KeyMove(int numder)
    {
        if (_pushing && _interationPossible && _movein && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if ((_playerVector.LeftKeySensor && numder == 0) ||
                (_playerVector.RightKeySensor && numder == 1) ||
                (_playerVector.UpKeySensor && numder == 3) ||
                (_playerVector.DownKeySensor && numder == 2))
            {
                PlayParticle();
                transform.position = _positionYea + _vec2Abs;
                if (_minCoolTime)
                {
                    StartCoroutine(CoolDown());
                    _breakCount--;
                }
            }
        }
    }

    IEnumerator CoolDown()
    {
        _minCoolTime = false;
        yield return new WaitForSeconds(0.05f);
        _minCoolTime = true;
    }

    void Goalin()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, _GoalinType);
        if (hit.collider != null && !isCoroutineRunning && !_destory)
        {
            arrivalCoroutine = StartCoroutine(ArrivalTrriger(hit.collider.gameObject));
        }
    }

    IEnumerator ArrivalTrriger(GameObject _go)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(0.5f);

        if (_pushing && !_destory)
        {
            _spren.enabled = false;
            _wallBlock = false;
            transform.position = new Vector3(transform.position.x, 300, -200);
            _go.GetComponent<Blocks>().PlayParticle();
            _goalSignal = true;
            _blockNumber = 67893;
            _destory = true;
        }

        isCoroutineRunning = false;
    }

    public void Wall()
    {
        _wallBlock = false;
    }

    public void WallTrue()
    {
        _wallBlock = true;
    }
}
