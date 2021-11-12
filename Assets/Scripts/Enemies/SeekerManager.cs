using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

namespace WormTomb
{
    public static class SeekerManager
    {
        private struct SeekerProperties
        {
            public RigidbodyController rb;
            public Transform target;
            public OnPathDelegate onPathDelegate;
            public float repeatRate;
            public Coroutine seekerCoroutine;
            public bool isSeeking;
        }

        private static readonly Dictionary<Seeker, SeekerProperties> seekerPropertyRegistry = new Dictionary<Seeker, SeekerProperties>();

        public static void StartSeeking(Seeker seeker, RigidbodyController _rb, Transform _target, OnPathDelegate _onPathDelegate, float _repeatRate)
        {
            bool isSeekerActive = seekerPropertyRegistry.TryGetValue(seeker, out SeekerProperties properties);

            if (isSeekerActive)
                seeker.StopCoroutine(properties.seekerCoroutine);
            
            properties = new SeekerProperties()
            {
                rb = _rb,
                target = _target,
                onPathDelegate = _onPathDelegate,
                repeatRate = _repeatRate,
                isSeeking = true
            };

            if (!isSeekerActive)
                seekerPropertyRegistry.Add(seeker, properties);

            seeker.StartCoroutine(UpdatePath(seeker, properties));
        }

        private static IEnumerator UpdatePath(Seeker seeker, SeekerProperties properties)
        {
            while (properties.isSeeking)
            {
                if (seeker.IsDone())
                    seeker.StartPath(properties.rb.Position, properties.target.position, properties.onPathDelegate);

                yield return YieldRegistry.Wait(properties.repeatRate);
            }
        }
    }
}
