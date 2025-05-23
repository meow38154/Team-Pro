using UnityEngine;
using System.Collections;

public class DoorOC : MonoBehaviour
{
    public static DoorOC Instance;

    public int score = 0;

    [Header("Open?")]
    [SerializeField] public bool stage1Open;
    [SerializeField] public bool stage2Open;
    [SerializeField] public bool stage3Open;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
