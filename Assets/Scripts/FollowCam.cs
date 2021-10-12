using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(Camera))]
    public class FollowCam : MonoBehaviour
    {
        [SerializeField] private Transform targetTransform;
        [SerializeField] private Vector2 offset = Vector2.zero;

        private float defaultZ;

        private void Awake()
        {
            defaultZ = transform.position.z;
        }

        private void Update()
        {
            var targetX = targetTransform.position.x;
            transform.position = new Vector3(targetX + offset.x, offset.y, defaultZ);
        }
    }
}
