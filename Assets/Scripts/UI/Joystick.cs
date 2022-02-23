using UnityEngine;
using UnityEngine.EventSystems;

namespace WormTomb
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
    {
        public float X => direction.x;
        public float Y => direction.y;

        [SerializeField] private RectTransform innerCircle;
        [SerializeField] private RectTransform outerCircle;
        [SerializeField] private CanvasGroup canvasGroup;

        private Vector2 startPos;
        private Vector2 endPos;
        private Vector2 direction;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            startPos = eventData.position;
            outerCircle.position = startPos;
            innerCircle.localPosition = Vector2.zero;
            canvasGroup.alpha = 1f;
        }

        public void OnDrag(PointerEventData eventData)
        {
            endPos = eventData.position;
            direction = (endPos - startPos).normalized;
            Debug.Log("direction: " + direction);
            Vector2 innerCirclePos = direction * outerCircle.rect.width * 0.5f;
            innerCircle.localPosition = innerCirclePos;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            canvasGroup.alpha = 0f;
        }

        private void Awake()
        {
            canvasGroup.alpha = 0f;
        }
    }
}
