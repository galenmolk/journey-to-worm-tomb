using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using WormTomb.General;

namespace WormTomb.Animation
{
    public abstract class CustomAnimator<TState, TFrame, TValue> : MonoBehaviour 
        where TState : State<TFrame, TValue>
        where TFrame : Frame<TValue>
    {
        // [SerializeField, Min(0f)] protected float frameDelay = 0.2f;
        [SerializeField] private UnityEvent<TValue> onFrameApplied;
        
        [Tooltip("Optional: state to play on Awake.")]
        [SerializeField] private TState startingState;

        public int ActiveStateId => ActiveState != null ? ActiveState.Id : 0;
        
        public TState ActiveState { get; private set; }

        public void Enter(TState state)
        {
            Stop();
            ActiveState = state;
            ActiveState.ResetState();
            ApplyFrame(ActiveState.AdvanceFrame());
        }
        
        public void Play(TState state)
        {
            if (ActiveStateId == state.Id)
                return;

            Stop();
            ActiveState = state;
            ActiveState.ResetState();
            ActiveState.Routine = StartCoroutine(Animate());
        }
        
        public void Stop()
        {
            if (ActiveState == null || ActiveState.Routine == null)
                return;
            
            StopCoroutine(ActiveState.Routine);
            ActiveState.ResetState();
            ActiveState.IsPlaying = false;
            ActiveState = null;
        }
        
        public void Resume()
        {
            if (ActiveState != null && ActiveState.Routine == null) 
                ActiveState.Routine = StartCoroutine(Animate());
        }
        
        public void Pause()
        {
            if (ActiveState == null || ActiveState.Routine == null) 
                return;
            
            StopCoroutine(ActiveState.Routine);
            ActiveState.IsPlaying = false;
            ActiveState.Routine = null;
        }

        private IEnumerator Animate()
        {
            ActiveState.IsPlaying = true;
            
            while (ActiveState.CanAdvanceFrame() && ActiveState != null)
            {
                ApplyFrame(ActiveState.AdvanceFrame());
                yield return YieldRegistry.WaitForSeconds(ActiveState.FrameDelay);
            }

            Stop();
        }

        private void ApplyFrame(TFrame frame)
        {
            onFrameApplied?.Invoke(frame.Value);
        }

        private void Start()
        {
            if (startingState != null)
                Play(startingState);
        }
    }
}
