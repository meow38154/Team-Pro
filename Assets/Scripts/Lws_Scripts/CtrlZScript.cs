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
    Vector3 pos2;
    Vector3 pos3;
    Vector3 turnPos;

    private void Start()
    {
        pos = transform.position;
        pos2 = transform.position;
    }


    private void Update()
    {
        turnPos = GetComponent<PushableObject>()._turnPos;
    }


    public void SavePosZ()
    {
        moveList.Add(pos);
        listindex++;
        pos = pos2;
        pos2 = turnPos+transform.position;
    }

    public void CtrlZ()
    {
        if (listindex > 0)
        {
            transform.position = moveList[moveList.Count - 1];
            moveList.RemoveAt(moveList.Count - 1);
            listindex--;
            pos2 = transform.position;
        }
    }
}
