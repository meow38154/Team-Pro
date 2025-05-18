using System.Collections;
using Main_Scripts;
using UnityEngine;
using UnityEngine.InputSystem;

public class GoalIn : MonoBehaviour
{
    [SerializeField] int _goalNumber;
    [SerializeField] bool _openClose;

    [SerializeField] bool _isVertical;
    [SerializeField] Sprite _vDoorO;
    [SerializeField] Sprite _vDoorC;
    [SerializeField] Sprite _hDoorO;
    [SerializeField] Sprite _hDoorC;
    Blocks _blocks;
    private SpriteRenderer _render;
    GameManager _gm;

    bool _one;

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _blocks = GetComponent<Blocks>();
        _blocks.WallTrue();
    }

    private void Update()
    {
            Sprite();

        if (Blocks._goalSignal)
        {
            GamSec();
        }
    }
    void Sprite()
    {
        if (_openClose && _isVertical == false)
        {
            _render.sprite = _vDoorO;
        }

        if (_openClose == false && _isVertical == false)
        {
            _render.sprite = _vDoorC;
        }

        if (_openClose && _isVertical)
        {
            _render.sprite = _hDoorO;
        }

        if (_openClose == false && _isVertical)
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
            _blocks.WallTrue();
            _openClose = false;
        }
        else
        {
            if (_one == false)
            {
                GetComponent<Blocks>().PlayParticle();
                _one = true;
            }
            _openClose = true;
            _blocks.Wall();
        }
    }

}
