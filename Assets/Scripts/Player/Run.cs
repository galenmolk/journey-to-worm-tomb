using UnityEngine;

namespace WormTomb
{
    public class Run : MonoBehaviour
    {
        [SerializeField] private float runSpeed;

        private void OnEnable()
        {
            PlayerInput.Instance.RunningLeft.AddListener(OnRunningLeft);
            PlayerInput.Instance.RunningRight.AddListener(OnRunningRight);
            PlayerInput.Instance.RunningStop.AddListener(OnRunningStop);
        }

        private void OnRunningLeft()
        {
            PlayerRigidbody.Instance.SetVelocityX(-runSpeed);
        }

        private void OnRunningRight()
        {
            PlayerRigidbody.Instance.SetVelocityX(runSpeed);
        }

        private void OnRunningStop()
        {
            PlayerRigidbody.Instance.SetVelocityX(0f);
        }
    }
}
