using UnityEngine;

namespace WormTomb
{
    public class PlayerClimb : MonoBehaviour
    {
        public static bool isTouchingClimbable;
        
        public delegate void ClimbableEntered();
        public delegate void ClimbableExited();

        public static event ClimbableEntered OnClimbableEntered;
        public static event ClimbableExited OnClimbableExited;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IClimbable _))
                return;

            Debug.Log("Climbable Entered: " + other.gameObject.name);
            OnClimbableEntered?.Invoke();
            isTouchingClimbable = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IClimbable _))
                return;

            Debug.Log("Climbable Exited: " + other.gameObject.name);
            OnClimbableExited?.Invoke();
            isTouchingClimbable = false;
        }
    }
}
