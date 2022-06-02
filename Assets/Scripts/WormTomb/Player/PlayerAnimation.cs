using System;
using UnityEngine;
using WormTomb.Animation;

namespace WormTomb
{
    public class PlayerAnimation : SpriteAnimator
    {
        [SerializeField] private SpriteState run;

        private void Start()
        {
            Enter(run);
        }

        private void OnEnable()
        {
            Player.Instance.RB.OnHorizontalVelocityChanged += HandleHorizontalVelocityChanged;
            Player.Instance.GroundCheck.GroundStateChanged.AddListener(OnGroundStateChanged);
        }

        private void OnDisable()
        {
            Player.Instance.RB.OnHorizontalVelocityChanged -= HandleHorizontalVelocityChanged;
        }

        private void OnGroundStateChanged(bool isTouchingGround)
        {
            if (!isTouchingGround)
                Pause();
            else if (Player.Instance.HasXVelocity)
                Resume();
        }
        
        private void HandleHorizontalVelocityChanged(float x)
        {
            if (Mathf.Abs(x) > 0f && Player.Instance.GroundCheck.IsTouchingGround())
                Resume();
            else
                Pause();
        }
    }
}
