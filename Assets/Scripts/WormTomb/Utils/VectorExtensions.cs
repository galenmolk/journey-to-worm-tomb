using UnityEngine;

namespace WormTomb.Utils
{
    public static class VectorExtensions
    {
        public static bool WithinRangeOfPlayer(this Vector3 position, float range)
        {
            var distance = ((Vector2)Player.Player.Instance.Transform.position - (Vector2)position).sqrMagnitude;
            return distance <= range * range;
        }
        
        public static bool WithinRangeOfPlayer(this Vector2 position, float range)
        {
            var distance = ((Vector2)Player.Player.Instance.Transform.position - position).sqrMagnitude;
            return distance <= range * range;
        }
    }
}
