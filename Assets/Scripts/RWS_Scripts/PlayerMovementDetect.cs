using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovementDetect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rend;
    [SerializeField] private GameObject _player;
    [SerializeField] private string _playerName = "RWS_Player";
    [SerializeField] private bool _isBlocked;

    private float _playerX;
    private float _playerY;

    private void Awake()
    {
        _player = GameObject.Find(_playerName);
        _rend = GetComponent<SpriteRenderer>();
    }

    public void OnClick()
    {
        if (_isBlocked == false)
        {
            Vector3 newPosition = _player.transform.position;
            newPosition += transform.localPosition;
            _player.transform.position = newPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            _isBlocked = true;
            _rend.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _isBlocked = false;
        _rend.color = Color.green;
    }
}
