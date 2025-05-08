using UnityEngine;

public class GoalIn : MonoBehaviour
{
    [SerializeField] int _goalNumber;
    Blocks _blocks;

    private void Awake()
    {
        
        _blocks = GetComponent<Blocks>();
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
                    return;
                }
            }
        }
    }

}
