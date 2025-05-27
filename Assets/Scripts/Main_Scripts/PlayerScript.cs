using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float _moveCoolTIme = 0.3f;
    [SerializeField] ParticleSystem _particle;
    [SerializeField] int particleRate;


    Vector3 _mousePos;
    public Vector2 Vec2Move { get; set; }
    [SerializeField] bool _leftMoveWhather, _rightMoveWhather, _downMoveWhather, _upMoveWhather, _movePossbie = true;
    float _rich = 0.7f;

    [field: SerializeField] public bool LeftKeySensor { get; set; }
    [field: SerializeField] public bool RightKeySensor { get; set; }
    [field: SerializeField] public bool UpKeySensor { get; set; }
    [field: SerializeField] public bool DownKeySensor { get; set; }

    [SerializeField] Blocks[] _blocks = new Blocks[4];

    GameObject _childGameObject;

    bool ct;

    private void Awake()
    {
        _childGameObject = GameObject.Find("PlayerVIsual");
    }

    public void OnMove(InputValue value)
    {
        Vec2Move = value.Get<Vector2>();
    }

    void Upmove()
    {
        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(0, 0.6f, 0), Vector2.up, _rich);
        _blocks[3] = move.collider?.GetComponent<Blocks>();
        _upMoveWhather = move.collider == null || (_blocks[3] != null && !_blocks[3]._wall);
    }

    void Downmove()
    {
        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(0, -0.6f, 0), Vector2.down, _rich);
        _blocks[2] = move.collider?.GetComponent<Blocks>();
        _downMoveWhather = move.collider == null || (_blocks[2] != null && !_blocks[2]._wall);
    }

    void Leftmove()
    {
        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0, 0), Vector2.left, _rich);
        _blocks[0] = move.collider?.GetComponent<Blocks>();
        _leftMoveWhather = move.collider == null || (_blocks[0] != null && !_blocks[0]._wall);
    }

    void Rightmove()
    {
        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(0.6f, 0, 0), Vector2.right, _rich);
        _blocks[1] = move.collider?.GetComponent<Blocks>();
        _rightMoveWhather = move.collider == null || (_blocks[1] != null && !_blocks[1]._wall);
    }

    void Update()
    {
        ct = Keyboard.current.leftCtrlKey.isPressed;

        Upmove();
        Downmove();
        Leftmove();
        Rightmove();

        for (int i = 0; i < 4; i++)
        {
            _blocks[i]?.KeyMove(i);
        }

        LeftKeySensor = (Vec2Move.x < 0);
        RightKeySensor = (Vec2Move.x > 0);
        UpKeySensor = (Vec2Move.y > 0);
        DownKeySensor = (Vec2Move.y < 0);

        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;

        if (Vec2Move.x < 0)
            _childGameObject.GetComponent<SpriteRenderer>().flipX = false;
        else if (Vec2Move.x > 0)
            _childGameObject.GetComponent<SpriteRenderer>().flipX = true;

        if (ct == false && Time.timeScale != 0 && _movePossbie)
        {
            bool moved = false;

            // 키보드 우선 처리
            if (Vec2Move.x < 0 && _leftMoveWhather)
            {
                Move(Vector3.left);
                moved = true;
            }
            else if (Vec2Move.x > 0 && _rightMoveWhather)
            {
                Move(Vector3.right);
                moved = true;
            }
            else if (Vec2Move.y < 0 && _downMoveWhather)
            {
                Move(Vector3.down);
                moved = true;
            }
            else if (Vec2Move.y > 0 && _upMoveWhather)
            {
                Move(Vector3.up);
                moved = true;
            }

            // 키보드로 이동하지 않은 경우에만 마우스 처리
            if (!moved && Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (_mousePos.x >= transform.position.x - 1.5f && _mousePos.x <= transform.position.x - 0.5f &&
                    _mousePos.y >= transform.position.y - 0.5f && _mousePos.y <= transform.position.y + 0.5f &&
                    _leftMoveWhather)
                {
                    Move(Vector3.left);
                }
                else if (_mousePos.x <= transform.position.x + 1.5f && _mousePos.x >= transform.position.x + 0.5f &&
                         _mousePos.y >= transform.position.y - 0.5f && _mousePos.y <= transform.position.y + 0.5f &&
                         _rightMoveWhather)
                {
                    Move(Vector3.right);
                }
                else if (_mousePos.y >= transform.position.y - 1.5f && _mousePos.y <= transform.position.y - 0.5f &&
                         _mousePos.x >= transform.position.x - 0.5f && _mousePos.x <= transform.position.x + 0.5f &&
                         _downMoveWhather)
                {
                    Move(Vector3.down);
                }
                else if (_mousePos.y <= transform.position.y + 1.5f && _mousePos.y >= transform.position.y + 0.5f &&
                         _mousePos.x >= transform.position.x - 0.5f && _mousePos.x <= transform.position.x + 0.5f &&
                         _upMoveWhather)
                {
                    Move(Vector3.up);
                }
            }
        }
    }

    void Move(Vector3 direction)
    {
        StartCoroutine(MoveCoolTime());
        transform.position += direction;
        PlayMoveAnimation();
        AudioManager.Instance.PlayStep();
    }

    void PlayMoveAnimation()
    {
        GameObject particle = Instantiate(_particle).gameObject;
        particle.transform.position = transform.position;

        var child = transform.GetChild(0).gameObject;
        child.transform.localScale = new Vector3(2, 0.5f, 0);
        StartCoroutine(Anim(child));
    }

    IEnumerator Anim(GameObject child)
    {
        for (int i = 0; i < 5; i++)
        {
            child.transform.localScale += new Vector3(-0.2f, 0.1f, 0);
            yield return new WaitForSeconds(0.025f);
        }
        child.transform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator MoveCoolTime()
    {
        _movePossbie = false;
        yield return new WaitForSeconds(_moveCoolTIme);
        _movePossbie = true;
    }
}
