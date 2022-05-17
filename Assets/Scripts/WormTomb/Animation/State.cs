using UnityEngine;

namespace WormTomb.Animation
{
    public abstract class State<TFrame, TValue> : ScriptableObject where TFrame : Frame<TValue>
    {
        protected const string MENU = "Custom/Animation/State/";

        public TFrame[] Frames => frames;
        [SerializeField] private TFrame[] frames;
    }
}
