using System;
using UnityEngine;

namespace WormTomb
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Awake()
        {
            SetIsRunning(false);
        }

        private void OnEnable()
        {
            PlayerInput.Instance.RunningLeft.AddListener(() => SetIsRunning(true));
            PlayerInput.Instance.RunningRight.AddListener(() => SetIsRunning(true));
            PlayerInput.Instance.RunningStop.AddListener(() => SetIsRunning(false));
        }

        private void SetIsRunning(bool isRunning)
        {
            if (Math.Abs(PlayerRigidbody.Instance.VelocityX) > 0f)
                isRunning = true;

            animator.speed = isRunning ? 1f : 0f;
        }
    }
}
