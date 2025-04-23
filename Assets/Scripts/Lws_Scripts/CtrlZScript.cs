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
    Vector3 turnPos;
    private void Start()
    {
        pos = transform.position;
    }


    private void Update()
    {
        turnPos = GetComponent<PushableObject>()._turnPos;
    }


    public void SavePosZ()
    {
        moveList.Add(turnPos);
        listindex++;
        pos = turnPos;
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
