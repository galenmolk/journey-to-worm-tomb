using UnityEngine;

namespace WormTomb.Utils
{
    public static class VectorExtensions
    {
        public static bool WithinRangeOfPlayer(this Vector2 position, float range)
        {
            if (Player.Instance == null)
            {
                Debug.LogWarning("No Player in scene.");
                return false;
            }
            
            var distance = ((Vector2)Player.Instance.Transform.position - position).sqrMagnitude;
            return distance <= range * range;
        }
    }
}
    