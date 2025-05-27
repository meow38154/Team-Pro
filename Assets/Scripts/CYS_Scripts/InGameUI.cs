using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.SceneManagement;
using Main_Scripts;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.EventSystems;
using Unity.Cinemachine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private Sprite stopped;
    [SerializeField] private Sprite resumed;
    [SerializeField] private Image stopBtn;
    [SerializeField] private TextMeshProUGUI _stop;
    private bool wasStopped ;
    private GameManager gamemanager;
    [SerializeField] CinemachineCamera _camera;


    private IEnumerator Start()
    {
        while (GameManager.Instance == null)
        {
            yield return null;
        }

        gamemanager = GameManager.Instance;

        _stop.text = "ll";
        _pauseUI.SetActive(false);
        wasStopped = false;
    }


    private void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (!_pauseUI.activeSelf)
            {
                Pause();
                Time.timeScale = 0;
            }

            else if (_pauseUI.activeSelf)
            {
                Time.timeScale = 1;
                Return();
            }
        }
    }

    //a

    public void Pause()
    {
        AudioManager.Instance.PlayUICilck();
        stopBtn.sprite = stopped;
            _stop.text = ">";
            _pauseUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void Return()
    {
        AudioManager.Instance.PlayUICilck();
        stopBtn.sprite = resumed;
        _stop.text = "ll";
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void PR()
    {
        if(stopBtn.sprite == stopped)
        {
            AudioManager.Instance.PlayUICilck();
            stopBtn.sprite = resumed;
            _stop.text = "ll";
            _pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
        else if (stopBtn.sprite == resumed)
        {
            AudioManager.Instance.PlayUICilck();
            stopBtn.sprite = stopped;
            _stop.text = ">";
            _pauseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ToLobby()
    {
        AudioManager.Instance.PlayUICilck();
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Reset2()
    {
        AudioManager.Instance.PlayResetPlay();
        gamemanager.Reset1();
        Time.timeScale = 1;
        _pauseUI.SetActive(false);
    }

    public void Expansion()
    {
        Debug.Log("취소");
        if (_camera.Lens.OrthographicSize > 1)
        {
            Debug.Log("취소조건됨 " + _camera.Lens.OrthographicSize);
            _camera.Lens.OrthographicSize -= 0.3f;
        }
    }

    public void Shrinking()
    {
        Debug.Log("확대");
        if (_camera.Lens.OrthographicSize < 15)
        {
            Debug.Log("확대조건됨, " + _camera.Lens.OrthographicSize);
            _camera.Lens.OrthographicSize += 0.3f;
        }
    }
}



