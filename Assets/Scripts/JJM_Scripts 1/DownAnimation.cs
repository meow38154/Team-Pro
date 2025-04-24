using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class DownAnimation : MonoBehaviour
{
    [SerializeField] GameObject _player;
    float _y;
    bool _down;
    [SerializeField] float _speed;
    [SerializeField] float _up;


    private void Update()
    {
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    DownAnimationPlay();
        //}

        if (_down)
        {
            transform.position -= new Vector3(0, _speed, 0) * Time.deltaTime;
        }

        if (_y >= transform.position.y)
        {
            _down = false;
            transform.position = new Vector3(transform.position.x, _y, transform.position.z);
        }
    }

    public void DownAnimationPlay()
    {
        _down = true;
        _y = _player.transform.position.y;
        transform.position += new Vector3(0, _up, 0);
    }
}
