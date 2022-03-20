using System.Collections;
using System.Collections.Generic;
using Pathfinding;

namespace WormTomb
{
    public static class SeekerManager
    {
        private static readonly Dictionary<Seeker, SeekerProperties> SeekerPropertyRegistry = new();

        public static void StartSeeking(Seeker seeker, SeekerProperties properties)
        {
            if (!SeekerPropertyRegistry.TryAdd(seeker, properties))
                return;
            
            properties.SeekerCoroutine = seeker.StartCoroutine(UpdatePath(seeker, properties));
        }

        public static void StopSeeking(Seeker seeker)
        {
            if (!SeekerPropertyRegistry.ContainsKey(seeker))
                return;

            seeker.StopCoroutine(SeekerPropertyRegistry[seeker].SeekerCoroutine);
            SeekerPropertyRegistry.Remove(seeker);
        }

        private static IEnumerator UpdatePath(Seeker seeker, SeekerProperties properties)
        {
            while (properties.IsSeeking)
            {
                if (seeker.IsDone())
                    seeker.StartPath(properties.RB.Position, properties.Target.position, properties.OnPathDelegate);

                yield return YieldRegistry.WaitForSeconds(properties.RepeatRate);
            }
        }
    }
}
