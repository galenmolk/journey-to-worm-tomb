using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowCam : MonoBehaviour
{
    [SerializeField] private Transform targetTransform = null;

    private Camera cam;
    private float defaultZ;

    private void Awake()
    {
        CacheReferences();
        defaultZ = transform.position.z;
    }

    private void CacheReferences()
    {
        cam = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 targetPos = targetTransform.position;
        transform.position = new Vector3(targetPos.x, targetPos.y, defaultZ);
    }
}
