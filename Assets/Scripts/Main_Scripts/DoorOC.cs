using UnityEngine;
using System.Collections;

public class DoorOC : MonoBehaviour
{
    public static DoorOC Instance;

    public int score = 0;

    [Header("Open?")]
    [field: SerializeField] public bool Stage1Open { get; set; }
    [field: SerializeField] public bool Stage2Open { get; set; }
    [field: SerializeField] public bool Stage3Open { get; set; }

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
