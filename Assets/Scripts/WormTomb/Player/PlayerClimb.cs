using System.Collections;
using UnityEngine;
using WormTomb.Environment;
using WormTomb.UI;

namespace WormTomb
{
    public class PlayerClimb : MonoBehaviour
    {
        public static bool IsTouchingClimbable { get; private set; }

        [SerializeField] private float climbSpeed;

        private bool isClimbing;

        private void OnEnable()
        {
            PlayerInput.Instance.joystickUp.AddListener(() => StartClimbing(climbSpeed));
            PlayerInput.Instance.joystickDown.AddListener(() => StartClimbing(-climbSpeed));
            PlayerInput.Instance.joystickCenterY.AddListener(OnJoystickCenterY);
        }

        private void StartClimbing(float velocity)
        {
            if (!IsTouchingClimbable)
                return;

            isClimbing = true;
            StartCoroutine(ClimbContinuously(velocity));
        }

        private void OnJoystickCenterY()
        {
            if (!IsTouchingClimbable)
                return;
            
            isClimbing = false;
            Player.Instance.RB.SetVerticalVelocity(0f);
        }

        private IEnumerator ClimbContinuously(float velocity)
        {
            while (isClimbing && IsTouchingClimbable)
            {
                Player.Instance.RB.SetVerticalVelocity(velocity);
                yield return null;
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out IClimbable _))
                SetIsTouchingClimbable(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out IClimbable _))
                SetIsTouchingClimbable(false);
        }

        private void SetIsTouchingClimbable(bool isTouchingClimbable)
        {
            Player.Instance.RB.SetVerticalVelocity(0f);
            IsTouchingClimbable = isTouchingClimbable;
            Player.Instance.RB.SetIsObeyingGravity(!isTouchingClimbable);
        }
    }
}
