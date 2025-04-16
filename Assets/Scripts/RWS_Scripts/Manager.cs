using UnityEngine;

public class Manager2 : MonoBehaviour
{
    [SerializeField] private string[] _blockTagArr;
    [SerializeField] private string[] _pushableTagArr;

    public string[] GetBlockTagArr()
    {
        return _blockTagArr;
    }
    public string[] GetPushableTagArr()
    {
        return _pushableTagArr;
    }
}
