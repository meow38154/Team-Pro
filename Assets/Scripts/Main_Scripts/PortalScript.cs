using UnityEngine;
using UnityEngine.InputSystem;

public class PortalScript : MonoBehaviour
{
    [SerializeField] GameObject _text;
    bool _able;
    [SerializeField] GameObject _player;
    [SerializeField] SceneFade _sceneFade;

    private void Awake()
    {
        _player = GameObject.Find("Player");
        _sceneFade = GameObject.Find("BlackScreen").GetComponent<SceneFade>();
    }
    private void Update()
    {
        Able();

        if (_able)
        {
            _text.SetActive(true);
            if (Keyboard.current.rKey.wasPressedThisFrame)
            {
                _sceneFade.SceneChangeFadeout();
            }
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
