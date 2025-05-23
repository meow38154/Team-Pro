using System.Collections;
using Main_Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalIn : MonoBehaviour
{
    [SerializeField] int _goalNumber;
    [field: SerializeField] public bool _openClose { get; set; }

    [SerializeField] bool _isVertical;
    [SerializeField] Sprite _vDoorO;
    [SerializeField] Sprite _vDoorC;
    [SerializeField] Sprite _hDoorO;
    [SerializeField] Sprite _hDoorC;

    private Blocks _blocks;
    private SpriteRenderer _render;
    private GameManager _gm;

    private bool _one;
    private float _noBlockTimer = 0f;
    private const float OpenDelay = 1f; // 1초

    bool _oneSound;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _blocks = GetComponent<Blocks>();
        _blocks.WallTrue();
    }

    private void Update()
    {
        SpriteUpdate();

        if (Blocks._goalSignal)
        {
            GamSec();
        }
    }

    void SpriteUpdate()
    {
        if (_openClose && !_isVertical)
        {
            _render.sprite = _vDoorO;
        }
        else if (!_openClose && !_isVertical)
        {
            _render.sprite = _vDoorC;
        }
        else if (_openClose && _isVertical)
        {
            _render.sprite = _hDoorO;
        }
        else if (!_openClose && _isVertical)
        {
            _render.sprite = _hDoorC;
        }
    }

    void GamSec()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        bool goalBlockExists = false;

        foreach (GameObject obj in blocks)
        {
            if (obj == this.gameObject) continue;

            Blocks block = obj.GetComponent<Blocks>();
            if (block != null && block.BlockNumber == _goalNumber)
            {
                goalBlockExists = true;
                break;
            }
        }

        if (goalBlockExists)
        {
            // 블록이 다시 생겼으면 타이머 초기화하고 닫음
            _noBlockTimer = 0f;
            _blocks.WallTrue();
            _openClose = false;
            _one = false; // 다시 효과를 재생할 수 있게
            _oneSound = true;
        }
        else
        {
            // 블록이 없을 경우 타이머 시작
            _noBlockTimer += Time.deltaTime;

            if (_noBlockTimer >= OpenDelay)
            {
                if (!_one)
                {
                    _blocks.PlayParticle();
                    _one = true;
                }

                _openClose = true;
                _blocks.Wall(); // 벽 해제
                if (_oneSound)
                {
                    AudioManager.Instance.PlayOpenDoor();
                    _oneSound = false;
                }
            }
        }
    }
}
