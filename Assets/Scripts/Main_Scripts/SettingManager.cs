using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            LoadSettings(); // 게임 시작 시 저장된 값 불러오기
        }
        else
        {
            Destroy(gameObject);
        }
        StartCoroutine(SaveCoolTime());
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
            SceneManager.LoadScene(0);

        }

    }

    IEnumerator SaveCoolTime()
    {
        yield return new WaitForSeconds(2);
        SaveSettings();
        Debug.Log("cool");
        StartCoroutine(SaveCoolTime());
    }    

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("Copper", Copper);
        PlayerPrefs.SetFloat("Iron", Iron);
        PlayerPrefs.SetFloat("Gold", Gold);
        PlayerPrefs.SetFloat("HapGold", HapGold);

        PlayerPrefs.SetInt("Stage1Open", Stage1Open ? 1 : 0);
        PlayerPrefs.SetInt("Stage2Open", Stage2Open ? 1 : 0);
        PlayerPrefs.SetInt("Stage3Open", Stage3Open ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        Copper = PlayerPrefs.GetFloat("Copper", 0f);
        Iron = PlayerPrefs.GetFloat("Iron", 0f);
        Gold = PlayerPrefs.GetFloat("Gold", 0f);
        HapGold = PlayerPrefs.GetFloat("HapGold", 0f);

        Stage1Open = PlayerPrefs.GetInt("Stage1Open", 0) == 1;
        Stage2Open = PlayerPrefs.GetInt("Stage2Open", 0) == 1;
        Stage3Open = PlayerPrefs.GetInt("Stage3Open", 0) == 1;
    }
}
