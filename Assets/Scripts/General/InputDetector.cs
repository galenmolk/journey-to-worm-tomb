using UnityEngine;
using UnityEngine.EventSystems;

public class InputDetector : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    public PointerEvent pointerDownHandler = new PointerEvent();
    public PointerEvent pointerEnterHandler = new PointerEvent();
    public PointerEvent pointerUpHandler = new PointerEvent();
    public PointerEvent pointerExitHandler = new PointerEvent();
    
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDownHandler.Invoke(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pointerUpHandler.Invoke(eventData);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        pointerEnterHandler.Invoke(eventData);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        pointerExitHandler.Invoke(eventData);
    }
}
