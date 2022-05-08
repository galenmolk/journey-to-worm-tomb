using Pathfinding;
using UnityEngine;

namespace WormTomb
{
    public class SeekerProperties
    {
        public SeekerProperties(RigidbodyController rb, Transform target, OnPathDelegate onPathReadyDelegate, float repeatRate)
        {
            RB = rb;
            Target = target;
            OnPathReadyDelegate = onPathReadyDelegate;
            RepeatRate = repeatRate;
        }
        
        public RigidbodyController RB;
        public Transform Target;
        public OnPathDelegate OnPathReadyDelegate;
        public float RepeatRate;
        public Coroutine SeekerCoroutine;
        public bool IsSeeking = true;
    }
}
