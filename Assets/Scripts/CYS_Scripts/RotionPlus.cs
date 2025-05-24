using UnityEngine;

public class RotionPlus : MonoBehaviour
{
    [field: SerializeField] public bool _play { get; set; }
    [SerializeField] float _speed;
    void Update()
    {
        if (_play)
        {
            transform.Rotate(0, _speed * Time.deltaTime, 0); 
        }
    }
}
