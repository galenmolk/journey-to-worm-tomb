using System.Collections;
using Pathfinding;
using UnityEngine;
using UnityEngine.Events;
using WormTomb.Enemies.Pathfinding;
using WormTomb.General;
using WormTomb.Utils;

namespace WormTomb.Enemies
{
    [RequireComponent(typeof(Seeker))]
    [RequireComponent(typeof(RigidbodyController))]
    public class MoveTowardsPlayer : MonoBehaviour, IUpdatable
    {
        public bool AlwaysUpdate => false;
        public IUpdatable.Type UpdateType { get; }

        [SerializeField] private UnityEvent OnPlayerInRange = new UnityEvent();
        [SerializeField] private UnityEvent OnPlayerOutOfRange = new UnityEvent();
        
        [Tooltip("Lower number: sluggish response to player movement. 0.1 will cause lag!")]
        [SerializeField, Min(0.1f)] private float pathRepeatRate;
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
            UpdateManager.AddUpdatable(this);
        }

        public void StopPursuing()
        {
            UpdateManager.RemoveUpdatable(this);
            isPursuing = false;
            SeekerManager.StopSeeking(seeker);
        }

        private IEnumerator PursueContinuously()
        {
            while (isPursuing)
            {
                if (ReachedEndOfPath() || ReachedPlayer())
                {
                    if (Mathf.Abs(rigidbodyController.VelocityX) > 0f)
                            rigidbodyController.SetHorizontalVelocity(0f);
                    
                    yield return YieldRegistry.waitForFixedUpdate;
                    continue;
                }
                
                MoveTowards();
                yield return YieldRegistry.waitForFixedUpdate;
            }
        }

        private bool ReachedPlayer()
        {
            return rigidbodyController.Position.WithinRangeOfPlayer(stoppingDistance);
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
            properties = new SeekerProperties(rigidbodyController, Player.Instance.Transform, OnPathReady, pathRepeatRate);
        }

        private void CacheComponents()
        {
            seeker = GetComponent<Seeker>();
            rigidbodyController = GetComponent<RigidbodyController>();
        }

        public void ExecuteUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}
