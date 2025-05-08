using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CtrlZManager : MonoBehaviour
{
    
    
    //�Ŵ��� �ϳ� ����� �־��ֱ⸸ �ϸ� ��
    public static  List<CtrlZMoveBolck> MoveBlockList = new List<CtrlZMoveBolck>();
    [FormerlySerializedAs("ZCoolTime")] [SerializeField] private float zCoolTime = 0.2f;
    private bool _coolTimeOk = true;
    public static CtrlZManager Instance;
    

    private void Awake()
    {
        MoveBlockList = new List<CtrlZMoveBolck>();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Keyboard.current.zKey.isPressed && _coolTimeOk)
        {
            StartCoroutine(MoveCoolTime());
            AllCtrlZ();
        }
    }
     public static void AllSave()
    {
        int a = MoveBlockList.Count;
        for (int i = 0; i < a;i++)
        {
            MoveBlockList[i].Save();
        }
    }

    public void AllCtrlZ()
    {
        int a = MoveBlockList.Count;
        for (int i = 0; i < a; i++)
        {
            MoveBlockList[i].CtrlZ();
        }
    }

    IEnumerator MoveCoolTime()
    {
        _coolTimeOk = false;
        yield return new WaitForSeconds(zCoolTime);
        _coolTimeOk = true;
    }
}
