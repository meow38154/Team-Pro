using System.Collections;
using Main_Scripts;
using UnityEngine;

public class GoalIn : MonoBehaviour
{
    [SerializeField] int _goalNumber;
    [SerializeField] bool _isVertical;
    [SerializeField] Sprite _vDoorO;
    [SerializeField] Sprite _vDoorC;
    [SerializeField] Sprite _hDoorO;
    [SerializeField] Sprite _hDoorC;
    Blocks _blocks;
    private SpriteRenderer _render;
    GameManager _gm;

    private void Awake()
    {
        _gm = GameObject.Find("GameManager")?.GetComponent<GameManager>();
        if (_gm != null && _gm.ManagerEvent != null)
        {
            _gm.ManagerEvent.AddListener(ReStart);
        }
        else
        {
            Debug.LogError("GameManager or ManagerEvent is not initialized properly.");
        }

        _render = GetComponent<SpriteRenderer>();
        _blocks = GetComponent<Blocks>();
        _blocks.WallTrue();

    }

    private void OnEnable()
    {
        if (_isVertical)
        {
            Debug.Log("Start");
            _render.sprite = _vDoorC;
        }

        //Å×½ºÆ®

        else
        {
            Debug.Log("Start else");
            _render.sprite = _hDoorC;
        }
        
    }

    private void Update()
    {
        if (Blocks._goalSignal)
        {
            GamSec();
        }
    }
    void GamSec()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");

        foreach (GameObject obj in blocks)
        {
            if (obj == this.gameObject) continue;

            Blocks block = obj.GetComponent<Blocks>();
            if (block != null)
            {
                if (block.BlockNumber == _goalNumber)
                {
                    _blocks.WallTrue();
                    return;
                }
            }
        }

        if(_isVertical)
        {
            Debug.Log("_isVertical");
            _render.sprite = _vDoorO;
        }

        else
        {
            Debug.Log("_isVertical else");
            _render.sprite = _hDoorO;
        }

        _blocks.Wall();
    }

    public void ReStart()
    {
        StartCoroutine(ResetWaiTime());
    }


    private IEnumerator ResetWaiTime()
    {
        yield return new WaitForSeconds(0.1f);
        if (_isVertical)
        {
            Debug.Log("Start");
            _render.sprite = _vDoorC;
        }
        else
        {
            Debug.Log("Start else");
            _render.sprite = _hDoorC;
        }
    }
}
