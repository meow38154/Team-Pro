using UnityEngine;

public class CreditTextMove : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField] private float _yPosition;

    private void OnEnable()
    {
        transform.position = new Vector2(1300, _yPosition);
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _speed;
        if(transform.position.y > 3700) transform.position = new Vector2(1300, _yPosition);
    }







}
