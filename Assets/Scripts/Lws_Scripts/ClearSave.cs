using UnityEngine;

public class ClearSave : MonoBehaviour
{
    private int _clearStage = 0;

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

    private void Start()
    {
        ClearStage = PlayerPrefs.GetInt("ClearStage");
    }


    private void setClearStage()
    {

        PlayerPrefs.SetInt("ClearStage", ClearStage);

        //int a = PlayerPrefs.GetInt("ClearStage");
        //if(ClearStage > a)
        //{
        //    PlayerPrefs.SetInt("ClearStage", ClearStage);
        //}
        //else if(ClearStage < a) 
        //{
        //    ClearStage = a;
        //}
    }

    private void SettingManagerSetting()
    {
        SettingManagerr a = SettingManagerr.Instance;
        bool[] b = { a.Stage1Open, a.Stage2Open, a.Stage3Open };
        //for(int i = 0;i < ClearStage;)
    }
}
