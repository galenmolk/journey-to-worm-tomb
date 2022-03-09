using UnityEngine;
using UnityEngine.UI;

namespace WormTomb
{
    [RequireComponent(typeof(Image))]
    public class InteractableAlert : MonoBehaviour
    {
        private Image image;
        
        private void Show()
        {
            image.enabled = true;
        }

        private void Hide()
        {
            image.enabled = false;
        }

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void OnEnable()
        {
            PlayerInteract.OnDiscoveredInteractable += Show;
            PlayerInteract.OnLostInteractable += Hide;
        }

        private void OnDisable()
        {
            PlayerInteract.OnDiscoveredInteractable -= Show;
            PlayerInteract.OnLostInteractable -= Hide;
        }
    }
}
