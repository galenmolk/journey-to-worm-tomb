using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using WormTomb.General;

namespace WormTomb.UI
{
    [RequireComponent(typeof(Image))]
    public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public readonly PointerEvent PointerEntered = new();
        public readonly PointerEvent PointerExited = new();

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
