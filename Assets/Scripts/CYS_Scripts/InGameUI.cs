using UnityEngine;
using UnityEngine.Serialization;
using TMPro;
using UnityEngine.SceneManagement;
using Main_Scripts;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.EventSystems;
using Unity.Cinemachine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
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
                Time.timeScale = 0;
                Pause();
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
        
            _stop.text = ">";
            _pauseUI.SetActive(true);
        Time.timeScale = 0;

    }

    public void Return()
    {
        _stop.text = "ll";
        _pauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void ToLobby()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void Reset2()
    {
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



