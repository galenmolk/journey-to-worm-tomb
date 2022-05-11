using UnityEngine;
using WormTomb.General;

namespace WormTomb.Player
{
    [RequireComponent(typeof(PlayerHealth))]
    public class Player : Singleton<Player>
    {
        private const string PlayerLayerName = "Player";
        
        public int PlayerLayer { get; private set; }

        public int StartingHealth => PlayerHealth.StartingHealth;
        
        public RigidbodyController RB => rigidbodyController;
        [SerializeField] private RigidbodyController rigidbodyController;

        public Transform Transform
        {
            get
            {
                if (t == null)
                    t = transform;

                return t;
            }
        }

        private Transform t;

        private PlayerHealth PlayerHealth
        {
            get
            {
                if (playerHealth == null)
                    playerHealth = GetComponent<PlayerHealth>();

                return playerHealth;
            }
        }
        
        private PlayerHealth playerHealth;
        
        private void Awake()
        {
            PlayerLayer = LayerMask.NameToLayer(PlayerLayerName);
        }
    }
}
