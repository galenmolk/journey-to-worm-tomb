using System;
using UnityEngine;
namespace WormTomb
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private void Awake()
        {
            animator.speed = 0;
        }

        private void OnEnable()
        {
            PlayerInput.Instance.onHorizontalInput.AddListener(SetAnimationSpeed);
        }

        private void SetAnimationSpeed(float runInput)
        {
            animator.speed = Mathf.Abs(runInput);
        }
    }
}
