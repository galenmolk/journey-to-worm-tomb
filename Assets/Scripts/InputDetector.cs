using UnityEngine;
using UnityEngine.EventSystems;

public class InputDetector : MonoBehaviour, IPointerDownHandler
{
    public PointerEvent tapHandler = new PointerEvent();

    public void OnPointerDown(PointerEventData eventData)
    {
        tapHandler.Invoke(eventData);
    }
}
