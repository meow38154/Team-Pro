using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Main_Manager : MonoBehaviour
{
    [FormerlySerializedAs("_blockTagArr")] [SerializeField] private string[] blockTagArr;
    [FormerlySerializedAs("_pushableTagArr")] [SerializeField] private string[] pushableTagArr;

    public static Main_Manager Instance;

    private void Awake()
    {
        if (Instance != null)
            Instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

    public string[] GetBlockTagArr()
    {
        return blockTagArr;
    }
    public string[] GetPushableTagArr()
    {
        return pushableTagArr;
    }
}
