using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class CtrlZScript : MonoBehaviour
{
    public List<Vector3> moveList = new List<Vector3>();
    int listindex = 0;
    Vector3 pos;

    private void Start()
    {
        pos = transform.position;
    }


    private void Update()
    {

        if (pos != transform.position)
        {
            SavePosZ(pos);
            pos = transform.position;
        }
    }


    public void SavePosZ(Vector3 nowVec3)
    {
        moveList.Add(nowVec3);
        listindex++;
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
