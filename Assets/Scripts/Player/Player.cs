using UnityEngine;
using UnityEngine.Events;

namespace WormTomb
{
    public class Player : Singleton<Player>
    {
        private const string PLAYER_LAYER_NAME = "Player";

        public UnityEvent OnDie = new();

        public int PlayerLayer { get; private set; }

        public RigidbodyController RB => rigidbodyController;

        [SerializeField] private RigidbodyController rigidbodyController;

        private void Awake()
        {
            PlayerLayer = LayerMask.NameToLayer(PLAYER_LAYER_NAME);
        }
    }
}
