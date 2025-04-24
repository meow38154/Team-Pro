using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCtrlZScript : MonoBehaviour
{
    public List<Vector3> moveList = new List<Vector3>();
    int listindex = 0;
    Vector3 pos;
    Vector3 turnPos;
    private void Start()
    {
        pos = transform.position;
    }



    public void SavePosZ()
    {
        moveList.Add(pos);
        listindex++;
        pos = transform.position;
    }

    public void CtrlZ()
    {
        if (listindex > 0)
        {
            transform.position = moveList[moveList.Count - 1];
            moveList.RemoveAt(moveList.Count - 1);
            listindex--;
            pos = transform.position;
        }
            
    }
}
