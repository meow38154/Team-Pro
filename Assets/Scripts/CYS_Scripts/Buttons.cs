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

        bool _isTimeOver;
    
        private void Start()
        {
            //_settingForm.SetActive(false);
            startingForm.SetActive(false);
            _3dCubeR.SetActive(false);
            creditForm.SetActive(false);
       
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
            _ahPlz.GetComponent<MouseMove>()._start = true;
        }

      public void Credit()
        {
            AudioManager.Instance.PlayUICilck();
            creditForm.SetActive(true);
            Setting.SetActive(false);
        }
        
        
        
        
        
        
        public void Quitting()
        {
            AudioManager.Instance.PlayUICilck();
            Application.Quit();
        }

    }
}
