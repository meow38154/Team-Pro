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
                _MoveBlock[i].GetComponent<CtrlZScript>().CtrlZ();
                Debug.Log(i);
            }
        }
    }
}
