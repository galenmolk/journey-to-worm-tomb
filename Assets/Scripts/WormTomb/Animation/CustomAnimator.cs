using UnityEngine;

namespace WormTomb.Animation
{
    public abstract class CustomAnimator<TState, TFrame, TValue> : MonoBehaviour 
        where TState : State<TFrame, TValue>
        where TFrame : Frame<TValue>
    {
        [SerializeField] protected TState[] states;
    }
}
