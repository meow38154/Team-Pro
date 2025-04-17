using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class CtrlZScript : MonoBehaviour
{
    List<Vector3> list = new List<Vector3>();
    int listindex = 0;
    public void SavePosZ(Vector3 nowVec3)
    {
        list.Add(nowVec3);
        listindex++;
    }
    public void CtrlZ()
    {
        if (listindex > 0)
        {
            transform.position = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            listindex--;
        }
            
    }
}
