using System.Collections;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;

namespace WormTomb
{
    [RequireComponent(typeof(Seeker))]
    [RequireComponent(typeof(RigidbodyController))]
    public class MoveTowardsPlayer : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnPlayerInRange = new UnityEvent();
        [SerializeField] private UnityEvent OnPlayerOutOfRange = new UnityEvent();
        
        [SerializeField] private float speed = 5;
        
        [Tooltip("Distance from waypoint in world units before targeting the next waypoint in path.")]
        [SerializeField] private float nextWaypointDistance = 3f;
        
        [Tooltip("Distance from target in world units to stop moving.")]
        [SerializeField] private float stoppingDistance = 3f;
        
        private Seeker seeker;
        private RigidbodyController rigidbodyController;
        private SeekerProperties properties;
        private Path path;
        private int currentWaypoint;
        private bool isPursuing;
        
        public void StartPursuing()
        {
            SeekerManager.StartSeeking(seeker, properties);
            isPursuing = true;
        }

        public void StopPursuing()
        {
            isPursuing = false;
            SeekerManager.StopSeeking(seeker);
        }

        private IEnumerator PursueContinuously()
        {
            while (isPursuing)
            {
                if (ReachedPlayer() || ReachedEndOfPath())
                {
                    rigidbodyController.SetHorizontalVelocity(0f);
                    yield return YieldRegistry.waitForFixedUpdate;
                    continue;
                }

                MoveTowards();
                yield return YieldRegistry.waitForFixedUpdate;
            }
        }

        private void MoveTowards()
        {
            Vector2 position = rigidbodyController.Position;
            Vector2 waypointPosition = path.vectorPath[currentWaypoint];
            var velocity = (position.x < waypointPosition.x).ToSign() * speed;
            rigidbodyController.SetHorizontalVelocity(velocity);
                
            if (Vector2.Distance(position, waypointPosition) < nextWaypointDistance)
                currentWaypoint++;
        }

        private bool ReachedPlayer()
        {
            bool hasReachedPlayer = Vector2.Distance(rigidbodyController.Position,  Player.Instance.Transform.position) < stoppingDistance;

            if (hasReachedPlayer)
                OnPlayerInRange.Invoke();
            else
                OnPlayerOutOfRange.Invoke();
            
            return hasReachedPlayer;
        }

        private bool ReachedEndOfPath()
        {
            return currentWaypoint >= path.vectorPath.Count;
        }
        
        private void OnPathReady(Path newPath)
        {
            path = newPath;
            StartCoroutine(PursueContinuously());
        }
        
        private void Awake()
        {
            CacheComponents();
            properties = new SeekerProperties(rigidbodyController, Player.Instance.Transform, OnPathReady, 0.5f);
        }

        private void CacheComponents()
        {
            seeker = GetComponent<Seeker>();
            rigidbodyController = GetComponent<RigidbodyController>();
        }
    }
}
