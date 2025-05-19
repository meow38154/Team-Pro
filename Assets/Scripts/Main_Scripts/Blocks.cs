using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Main_Scripts;
using UnityEngine.Events;
using TMPro;
using NUnit.Framework.Constraints;

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
    [field: SerializeField] public int _blockNumber { get; set; }

    [Header("미는게 제한이 있는 블록일때\n")]
    [SerializeField] bool _breakBlock;
    [SerializeField] int _breakCount;
    [SerializeField] float _daldal = 0.25f;

    [Header("건드리지 마세요")]
    [SerializeField] GameObject _numberPrefabs;
    [SerializeField] GameObject _breakImage;
    [SerializeField] GameObject _particles;
    [SerializeField] GameObject _hapGoldGameObject;
    [SerializeField] LayerMask _hapGoldtell;

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
    PlayerScript _playerVector;
    bool _movein, _destory;
    int _saveNumber, _saveBreak;
    bool _signal, _hapGoldTF;
    GameObject _childGo, _Parents, _image;

    GameObject _block;

    [SerializeField] TextMeshPro _count;

    GameManager _gm;

    Coroutine arrivalCoroutine;
    bool isCoroutineRunning = false;

    bool _one, _savePushing;

    bool _one2 = true;

    ParticleSystem particleSystem;

    private void Awake()
    {
        _savePushing = _pushing;

        _block = gameObject;
        _goalSignal = false;

            _savePosition = transform.position;
            _saveNumber = _blockNumber;
        if (_savePushing)
        {
            _Parents = transform.parent.gameObject;
            _saveBreak = _breakCount;
            _childGo = _Parents.transform.GetChild(1).gameObject;
            _playerGameObject = GameObject.Find("Player");
            _playerVector = _playerGameObject.GetComponent<PlayerScript>();
            _spren = GetComponent<SpriteRenderer>();

            if (_breakBlock)
            {
                _count = Instantiate(_numberPrefabs, _Parents.transform).GetComponent<TextMeshPro>();
                _image = Instantiate(_breakImage, _childGo.transform);
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
        if (gameObject.layer == 20)
        {
            transform.position = _savePosition;
        }

        if (gameObject.layer == 12)
        {
            Destroy(_Parents.gameObject);
        }
            if (gameObject.layer == 19)
            {
                Debug.Log("실행됨" + _savePosition + " " + _saveNumber);
                transform.position = _savePosition;
                _blockNumber = _saveNumber;
            }

        if (_savePushing)
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
            if (this.gameObject.layer == 12)
            {
                Debug.Log("합금 파티클");
            }

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
            _count.rectTransform.position = new Vector3(_count.rectTransform.position.x, _count.rectTransform.position.y, -5f);
            _count.text = (_breakCount - 1).ToString();

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
        //if (_breakBlock)
        //{
        //    _breakImageMove = new Vector3(_image.transform.position.x, _image.transform.position.y);
        //    _image.transform.position = Vector3.Lerp(_breakImageMove, transform.position, Time.deltaTime * 5);
        //}
    }

    private void Update()
    {
        HabGold();
        BIM();
        TextMoveMSD();
        BlockNumber = _blockNumber;
        MiniRaycast();
        _signal = _goalSignal;

        _wall = _wallBlock;
        _pushingGa = _pushing;



        if (_savePushing)
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

    IEnumerator DalDal()
    {
        _childGo.transform.position += new Vector3(_daldal, 0, 0);
        yield return new WaitForSeconds(0.05f);
        _childGo.transform.position += new Vector3(-_daldal, 0, 0);
        yield return new WaitForSeconds(0.05f);
        _childGo.transform.position += new Vector3(_daldal/2, 0, 0);
        yield return new WaitForSeconds(0.05f);
        _childGo.transform.position += new Vector3(-_daldal/2, 0, 0);
        yield return new WaitForSeconds(0.05f);
        _childGo.transform.position += new Vector3(_daldal/3, 0, 0);
        yield return new WaitForSeconds(0.05f);
        _childGo.transform.position += new Vector3(-_daldal/3, 0, 0);
        yield return new WaitForSeconds(0.05f);
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
            if (_breakCount > 0)
            {
                StartCoroutine(DalDal());
            }

            Vector2 noMove = _positionYea + _vec2Abs;

            if (transform.position.x == noMove.x && transform.position.y == noMove.y)
            {
                StartCoroutine(DalDal());
            }
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
        if (_savePushing && _interationPossible && _movein && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if ((_playerVector.LeftKeySensor && numder == 0) ||
                (_playerVector.RightKeySensor && numder == 1) ||
                (_playerVector.UpKeySensor && numder == 3) ||
                (_playerVector.DownKeySensor && numder == 2))
            {
                PlayParticle();
                if (_breakCount > 0)
                {
                    StartCoroutine(DalDal());
                }

                Vector2 noMove = _positionYea + _vec2Abs;

                if (transform.position.x == noMove.x && transform.position.y == noMove.y)
                {
                    Debug.Log(noMove);
                    StartCoroutine(DalDal());
                }

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

    void MiniRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, _GoalinType);
        if (hit.collider != null && !isCoroutineRunning && !_destory)
        {
            Debug.Log(hit.collider.gameObject.name + ", " + gameObject.name);

            arrivalCoroutine = StartCoroutine(ArrivalTrriger(hit.collider.gameObject));
        }
    }

    IEnumerator ArrivalTrriger(GameObject _go)
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(0.5f);

        if (_savePushing && !_destory)
        {
            RemoveBlock(this.gameObject);
            _go.GetComponent<Blocks>().PlayParticle();

        }

        Debug.Log("제거 대상:" + _go.name);

        if (_go.gameObject.layer == 19)
            {
                Debug.Log("레이어 19");
                RemoveBlock(_go);
            }

        isCoroutineRunning = false;
    }

    public void RemoveBlock(GameObject _go)
    {
        _go.GetComponent<Blocks>()._pushing = false;
        if (_go.gameObject.layer != 19)
        {
            _go.GetComponent<Blocks>()._childGo.GetComponent<SpriteRenderer>().color = Color.white;
            _go.GetComponent<Blocks>()._spren.enabled = false;
            _go.GetComponent<Blocks>()._wallBlock = false;
        }
            GetComponent<Blocks>().PlayParticle();
            _goalSignal = true;
        _go.GetComponent<Blocks>()._blockNumber = 67893;
        _go.GetComponent<Blocks>()._destory = true;
            _go.transform.position += new Vector3(0, 300,0);
        _one2 = true;

        if (_go.layer == 22)
        {
            _go.layer = 10;
        }
        if (_go.layer == 21)
        {
            _go.layer = 9;
        }
    }


    GameObject _hit;

    public void HabGold()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.up, 0.1f, _hapGoldtell);
        if (hit.collider != null)
        {
            _hit = hit.collider.gameObject;

            if (gameObject.layer == 9)
            {
                this.gameObject.layer = 21;
                _pushing = false;
                StartCoroutine(HapGoldCoolTime());
            }

            if (gameObject.layer == 10)
            {
                this.gameObject.layer = 22;
                _pushing = false;
                StartCoroutine(HapGoldCoolTime());
            }
        }


        if (_one)
        {
            Debug.Log("왜안돼");
            StartCoroutine(BugSuJeongCoolTime());
            _one = false;
        }
    }
    IEnumerator HapGoldCoolTime()
    {
        _hapGoldTF = true;
        Debug.Log("코루틴 실행");
        yield return new WaitForSeconds(1.15f);
        Debug.Log("0.5초 지남");
        _childGo.GetComponent<SpriteRenderer>().color = Color.gray;
        _wallBlock = false;
    }

    IEnumerator HapGoldPlay(GameObject _twotwo)
    {
        _one2 = false;
        yield return new WaitForSeconds(1.15f);
        PlayParticle();

        GameObject HG = Instantiate(_hapGoldGameObject);
        GameObject HGChild = HG.transform.GetChild(0).gameObject;

        HG.transform.position = transform.position;
        HGChild.GetComponentInChildren<Blocks>()._blockNumber = GetComponent<Blocks>()._blockNumber;
        Debug.Log("바꼈는데");
        RemoveBlock(_twotwo);
        RemoveBlock(this.gameObject);
        _one = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((gameObject.layer == 21 && collision.gameObject.layer == 22) && _one2)
        {
            Debug.Log("트리커 닿음: " + _Parents.name + "나는 " + collision.gameObject.GetComponent<Blocks>()._Parents.name);
            StartCoroutine(HapGoldPlay(collision.gameObject));
        }
    }

    IEnumerator BugSuJeongCoolTime()
    {
        yield return new WaitForSeconds(0.05f);
            _hit.transform.position = new Vector3(transform.position.x, 300, transform.position.x);

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
