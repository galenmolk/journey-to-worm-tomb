using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WormTomb
{
    [RequireComponent(typeof(Image))]
    public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public readonly PointerEvent PointerEntered = new PointerEvent();
        public readonly PointerEvent PointerExited = new PointerEvent();

        public bool IsPressed { get; private set; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            IsPressed = true;
            PointerEntered.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            IsPressed = false;
            PointerExited.Invoke(eventData);
        }

        private void OnDestroy()
        {
            PointerEntered.RemoveAllListeners();
            PointerExited.RemoveAllListeners();
        }
    }
}
