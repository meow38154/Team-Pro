using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.SceneManagement;
using Main_Scripts;
public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private TextMeshProUGUI _stop;
    private bool wasStopped ;
    private GameManager gamemanager;
    
    
    private void Awake()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Time.timeScale = 1;
    }
    private void Start()
    {
        _stop.text = "ll";
        _pauseUI.SetActive(false);
        wasStopped = false;
  
    }


    public void Pause()
    {
        
            _stop.text = ">";
            _pauseUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void Return()
    {
        _stop.text = "ll";
        _pauseUI.SetActive(false);
    }

    public void ToLobby()
    {
        SceneManager.LoadScene(1);
    }

    public void Reset2()
    {
        gamemanager.Reset1();
    }
}



