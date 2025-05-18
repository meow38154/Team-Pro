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

    [Header("이동할 씬")]
    [SerializeField] int sceneNum;
    [Header("페이드 시간")]
    [SerializeField] float fadeTime = 0.5f;
    private void Awake()
    {
        d = false;
        _player = GameObject.Find("Player");
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
                Time.timeScale = 0f;
            }
        }

        if (d)
        {
            time += Time.unscaledDeltaTime;
        }

        if (time >= fadeTime)
        {
             SceneManagerReal scene = GameObject.Find("SceneManager").GetComponent<SceneManagerReal>();
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
