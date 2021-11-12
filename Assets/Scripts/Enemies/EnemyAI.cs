using Pathfinding;
using UnityEngine;

namespace WormTomb
{
    public class EnemyAI : MonoBehaviour
    {
        [SerializeField] private Seeker seeker;
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Animator animator;

        [SerializeField] private RigidbodyController rigidbodyController;

        [SerializeField] private float speed = 200f;
        [SerializeField] private float nextWaypointDistance = 3f;

        private Path path;

        private int currentWaypoint;
        private bool hasReachedEndOfPath;

        private void Start()
        {
            InvokeRepeating(nameof(UpdatePath), 0f, 0.5f);
        }

        private void UpdatePath()
        {
            if (!seeker.IsDone())
                return;

            seeker.StartPath(rb.position, Player.Instance.transform.position, OnPathComplete);
        }

        private void FixedUpdate()
        {
            if (path == null)
                return;

            hasReachedEndOfPath = currentWaypoint >= path.vectorPath.Count;

            if (hasReachedEndOfPath)
                return;

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
            Vector2 force = direction * speed * Time.deltaTime;

            rb.AddForce(force);

            float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if (distance < nextWaypointDistance)
                currentWaypoint++;

            Vector2 velocity = rb.velocity;

            bool isMoving = Mathf.Abs(velocity.x) > 0.4f;
            animator.speed = isMoving ? 1f : 0f;

            if (isMoving)
                spriteRenderer.flipX = Mathf.Sign(velocity.x) == -1f;
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
