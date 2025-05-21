using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragOut : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] bool _maxmin;
    private bool isHolding = false;
    CinemachineCamera _camera;

    private void Awake()
    {
        _camera = GameObject.Find("CinemachineCamera").GetComponent<CinemachineCamera>();
    }

    void Update()
    {
        if (isHolding)
        {
            if (_camera.Lens.OrthographicSize > 1 && _maxmin == false)
            {
                Debug.Log("√Îº“¡∂∞«µ  " + _camera.Lens.OrthographicSize);
                _camera.Lens.OrthographicSize -= 0.05f;
            }

            if (_camera.Lens.OrthographicSize < 15 && _maxmin)
            {
                Debug.Log("»Æ¥Î¡∂∞«µ , " + _camera.Lens.OrthographicSize);
                _camera.Lens.OrthographicSize += 0.05f;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
    }
}
