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

    private void Awake()
    {
        _render = GetComponent<SpriteRenderer>();
        _blocks = GetComponent<Blocks>();
        _blocks.WallTrue();
    }

    private void Start()
    {
        if (_isVertical)
        {
            _render.sprite = _vDoorC;
        }
        else
        {
            _render.sprite = _hDoorC;
        }
    }

    private void Update()
    {
        if (Blocks.GoalSignal)
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
            _render.sprite = _vDoorO;
        }
        else
        {
            _render.sprite = _hDoorO;
        }
        _blocks.Wall();
    }

}
