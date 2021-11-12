using UnityEngine;

namespace WormTomb
{
    public class Player : Singleton<Player>
    {
        private const string PLAYER_LAYER_NAME = "Player";

        public int PlayerLayer { get { return playerLayer; } }

        public RigidbodyController RB { get { return rigidbodyController; } }

        [SerializeField] private RigidbodyController rigidbodyController;

        private int playerLayer;

        private void Awake()
        {
            playerLayer = LayerMask.NameToLayer(PLAYER_LAYER_NAME);
        }
    }
}
