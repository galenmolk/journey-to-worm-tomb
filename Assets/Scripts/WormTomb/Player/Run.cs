using System.Collections;
using UnityEngine;

namespace WormTomb
{
    public class Run : MonoBehaviour
    {
        [SerializeField] private float runSpeed;

        private bool isRunning;
        
        private void OnEnable()
        {
            PlayerInput.Instance.joystickLeft.AddListener(() => StartRunning(-runSpeed));
            PlayerInput.Instance.joystickRight.AddListener(() => StartRunning(runSpeed));
            PlayerInput.Instance.joystickCenterX.AddListener(OnRunningStop);
        }

        private void StartRunning(float velocity)
        {
            isRunning = true;
            StartCoroutine(RunContinuously(velocity));
        }

        private void OnRunningStop()
        {
            isRunning = false;
            Player.Instance.RB.SetHorizontalVelocity(0f);
        }

        private IEnumerator RunContinuously(float velocity)
        {
            while (isRunning)
            {
                Player.Instance.RB.SetHorizontalVelocity(velocity);
                yield return null;
            }
        }
    }
}
