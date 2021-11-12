using Pathfinding;
using UnityEngine;

namespace WormTomb
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Seeker seeker;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;

        [SerializeField] private RigidbodyController rigidbodyController;
        [SerializeField] private DetectPlayer detectPlayer;

        [SerializeField] private float speed = 200f;
        [SerializeField] private float nextWaypointDistance = 3f;

        private Path path;

        private int currentWaypoint;
        private bool hasReachedEndOfPath;

        private void Awake()
        {
            detectPlayer.PlayerDetected.AddListener(OnPlayerDetected);
            animator.speed = 0f;
        }

        private void OnPlayerDetected()
        {
            SeekerManager.StartSeeking(seeker, rigidbodyController, Player.Instance.transform, OnPathComplete, 0.5f);
        }

        private void FixedUpdate()
        {
            if (path == null)
                return;

            hasReachedEndOfPath = currentWaypoint >= path.vectorPath.Count;

            if (hasReachedEndOfPath)
                return;

            Vector2 position = rigidbodyController.Position;
            Vector2 waypointPosition = path.vectorPath[currentWaypoint];

            int directionSign = (position.x < waypointPosition.x).ToSign();

            rigidbodyController.SetHorizontalVelocity(speed * directionSign);

            float distance = Vector2.Distance(position, waypointPosition);

            if (distance < nextWaypointDistance)
                currentWaypoint++;

            float velocityX = rigidbodyController.VelocityX;

            bool isMoving = Mathf.Abs(velocityX) > 0.1f;
            animator.speed = isMoving.ToInt();

            if (isMoving)
                spriteRenderer.flipX = Mathf.Sign(velocityX) == -1f;
        }

        private void OnPathComplete(Path _path)
        {
            if (_path.error)
                return;

            path = _path;
            currentWaypoint = 0;
        }
    }
}
