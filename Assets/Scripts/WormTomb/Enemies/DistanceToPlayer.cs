using UnityEngine;
using WormTomb.General;
using WormTomb.Utils;

namespace WormTomb.Enemies
{
    public class DistanceToPlayer : MonoBehaviour, IUpdatable
    {
        public float Distance { get; private set; }

        private Transform _transform;

        private Transform Transform
        {
            get
            {
                if (_transform == null)
                    _transform = transform;

                return _transform;
            }
        }

        public bool AlwaysUpdate => false;
        public IUpdatable.Type UpdateType { get; }

        public void StartTracking()
        {
            UpdateManager.AddUpdatable(this);
        }

        public void StopTracking()
        {
            UpdateManager.RemoveUpdatable(this);
        }
        
        public void ExecuteUpdate()
        {
            if (Player.Instance == null)
            {
                StopTracking();
                return;                
            }

            Distance = Vector2.Distance(Transform.position, Player.Instance.Transform.position);
        }

        private void OnDisable()
        {
            StopTracking();
        }
    }
}
