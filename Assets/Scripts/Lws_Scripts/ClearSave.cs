using UnityEngine;

public class ClearSave : MonoBehaviour
{
    private int _clearStage = 0;

    SettingManagerr _ClearStageClass = SettingManagerr.Instance;

    public static ClearSave Instance;

    private int Stage1Open = 0;
    private int Stage2Open = 0;
    private int Stage3Open = 0;



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
    }


    public void SettingManagerSetting(int a)
    {
        if(a != 0)PlayerPrefs.SetInt($"Stage{a}Open",1);
        PlayerPrefs.SetInt("Stage1Open", Stage1Open);
        PlayerPrefs.SetInt("Stage2Open", Stage2Open);
        PlayerPrefs.SetInt("Stage3Open", Stage3Open);

        _ClearStageClass.Stage1Open = Stage1Open == 1 ? true : false;
        _ClearStageClass.Stage2Open = Stage2Open == 1 ? true : false;
        _ClearStageClass.Stage3Open = Stage3Open == 1 ? true : false;
    }

    public void GetMetal(int a,int b,int c,int d)
    {

        PlayerPrefs.SetInt("Copper", PlayerPrefs.GetInt("Copper")+a);
        PlayerPrefs.SetInt("Iron", PlayerPrefs.GetInt("Iron") + a);
        PlayerPrefs.SetInt("Gold", PlayerPrefs.GetInt("Gold") + a);
        PlayerPrefs.SetInt("HapGold", PlayerPrefs.GetInt("HapGold") + a);

        _ClearStageClass.Copper  = PlayerPrefs.GetInt("Copper");
        _ClearStageClass.Iron = PlayerPrefs.GetInt("Iron");
        _ClearStageClass.Gold = PlayerPrefs.GetInt("Gold");
        _ClearStageClass.HapGold = PlayerPrefs.GetInt("HapGold");
    }
}
