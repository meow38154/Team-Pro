using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CtrlZMoveBolck : MonoBehaviour
{
    //�����ϼ��ִ� ���� �ֱ⸸ �ϸ� ��
    public List<Vector3> moveList = new List<Vector3>();
    private int _listindex = 0;

    private void Start()
    {
        CtrlZManager.MoveBlockList.Add(this);
    }

    public void Save()
    {
        moveList.Add(transform.position);
        _listindex++;
    }

    public void CtrlZ()
    {
        if (_listindex > 0)
        {
            transform.position = moveList[moveList.Count - 1];
            moveList.RemoveAt(moveList.Count - 1);
            _listindex--;
        }
    }
}
