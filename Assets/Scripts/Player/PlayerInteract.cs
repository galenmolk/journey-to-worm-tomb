using UnityEngine;

namespace WormTomb
{
    public class PlayerInteract : MonoBehaviour
    {
        public delegate void DiscoveredInteractable();
        public delegate void LostInteractable();

        public static event DiscoveredInteractable OnDiscoveredInteractable;
        public static event LostInteractable OnLostInteractable;
        
        // private const string InteractableLayerName = "Interactable";
        //
        // private int InteractableLayer { get; set; } 
        
        private IInteractable currentInteractable = null;
        
        public bool TryInteract()
        {
            if (currentInteractable == null || !currentInteractable.CanInteract())
                return false;

            currentInteractable.Interact();
            return true;
        }

        // private void Awake()
        // {
        //     InteractableLayer = LayerMask.NameToLayer(InteractableLayerName);
        // }

        private void OnTriggerEnter2D(Collider2D other)
        {
            // if (other.gameObject.layer != InteractableLayer)
            //     return;

            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            Debug.Log("Setting Current Interactable: " + other.gameObject.name);
            currentInteractable = interactable;
            OnDiscoveredInteractable?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            // if (other.gameObject.layer != InteractableLayer)
            //     return;
            
            if (!other.TryGetComponent(out IInteractable interactable))
                return;

            if (interactable != currentInteractable)
                return;
            
            Debug.Log("Removing Current Interactable: " + other.gameObject.name);
            currentInteractable = null;
            OnLostInteractable?.Invoke();
        }
    }
}
