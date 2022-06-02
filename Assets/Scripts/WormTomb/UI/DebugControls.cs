using MolkExtras;
using UnityEngine;

namespace WormTomb.UI
{
    public class DebugControls : Singleton<DebugControls>
    {
        private void Update()
        {
            Run();
            Jump();
            Action();
        }

        private void Run()
        {
            if (Input.GetKeyDown(KeyCode.A))
                PlayerInput.Instance.joystickLeft.Invoke();

            if (Input.GetKeyDown(KeyCode.D))
                PlayerInput.Instance.joystickRight.Invoke();

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                PlayerInput.Instance.joystickCenterX.Invoke();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                PlayerInput.Instance.joystickUp.Invoke();
        }

        private void Action()
        {
            if (Input.GetKeyDown(KeyCode.F))
                PlayerInput.Instance.playerAction.Invoke();
        }
    }
}
