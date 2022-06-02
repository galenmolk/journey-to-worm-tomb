using UnityEngine;

namespace WormTomb.Animation
{
    public abstract class State<TFrame, TValue> : ScriptableObject where TFrame : Frame<TValue>
    {
        protected const string MENU = "Custom/Animation/State/";

        public bool IsPlaying { get; set; }

        public Coroutine Routine { get; set; }

        public float FrameDelay => frameDelay;

        public int Id
        {
            get
            {
                if (id == 0)
                    id = GetInstanceID();

                return id;
            }
        }

        private int id;
        
        [SerializeField] private TFrame[] frames;
        [SerializeField] private bool loop;
        [SerializeField] private float frameDelay;
        
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
