using Main_Scripts;
using Unity.VisualScripting;
using UnityEngine;

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

    private void Awake()
    {
                _player = GameObject.Find("Player");
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
        if(_player != null)
        {
            if (_player.transform.position.x >= ResetSizeOne.x && _player.transform.position.x <= ResetSizeTwo.x &&
                _player.transform.position.x <= ResetSizeOne.y && _player.transform.position.y >= ResetSizeTwo.x)
            {
                _player.transform.position = ResetPlayerPosition;
            }

            else
            {
                _player = null;
            }

        }
    }     
}
