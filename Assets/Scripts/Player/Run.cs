using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Run : MonoBehaviour
    {
        [SerializeField] private float runSpeed;

        private void OnEnable()
        {
            PlayerInput.Instance.joystickLeft.AddListener(OnRunningLeft);
            PlayerInput.Instance.joystickRight.AddListener(OnRunningRight);
            PlayerInput.Instance.joystickCenter.AddListener(OnRunningStop);
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
            while (PlayerInput.Instance.IsJoystickLeft)
            {
                Player.Instance.RB.SetHorizontalVelocity(-runSpeed);
                yield return null;
            }
        }

        private IEnumerator RunRightContinuously()
        {
            while (PlayerInput.Instance.IsJoystickRight)
            {
                Player.Instance.RB.SetHorizontalVelocity(runSpeed);
                yield return null;
            }
        }
    }
}
