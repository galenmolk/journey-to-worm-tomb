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
            Player.Instance.RB.SetHorizontalVelocity(0f);
        }

        private IEnumerator RunLeftContinuously()
        {
            while (PlayerInput.Instance.IsLeftButtonPressed)
            {
                Player.Instance.RB.SetHorizontalVelocity(-runSpeed);
                yield return null;
            }
        }

        private IEnumerator RunRightContinuously()
        {
            while (PlayerInput.Instance.IsRightButtonPressed)
            {
                Player.Instance.RB.SetHorizontalVelocity(runSpeed);
                yield return null;
            }
        }
    }
}
