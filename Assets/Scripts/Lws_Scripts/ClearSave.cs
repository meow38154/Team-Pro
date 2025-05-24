using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ClearSave : MonoBehaviour
{
    private int _clearStage = 0;

    

    public static ClearSave Instance;

    private int Stage1Open = 0;
    private int Stage2Open = 0;
    private int Stage3Open = 0;

    private float currentTime = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {

        Stage1Open = PlayerPrefs.GetInt("Stage1Open",0);
        Stage2Open = PlayerPrefs.GetInt("Stage2Open",0);
        Stage3Open = PlayerPrefs.GetInt("Stage3Open",0);

        PlayerPrefs.SetInt("Stage1Open", Stage1Open);
        PlayerPrefs.SetInt("Stage2Open", Stage2Open);
        PlayerPrefs.SetInt("Stage3Open", Stage3Open);

        SettingManagerSetting(0);
    }
    private void Update()
    {
        Debug.Log($"{Stage1Open}, {Stage2Open}, {Stage3Open}");


        openReset();


        if(currentTime <= 0)
        {
            SettingManagerSetting(0);
            Debug.Log("riwoo");
            currentTime = 2;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }


    private void openReset()
    {
        if (Keyboard.current.rKey.isPressed && Keyboard.current.numpad0Key.wasPressedThisFrame)
        {

            PlayerPrefs.SetInt("Stage1Open", 0);
            PlayerPrefs.SetInt("Stage2Open", 0);
            PlayerPrefs.SetInt("Stage3Open", 0);
            SettingManagerr.Instance.Stage1Open = false;
            SettingManagerr.Instance.Stage2Open = false;
            SettingManagerr.Instance.Stage3Open = false;
        }
    }

    public void SettingManagerSetting(int a)
    {
        if(a != 0)PlayerPrefs.SetInt($"Stage{a}Open",1);

        Stage1Open = PlayerPrefs.GetInt("Stage1Open",0);
        Stage2Open = PlayerPrefs.GetInt("Stage2Open",0);
        Stage3Open = PlayerPrefs.GetInt("Stage3Open",0);

        SettingManagerr.Instance.Stage1Open = Stage1Open == 1 ? true : false;
        SettingManagerr.Instance.Stage2Open = Stage2Open == 1 ? true : false;
        SettingManagerr.Instance.Stage3Open = Stage3Open == 1 ? true : false;
    }

    public void GetMetal(int a,int b,int c,int d)
    {

        PlayerPrefs.SetInt("Copper", PlayerPrefs.GetInt("Copper")+a);
        PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") + a);
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + a);
        PlayerPrefs.SetInt("HapGold", PlayerPrefs.GetInt("HapGold") + a);

        SettingManagerr.Instance.Copper  = PlayerPrefs.GetInt("Copper");
        SettingManagerr.Instance.Iron = PlayerPrefs.GetInt("Iron");
        SettingManagerr.Instance.Gold = PlayerPrefs.GetInt("Gold");
        SettingManagerr.Instance.HapGold = PlayerPrefs.GetInt("HapGold");
    }
}
