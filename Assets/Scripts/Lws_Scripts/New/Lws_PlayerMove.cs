using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.UI.Image;
using System.Collections;
using System;

public class Lws_PlayerMove : MonoBehaviour
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

    private void Awake()
    {

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

            _rightMoveWhather = !(blockSensor != null && blockSensor._wall == true);

            //if (blockSensor != null && blockSensor._wall == true)
            //{
            //    _rightMoveWhather = false;
            //}
            //else
            //{
            //    _rightMoveWhather = true;
            //}
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
                    _blocks[i].KeyMove();
                }
            }
            //if (_blocks[0] != null)
            //{
            //    _blocks[0].KeyMove();
            //}
            //if (_blocks[1] != null)
            //{
            //    _blocks[1].KeyMove();
            //}
            //if (_blocks[2] != null)
            //{
            //    _blocks[2].KeyMove();
            //}
            //if (_blocks[3] != null)
            //{
            //    _blocks[3].KeyMove();
            //}
        }


        #region KeySensor

        LeftKeySensor = (Vec2Move.x < 0);
        RightKeySensor = (Vec2Move.x > 0);
        UpKeySensor = (Vec2Move.y > 0);
        DownKeySensor = (Vec2Move.y < 0);

        #endregion


        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;

        PlayerMove();
    }
    private void PlayerMove()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)//마우스로 이동
        {
            float myPosX = transform.position.x;
            float myPosY = transform.position.y;
            if ((myPosX - 0.5 <= _mousePos.x && _mousePos.x <= myPosX + 0.5) && (myPosY - 0.5 <= _mousePos.y && _mousePos.y <= myPosY + 0.5)) Debug.Log("자신을 클릭함");
            else if (myPosX - 0.5 <= _mousePos.x && _mousePos.x <= myPosX + 0.5)
            {
                if (myPosY < _mousePos.y && _upMoveWhather)
                {
                    StartCoroutine(MoveCoolTime());
                    transform.position += new Vector3(0, 1, 0);
                }
                else if (_downMoveWhather)
                {
                    StartCoroutine(MoveCoolTime());
                    transform.position += new Vector3(0, -1, 0);
                }
            }
            else if (myPosY - 0.5 <= _mousePos.y && _mousePos.y <= myPosY + 0.5)
            {
                if (myPosX < _mousePos.x && _rightMoveWhather)
                {
                    StartCoroutine(MoveCoolTime());
                    transform.position += new Vector3(1, 0, 0);
                }
                else if (_leftMoveWhather)
                {
                    StartCoroutine(MoveCoolTime());
                    transform.position += new Vector3(-1, 0, 0);
                }
            }
        }
        else if (_movePossbie)//키보드로 이동
        {
            if (RightKeySensor && _rightMoveWhather)
            {
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(1, 0, 0); 
            }
            else if (LeftKeySensor && _leftMoveWhather) 
            { 
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(-1, 0, 0); 
            }
            else if (UpKeySensor && _upMoveWhather) 
            {
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(0, 1, 0); 
            }
            else if (DownKeySensor && _downMoveWhather) 
            {
                StartCoroutine(MoveCoolTime());
                transform.position += new Vector3(0, -1, 0);
            }
        }
    }
    IEnumerator MoveCoolTime()
    {
        _movePossbie = false;
        yield return new WaitForSeconds(_moveCoolTIme);
        _movePossbie = true;
    }
}
