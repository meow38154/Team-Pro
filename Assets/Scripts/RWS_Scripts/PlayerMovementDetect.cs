using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMovementDetect : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _rend;
    [SerializeField] private GameObject _player;
    [SerializeField] private string _playerName = "RWS_Player";

    private float _playerX;
    private float _playerY;

    private void Awake()
    {
        _player = GameObject.Find(_playerName);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick()
    {
        Vector3 newPosition = _player.transform.position;
        newPosition += transform.localPosition;
        _player.transform.position = newPosition;
    }
}
