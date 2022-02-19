using UnityEngine;

namespace WormTomb
{
    public class Player : Singleton<Player>
    {
        private const string PLAYER_LAYER_NAME = "Player";
        
        public int PlayerLayer { get; private set; }

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
        
        private void Awake()
        {
            PlayerLayer = LayerMask.NameToLayer(PLAYER_LAYER_NAME);
        }
    }
}
