using UnityEngine;

namespace WormTomb.Animation
{
    public abstract class State<TFrame, TValue> : ScriptableObject where TFrame : Frame<TValue>
    {
        protected const string MENU = "Custom/Animation/State/";

        public Coroutine Routine { get; set; }
        
        [SerializeField] private TFrame[] frames;
        [SerializeField] private bool loop;
        
        private int frameIndex = -1;
        
        public bool CanAdvanceFrame()
        {
            return loop || frameIndex < frames.Length - 1;
        }
        
        public TFrame AdvanceFrame()
        {
            if (loop && frameIndex == frames.Length - 1)
                frameIndex = 0;
            else
                frameIndex++;
                
            return frames[frameIndex];
        }

        public void ResetState()
        {
            frameIndex = -1;
            Routine = null;
        }
    }
}
