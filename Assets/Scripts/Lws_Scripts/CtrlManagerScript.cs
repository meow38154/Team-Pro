using UnityEngine;
using UnityEngine.InputSystem;

public class CtrlManagerScript : MonoBehaviour
{
    [SerializeField] GameObject[] _MoveBlock;
    
    void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
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
    }
    public void AllSave()
    {
        for (int i = 0; i < _MoveBlock.Length; i++)
        {
            if (i == 0)
            {
                _MoveBlock[i].gameObject.GetComponent<PlayerCtrlZScript>().SavePosZ();
            }
            else
            {
                _MoveBlock[i].gameObject.GetComponent<CtrlZScript>().SavePosZ();
                
            }
        }
    }
}
