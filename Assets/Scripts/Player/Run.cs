using System.Collections;
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
            StartCoroutine(RunLeftContinuously());
        }

        private void OnRunningRight()
        {
            StartCoroutine(RunRightContinuously());
        }

        private void OnRunningStop()
        {
            PlayerRigidbody.Instance.SetVelocityX(0f);
        }

        private IEnumerator RunLeftContinuously()
        {
            while (PlayerInput.Instance.IsLeftButtonPressed)
            {
                PlayerRigidbody.Instance.SetVelocityX(-runSpeed);
                yield return null;
            }
        }

        private IEnumerator RunRightContinuously()
        {
            while (PlayerInput.Instance.IsRightButtonPressed)
            {
                PlayerRigidbody.Instance.SetVelocityX(runSpeed);
                yield return null;
            }
        }
    }
}
