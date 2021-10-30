using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WormTomb
{
    [RequireComponent(typeof(Image))]
    public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public PointerEvent PointerEntered = new PointerEvent();
        public PointerEvent PointerExited = new PointerEvent();

        public bool IsPressed { get; private set; }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Entered " + gameObject.name);
            IsPressed = true;
            PointerEntered.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            Debug.Log("Exited " + gameObject.name);
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
