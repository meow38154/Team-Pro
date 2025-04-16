using UnityEngine;

[CreateAssetMenu(fileName = "PushSO", menuName = "Scriptable Objects/PushSO")]
public class PushSO : ScriptableObject
{
    public string _goalTag;
    public LayerMask _whatIsWall;
}
