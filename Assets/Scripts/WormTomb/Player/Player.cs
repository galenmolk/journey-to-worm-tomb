using MolkExtras;
using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(PlayerHealth))]
    [RequireComponent(typeof(GroundCheck))]
    public class Player : Singleton<Player>
    {
        private const string PlayerLayerName = "Player";
        
        public int PlayerLayer { get; private set; }

        public int StartingHealth => PlayerHealth.StartingHealth;

        public bool HasXVelocity => Mathf.Abs(rigidbodyController.VelocityX) > 0;
        
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

        public GroundCheck GroundCheck
        {
            get
            {
                if (groundCheck == null)
                    groundCheck = GetComponent<GroundCheck>();

                return groundCheck;
            }
        }

        private GroundCheck groundCheck;

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
