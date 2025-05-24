using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class SettingManagerr : MonoBehaviour
{
    public static SettingManagerr Instance;

    public int score = 0;

    [Header("Open?")]
    [field: SerializeField] public bool Stage1Open { get; set; }
    [field: SerializeField] public bool Stage2Open { get; set; }
    [field: SerializeField] public bool Stage3Open { get; set; }

    [Header("Volume")]
    [field: SerializeField] public float Master { get; set; }
    [field: SerializeField] public float BGM { get; set; }
    [field: SerializeField] public float SoundEffect { get; set; }

    [Header("Score")]
    [field: SerializeField] public float Copper { get; set; }
    [field: SerializeField] public float Iron { get; set; }
    [field: SerializeField] public float Gold { get; set; }
    [field: SerializeField] public float HapGold { get; set; }

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

    private void Update()
    {
        if (Keyboard.current.zKey.isPressed && Keyboard.current.pKey.wasPressedThisFrame)
        {
            Copper = 0;
            Iron = 0;
            Gold = 0;
            HapGold = 0;
            Stage1Open = false;
            Stage2Open = false;
            Stage3Open = false;
        }
    }
}
