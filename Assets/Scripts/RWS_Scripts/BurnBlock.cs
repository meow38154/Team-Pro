using UnityEngine;

public class BurnBlock : MonoBehaviour
{
    [SerializeField] private GameObject _blockPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _blockPrefab = GameObject.FindGameObjectWithTag(collision.gameObject.tag);
        Instantiate(_blockPrefab, transform.position, Quaternion.identity);
    }
}
