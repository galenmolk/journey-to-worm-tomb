using Pathfinding;
using UnityEngine;

namespace WormTomb
{
    public class SeekerProperties
    {
        public SeekerProperties(RigidbodyController rb, Transform target, OnPathDelegate onPathDelegate, float repeatRate)
        {
            RB = rb;
            Target = target;
            OnPathDelegate = onPathDelegate;
            RepeatRate = repeatRate;
        }
        
        public RigidbodyController RB;
        public Transform Target;
        public OnPathDelegate OnPathDelegate;
        public float RepeatRate;
        public Coroutine SeekerCoroutine;
        public bool IsSeeking = true;
    }
}
