using UnityEngine;

public class CreditTextMove : MonoBehaviour
{
    [SerializeField]private float _speed;
    [SerializeField] private float _yPosition;
    [SerializeField] private float _yPosition2;
    private void OnEnable()
    {
        transform.position = new Vector2(transform.position.x, _yPosition);
    }

    private void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * _speed;
        if(transform.position.y > _yPosition2) transform.position = new Vector2(transform.position.x, _yPosition);
    }







}
