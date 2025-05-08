using UnityEngine;

namespace CYS_Scripts
{
    public class PlayerViewMovement : MonoBehaviour
    {
        private RectTransform _rectTransform;
        private Canvas _canvas;
   
  
    
    
        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<Canvas>();
       
        }

        private void Update()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                _canvas.transform as RectTransform,
                Input.mousePosition,
                _canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : _canvas.worldCamera,
                out var mousePoint 
            );
            _rectTransform.anchoredPosition = mousePoint;

        }
   

        private void LateUpdate()
        {
            _rectTransform.anchoredPosition = new Vector3(Mathf.Clamp(_rectTransform.anchoredPosition.x, -972.4036f, 945.596f), _rectTransform.anchoredPosition.y, 0);
            _rectTransform.anchoredPosition = new Vector3(_rectTransform.anchoredPosition.x, Mathf.Clamp(_rectTransform.anchoredPosition.y, -604.4187f, 553.581f), 0);

            //transform.position = new Vector3(Mathf.Clamp((Mathf.Clamp(Transform.Position.x, 272.4036f, 1045.596f), Transform.Position.y, 0);
            //transform.position = new Vector3(Transform.Position.x, Mathf.Clamp(Transform.Position.y, -604.4187f, 553.581f), 0);
            //Mathf.Clamp(a,20,30) if a<20, a = 20; if a >40, a = 40;
        }





    }
}
