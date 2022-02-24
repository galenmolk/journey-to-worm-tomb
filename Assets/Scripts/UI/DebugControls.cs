using UnityEngine;

namespace WormTomb
{
    public class DebugControls : Singleton<DebugControls>
    {
        private void Update()
        {
            Run();
            Jump();
            Attack();
        }

        private void Run()
        {
            if (Input.GetKeyDown(KeyCode.A))
                PlayerInput.Instance.RunningLeft.Invoke();

            if (Input.GetKeyDown(KeyCode.D))
                PlayerInput.Instance.RunningRight.Invoke();

            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
                PlayerInput.Instance.RunningStop.Invoke();
        }

        private void Jump()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                PlayerInput.Instance.Jump.Invoke();
        }

        private void Attack()
        {
            if (Input.GetKeyDown(KeyCode.K))
                PlayerInput.Instance.Attack.Invoke();
        }
    }
}
