using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Trigger : MonoBehaviour
    {
        [SerializeField] private bool disableOnPlayerEnter = false;

        [SerializeField] private Collider2D collider2D;

        private void Awake()
        {
            if (collider2D == null)
            {
                Debug.LogWarning($"Trigger.Awake on {gameObject.name}: collider2D not assigned in inspector.");
                collider2D = GetComponent<Collider2D>();
            }

            if (collider2D == null)
            {
                Debug.LogError($"Trigger.Awake on {gameObject.name}: no Collider2D component found on GameObject!");
                return;
            }

            collider2D.isTrigger = true;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != Player.Instance.PlayerLayer)
                return;

            TriggerEntered();

            if (disableOnPlayerEnter)
                collider2D.enabled = false;
        }

        protected abstract void TriggerEntered();
    }
}
