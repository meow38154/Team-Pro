using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] GameObject _playergo;
    Vector2 _vector2;
    [SerializeField] float _speed;


    private void Update()
    {
        _vector2 = _playergo.transform.position - transform.position;
        transform.position += (Vector3)_vector2 * _speed * Time.deltaTime;
    }
}
