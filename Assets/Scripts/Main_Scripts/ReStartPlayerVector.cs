using Main_Scripts;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ReStartPlayerVector : MonoBehaviour
{
    [Header("범위 정하기")]
    [SerializeField] Vector2 ResetSizeOne;
    [SerializeField] Vector2 ResetSizeTwo;

    [Header("리셋 시 플레이어가 이동할 위치")]
    [SerializeField] Vector2 ResetPlayerPosition;

    [Header("건드리지 마시오")]
    [SerializeField] GameManager _gm;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _p;

    private void Awake()
    {
        _p = GameObject.Find("Player");
        _gm = GameObject.Find("GameManager")?.GetComponent<GameManager>();

        if (_gm != null && _gm.ManagerEvent != null)
        {
            _gm.ManagerEvent.AddListener(PlayerReset);
        }
        else
        {
            Debug.LogError("GameManager or ManagerEvent is not initialized properly.");
        }
    }



    void PlayerReset()
    {
        if (_p != null)
        {
            _player.transform.position = ResetPlayerPosition;
        }
    }


    private void Update()
    {
        if (_p != null)
        {
            if (_p.transform.position.x >= ResetSizeOne.x && _p.transform.position.x <= ResetSizeTwo.x &&
                _p.transform.position.y <= ResetSizeOne.y && _p.transform.position.y >= ResetSizeTwo.y)
            {
                //Debug.Log("범위 안에 있음");
                _player = GameObject.Find("Player");
            }

            else
            {
                _player = null;
            }
        }
    }
}
