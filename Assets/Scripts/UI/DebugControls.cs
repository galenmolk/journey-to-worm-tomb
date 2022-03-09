using UnityEngine;

namespace WormTomb
{
    public class DebugControls : Singleton<DebugControls>
    {
        private void Update()
        {
            Run();
            Jump();
        }

        private void Run()
        {
            if (Input.GetKeyDown(KeyCode.A))
                PlayerInput.Instance.joystickLeft.Invoke();

            if (Input.GetKeyDown(KeyCode.D))
                PlayerInput.Instance.joystickRight.Invoke();

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                PlayerInput.Instance.joystickCenter.Invoke();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                PlayerInput.Instance.joystickUp.Invoke();
        }
    }
}
