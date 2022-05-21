using UnityEngine;
using WormTomb.Animation;

namespace WormTomb.Player
{
    public class PlayerAnimationNew : SpriteAnimator
    {
        [SerializeField] private SpriteState run;

        private void Start()
        {
            Enter(run);
        }

        private void OnEnable()
        {
            Player.Instance.RB.OnVelocityChanged.AddListener(OnVelocityChanged);
            Player.Instance.GroundCheck.GroundStateChanged.AddListener(OnGroundStateChanged);
        }

        private void OnGroundStateChanged(bool isTouchingGround)
        {
            if (!isTouchingGround)
                Pause();
            else if (Mathf.Abs(Player.Instance.RB.VelocityX) > 0f)
                Resume();
        }
        
        private void OnVelocityChanged(Vector2 velocity)
        {
            var isRunning = Mathf.Abs(velocity.x) > 0f;
            if (isRunning && Player.Instance.GroundCheck.IsTouchingGround())
                Resume();
            else
                Pause();
        }
        
        // [ContextMenu("Play")]
        // public void StartRunning()
        // {
        //     Play(run);
        // }
        //
        // [ContextMenu("DoPause")]
        // public void DoPause()
        // {
        //     Pause();
        // }
        //
        // [ContextMenu("DoResume")]
        // public void DoResume()
        // {
        //     Resume();
        // }
        //
        //
        // [ContextMenu("DoStop")]
        // public void DoStop()
        // {
        //     Stop();
        // }
        //
        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.UpArrow))
        //         Play(run);
        //     
        //     if (Input.GetKeyDown(KeyCode.DownArrow))
        //         Stop();
        //         
        //     if (Input.GetKeyDown(KeyCode.LeftArrow))
        //         Pause();
        //         
        //     if (Input.GetKeyDown(KeyCode.RightArrow))
        //         Resume();
        // }
    }
}
