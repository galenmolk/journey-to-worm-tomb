using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform targetTransform = null;
    [SerializeField] private Vector2 offset = Vector2.zero;

    private float defaultZ;

    private void Awake()
    {
        defaultZ = transform.position.z;
    }

    private void Update()
    {
        float targetX = targetTransform.position.x;
        Vector3 newPosition = new Vector3(targetX + offset.x, offset.y, defaultZ);
        transform.position = newPosition;
    }
}
