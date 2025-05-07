using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class MoveBolckCtrlZ : MonoBehaviour
{
    //움직일수있는 블럭에 넣기만 하면 끝
    public List<Vector3> moveList = new List<Vector3>();
    int listindex = 0;

    private void Start()
    {
        CtrlZManager.moveBlockList.Add(this);
    }

    public void Save()
    {
        moveList.Add(transform.position);
        listindex++;
    }

    public void CtrlZ()
    {
        if (listindex > 0)
        {
            transform.position = moveList[moveList.Count - 1];
            moveList.RemoveAt(moveList.Count - 1);
            listindex--;
        }
    }
}
