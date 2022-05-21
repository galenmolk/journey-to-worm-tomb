using System.Collections;
using UnityEngine;
using WormTomb.General;

namespace WormTomb.Animation
{
    public abstract class CustomAnimator<TState, TFrame, TValue> : MonoBehaviour 
        where TState : State<TFrame, TValue>
        where TFrame : Frame<TValue>
    {
        [SerializeField, Min(0f)] protected float frameDelay = 0.2f;

        private TState activeState;

        public void Enter(TState state)
        {
            Stop();
            activeState = state;
            activeState.ResetState();
            ApplyFrame(activeState.AdvanceFrame());
        }
        
        public void Play(TState state)
        {
            Stop();
            activeState = state;
            activeState.ResetState();
            activeState.Routine = StartCoroutine(Animate());
        }
        
        public void Stop()
        {
            if (activeState == null)
                return;
            
            StopCoroutine(activeState.Routine);
            activeState.ResetState();
            activeState = null;
        }
        
        public void Resume()
        {
            if (activeState != null && activeState.Routine == null) 
                activeState.Routine = StartCoroutine(Animate());
        }
        
        public void Pause()
        {
            if (activeState == null || activeState.Routine == null) 
                return;
            
            StopCoroutine(activeState.Routine);
            activeState.Routine = null;
        }

        private IEnumerator Animate()
        {
            while (activeState.CanAdvanceFrame() && activeState != null)
            {
                ApplyFrame(activeState.AdvanceFrame());
                yield return YieldRegistry.WaitForSeconds(frameDelay);
            }

            Stop();
        }

        protected abstract void ApplyFrame(TFrame frame);
    }
}
