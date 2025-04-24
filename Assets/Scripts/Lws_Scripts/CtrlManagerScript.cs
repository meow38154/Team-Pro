using UnityEngine;
using UnityEngine.InputSystem;

public class CtrlManagerScript : MonoBehaviour
{
    [SerializeField] GameObject[] _MoveBlock;
    
    void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            Debug.Log("All ZZZZZZZZZZZZZZZZZ!!!!!!!!!!!!!!!");
            for (int i = 0;i < _MoveBlock.Length; i++)
            {
                if (i == 0)
                {
                    _MoveBlock[i].GetComponent<PlayerCtrlZScript>().CtrlZ();
                }
                else
                {
                    _MoveBlock[i].GetComponent<CtrlZScript>().CtrlZ();
                }
            }
        }

        if (Keyboard.current.tKey.wasPressedThisFrame){
            AllSave();
        }
    }
    public void AllSave()
    {
        Debug.Log("All Save!!!!!!!!!!!!!!!");
        for (int i = 0; i < _MoveBlock.Length; i++)
        {
            if (i == 0)
            {
                _MoveBlock[i].GetComponent<PlayerCtrlZScript>().SavePosZ();
            }
            else
            {
                _MoveBlock[i].GetComponent<CtrlZScript>().SavePosZ();
                
            }
        }
    }
}
