using UnityEngine;

public class TextBoxDown : MonoBehaviour
{
    GameObject _parent, _textBox, _player;
    [SerializeField] Vector3 _showOffset = new Vector3(0, 3f, 0); // 표시 위치 오프셋
    [SerializeField] Vector3 _hideOffset = new Vector3(0, 100f, 0); // 숨김 위치 오프셋
    float _threshold = 0.1f;
    float _lerpSpeed = 5f; // 부드럽게 이동하는 속도
    float _lowSpeed;
    float _highSpeed;

    private void Awake()
    {
        _parent = transform.parent.gameObject;
        _textBox = _parent.transform.GetChild(1).gameObject;
        _player = GameObject.Find("Player");
        _highSpeed = _lerpSpeed / 1;
        _lowSpeed = _lerpSpeed / 10;
    }

    private void Update()
    {
        Vector3 playerPos = _player.transform.position;
        Vector3 thisPos = transform.position;

        Vector3 targetPosition;

        // 플레이어가 가까우면 보여줄 위치, 아니면 숨김 위치
        if (Mathf.Abs(playerPos.x - thisPos.x) < _threshold &&
            Mathf.Abs(playerPos.y - thisPos.y) < _threshold)
        {
            targetPosition = _parent.transform.position + _showOffset;

            _textBox.transform.position = Vector3.Lerp(
            _textBox.transform.position,
            targetPosition,
            Time.deltaTime * _highSpeed
            );
        }
        else
        {
            targetPosition = _parent.transform.position + _hideOffset;

            _textBox.transform.position = Vector3.Lerp(
            _textBox.transform.position,
            targetPosition,
            Time.deltaTime * _lowSpeed
            );
        }
    }
}
