using UnityEngine;

public class ClearSave : MonoBehaviour
{
    private int _clearStage = 0;

    SettingManagerr _ClearStageClass = SettingManagerr.Instance;

    public int ClearStage
    {
        get
        {
            return _clearStage;
        }
        set
        {
            _clearStage = value;
            setClearStage();
        }
    }

    public int[] haveMetals
    {
        get
        {
            return haveMetals;
        }
        set
        {

        }
    }

    private void Start()
    {
        ClearStage = PlayerPrefs.GetInt("ClearStage");
        SettingManagerSetting();
    }


    private void setClearStage()
    {
        int a = PlayerPrefs.GetInt("ClearStage");
        if (ClearStage > a)
        {
            PlayerPrefs.SetInt("ClearStage", ClearStage);
        }
        else if (ClearStage < a)
        {
            ClearStage = a;
        }
    }

    public void SettingManagerSetting()
    {
        
        bool[] b = { _ClearStageClass.Stage1Open, _ClearStageClass.Stage2Open, _ClearStageClass.Stage3Open };
        _ClearStageClass.Stage1Open = true;
        _ClearStageClass.Stage2Open = true;
        _ClearStageClass.Stage3Open = true;


        //for(int i = 0;i < ClearStage;)
        //{

        //}

    }

    public void GetMetal(int a,int b,int c,int d)
    {
        _ClearStageClass.Copper += a;
        _ClearStageClass.Iron += b;
        _ClearStageClass.Gold += c;
        _ClearStageClass.HapGold += d;
    }
}
