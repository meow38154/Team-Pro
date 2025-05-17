using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] float _moveCoolTIme = 0.3f;

    Vector3 _mousePos;
    public Vector2 Vec2Move { get; set; }
    bool _leftMoveWhather, _rightMoveWhather, _downMoveWhather, _upMoveWhather, _movePossbie = true;
    float _rich = 0.7f;

    public bool LeftKeySensor { get; set; }
    public bool RightKeySensor { get; set; }
    public bool UpKeySensor { get; set; }
    public bool DownKeySensor { get; set; }

    [SerializeField] Blocks[] _blocks = new Blocks[4];

    GameObject _childGameObject;

    private void Awake()
    {
        _childGameObject = transform.GetChild(0).gameObject;
    }

    public void OnMove(InputValue value)
    {
        Vec2Move = value.Get<Vector2>();
    }

    void Upmove()
    {
        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(0, 0.6f, 0), Vector2.up, _rich);
        Debug.DrawRay(transform.position + new Vector3(0, 0.6f, 0), Vector2.up * _rich, Color.green);

        if (move.collider != null)
        {
            Blocks blockSensor = move.collider.GetComponent<Blocks>();

            _blocks[3] = move.collider.GetComponent<Blocks>();
            if (blockSensor != null && blockSensor._wall == true)
            {
                _upMoveWhather = false;
            }
            else
            {
                _upMoveWhather = true;
            }
        }
        else
        {
            _upMoveWhather = true;
        }
    }
    void Downmove()
    {
        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(0, -0.6f, 0), Vector2.down, _rich);
        Debug.DrawRay(transform.position + new Vector3(0, -0.6f, 0), Vector2.down * _rich, Color.green);

        if (move.collider != null)
        {
            Blocks blockSensor = move.collider.GetComponent<Blocks>();
            _blocks[2] = move.collider.GetComponent<Blocks>();
            if (blockSensor != null && blockSensor._wall == true)
            {
                _downMoveWhather = false;
            }
            else
            {
                _downMoveWhather = true;
            }
        }
        else
        {
            _downMoveWhather = true;
        }
    }
    void Leftmove()
    {
        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(-0.6f, 0, 0), Vector2.left, _rich);
        Debug.DrawRay(transform.position + new Vector3(-0.6f, 0, 0), Vector2.left * _rich, Color.green);

        if (move.collider != null)
        {
            Blocks blockSensor = move.collider.GetComponent<Blocks>();
            _blocks[0] = move.collider.GetComponent<Blocks>();
            if (blockSensor != null && blockSensor._wall == true)
            {
                _leftMoveWhather = false;
            }
            else
            {
                _leftMoveWhather = true;
            }
        }
        else
        {
            _leftMoveWhather = true;
        }
    }
    void Rightmove()
    {

        RaycastHit2D move = Physics2D.Raycast(transform.position + new Vector3(0.6f, 0, 0), Vector2.right, _rich);
        Debug.DrawRay(transform.position + new Vector3(0.6f, 0, 0), Vector2.right * _rich, Color.green);

        if (move.collider != null)
        {
            Blocks blockSensor = move.collider.GetComponent<Blocks>();
            _blocks[1] = move.collider.GetComponent<Blocks>();
            if (blockSensor != null && blockSensor._wall == true)
            {
                _rightMoveWhather = false;
            }
            else
            {
                _rightMoveWhather = true;
            }
        }
        else
        {
            _rightMoveWhather = true;
        }
    }

    void Update()
    {

        Upmove();
        Downmove();
        Leftmove();
        Rightmove();

        {
            for(int i = 0;i < 4; i++)
            {
                if (_blocks[i] != null)
                {
                    _blocks[i].KeyMove(i);
                }
            }

        }

        {
            LeftKeySensor = (Vec2Move.x < 0);
            RightKeySensor = (Vec2Move.x > 0);
            UpKeySensor = (Vec2Move.y > 0);
            DownKeySensor = (Vec2Move.y < 0);
        }
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;

        if ((Mouse.current.leftButton.wasPressedThisFrame &&
            _mousePos.x >= transform.position.x - 1.5 && _mousePos.x <= transform.position.x - 0.5 &&
                _mousePos.y >= transform.position.y - 0.5 && _mousePos.y <= transform.position.y + 0.5) ||
                (Vec2Move.x < 0 && _movePossbie == true) && _leftMoveWhather == true)
        {
               _childGameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (_leftMoveWhather == true)
            {
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(-1, 0, 0);
            } 
        }

        if ((Mouse.current.leftButton.wasPressedThisFrame &&
            (_mousePos.x <= transform.position.x + 1.5 && _mousePos.x >= transform.position.x + 0.5 &&
                _mousePos.y >= transform.position.y - 0.5 && _mousePos.y <= transform.position.y + 0.5)) ||
                (Vec2Move.x > 0 && _movePossbie == true) && _rightMoveWhather == true)
        {
                _childGameObject.GetComponent<SpriteRenderer>().flipX = true;
            if (_rightMoveWhather == true)
            {
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(1, 0, 0);
            }
        }

        if ((Mouse.current.leftButton.wasPressedThisFrame &&
            _mousePos.y >= transform.position.y - 1.5 && _mousePos.y <= transform.position.y - 0.5 &&
                _mousePos.x >= transform.position.x - 0.5 && _mousePos.x <= transform.position.x + 0.5) ||
                (Vec2Move.y < 0 && _movePossbie == true) && _downMoveWhather == true)
        {
            if (_downMoveWhather == true)
            {
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(0, -1, 0);
            }
        }

        if ((Mouse.current.leftButton.wasPressedThisFrame &&
            (_mousePos.y <= transform.position.y + 1.5 && _mousePos.y >= transform.position.y + 0.5 &&
                _mousePos.x >= transform.position.x - 0.5 && _mousePos.x <= transform.position.x + 0.5)) ||
                (Vec2Move.y > 0 && _movePossbie == true) && _upMoveWhather == true)
        {
            if (_upMoveWhather == true)
            {
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(0, 1, 0);
            }
        }
    }

    

    IEnumerator MoveCoolTime()
    {
        _movePossbie = false;

        _movePossbie = false;

        
        yield return new WaitForSeconds(_moveCoolTIme);
        _movePossbie = true;

    }
}