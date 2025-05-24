using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortalScript : MonoBehaviour
{

    [SerializeField] GameObject _text;
    bool _able;
    [SerializeField] GameObject _player;

    [SerializeField] bool d;
    [SerializeField] float time;


    [Header("포탈번호")]
    [SerializeField] int num;
    [Header("이동할 씬")]
    [SerializeField] int sceneNum;
    [Header("페이드 시간")]
    [SerializeField] float fadeTime = 0.5f;
    GameObject fade;
    private void Awake()
    {
        d = false;
        _player = GameObject.Find("Player");
        fade = GameObject.Find("Black");
    }
    private void Update()
    {

        Able();

        if (_able)
        {
            _text.SetActive(true);
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                d = true;
                fade.GetComponent<Fade>().DarkPlay();
                Time.timeScale = 0f;
            }
        }

        if (d)
        {
            time += Time.unscaledDeltaTime;
        }

        if (time >= fadeTime)
        {
            Time.timeScale = 1f;
             SceneManagerReal scene = GameObject.Find("SceneManager").GetComponent<SceneManagerReal>();

            if (num == 1)
            {
                SettingManager.Instance.Stage1Open = true;
            }

            if (num == 2)
            {
                SettingManager.Instance.Stage2Open = true;
            }

            if (num == 3)
            {
                SettingManager.Instance.Stage3Open = true;
            }

            scene.ChangeScene(sceneNum);

        }

        if (_able == false)
        {
            _text.SetActive(false);
        }
    }

    void Able()
    {
        if (transform.position.x == _player.transform.position.x && transform.position.y == _player.transform.position.y)
        {
            _able = true;
        }

        else
        {
            _able = false;
        }
    }
}
