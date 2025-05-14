using Main_Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class ReStartPlayerVector : MonoBehaviour
{
    [Header("���� ���ϱ�")]
    [SerializeField] Vector2 ResetSizeOne;
    [SerializeField] Vector2 ResetSizeTwo;

    [Header("���� �� �÷��̾ �̵��� ��ġ")]
    [SerializeField] Vector2 ResetPlayerPosition;

    [Header("�ǵ帮�� ���ÿ�")]
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
