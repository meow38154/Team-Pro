using UnityEngine;

public class GoalIn : MonoBehaviour
{
    [SerializeField] int _goalNumber;
    Blocks _blocks;

    private void Awake()
    {
        
        _blocks = GetComponent<Blocks>();
        _blocks.WallTrue();
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
        _blocks.Wall();
    }

}
