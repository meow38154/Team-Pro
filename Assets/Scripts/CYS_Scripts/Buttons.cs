using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace CYS_Scripts
{
    public class Buttons : MonoBehaviour
    {
        [FormerlySerializedAs("_startingForm")] [SerializeField] private GameObject startingForm;
        [FormerlySerializedAs("_starting")] [SerializeField] private TextMeshProUGUI starting;
        [FormerlySerializedAs("_turnOffTheLight")] [SerializeField] private GameObject turnOffTheLight;
        [FormerlySerializedAs("_dontDisturb")] [SerializeField] private GameObject dontDisturb;
        [SerializeField] private GameObject _3dCubeR;
        [SerializeField] private GameObject Setting;
        [FormerlySerializedAs("_credit")][SerializeField] private GameObject creditForm; [FormerlySerializedAs("_quitting")][SerializeField] private GameObject quitting;
        [SerializeField] GameObject _gold;
        [SerializeField] GameObject _play;
        [SerializeField] GameObject _logo;
        [SerializeField] GameObject _ob;
        [SerializeField] GameObject _ahPlz;
        [SerializeField] GameObject _stext;
        [SerializeField] GameObject _logoo;
        [SerializeField] GameObject _uis;

        bool _isTimeOver;

        private void Awake()
        {
            _gold = GameObject.Find("HapGOld_0");
            _play = GameObject.Find("Play!");
            _logo = GameObject.Find("Objects");
            _ob = GameObject.Find("Title");
            _ahPlz = GameObject.Find("MosueLight");
        }


        private void Start()
        {
            //_settingForm.SetActive(false);
            startingForm.SetActive(false);
            _3dCubeR.SetActive(false);
            creditForm.SetActive(false);
            Setting.SetActive(false);
        }

        public void StartingButton()
        {
            AudioManager.Instance.PlayUICilck();
            _gold.GetComponent<RotionPlus>()._play = true;
            _play.SetActive(false);
            Setting.SetActive(false);
            dontDisturb.SetActive(false);
            turnOffTheLight.SetActive(false);
            _ob.SetActive(false);
            _logo.SetActive(false);
            startingForm.SetActive(true);
            _3dCubeR.SetActive(true);
            quitting.SetActive(false);
            _stext.SetActive(false);
            _logoo.SetActive(false);
            _ahPlz.GetComponent<MouseMove>()._start = true;
        }

      public void Credit()
        {
            _uis.SetActive(false);
            AudioManager.Instance.PlayUICilck();
            creditForm.SetActive(true);
            Setting.SetActive(false);
        }
        
        public void Setting1()
        {
            if(!Setting.activeSelf)
            {
                Setting.SetActive(true);
            }
            else
            {
                Setting.SetActive(false);
            }
            
        }




        public void Quitting()
        {
            AudioManager.Instance.PlayUICilck();
            Application.Quit();
        }

    }
}
