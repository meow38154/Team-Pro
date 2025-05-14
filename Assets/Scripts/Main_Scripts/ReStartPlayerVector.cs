using Main_Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class ReStartPlayerVector : MonoBehaviour
{
    [SerializeField] Vector2 ResetPosition;
    [SerializeField] GameManager _gm;
    [SerializeField] GameObject _player;

    private void Awake()
    {
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
        _player.transform.position = ResetPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("¾Æ");
            _player = collision.gameObject;
        }
    }

}
