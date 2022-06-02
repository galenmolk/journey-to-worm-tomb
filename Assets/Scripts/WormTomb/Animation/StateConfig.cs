using System;
using UnityEngine;

namespace WormTomb.Animation
{
    [Serializable]
    public class StateConfig<TState, TFrame, TValue>
    where TState : State<TFrame, TValue>
    where TFrame : Frame<TValue>
    {
        [SerializeField, Min(0f)] private float frameDelay;
        [SerializeField] private TState state;
    }
}
