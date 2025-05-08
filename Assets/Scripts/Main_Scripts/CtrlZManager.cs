using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CtrlZManager : MonoBehaviour
{
    //매니저 하나 만들고 넣어주기만 하면 끝
    static public List<CtrlZMoveBolck> moveBlockList = new List<CtrlZMoveBolck>();
    [SerializeField] float ZCoolTime = 0.2f;
    bool CoolTimeOk = true;

    private void Awake()
    {
        moveBlockList = new List<CtrlZMoveBolck>();
    }

    private void Update()
    {
        if (Keyboard.current.zKey.isPressed && CoolTimeOk)
        {
            StartCoroutine(MoveCoolTime());
            AllCtrlZ();
        }
    }
<<<<<<< HEAD
     public static void AllSave()
=======
    static public void AllSave()
>>>>>>> parent of 4ef4e39 (Fixed: code)
    {
        int a = moveBlockList.Count;
        for (int i = 0; i < a;i++)
        {
            moveBlockList[i].Save();
        }
    }

    public void AllCtrlZ()
    {
        int a = moveBlockList.Count;
        for (int i = 0; i < a; i++)
        {
            moveBlockList[i].CtrlZ();
        }
    }

    IEnumerator MoveCoolTime()
    {
        CoolTimeOk = false;
        yield return new WaitForSeconds(ZCoolTime);
        CoolTimeOk = true;
    }
}
