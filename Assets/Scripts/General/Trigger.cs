using UnityEngine;

namespace WormTomb
{
    [RequireComponent(typeof(Collider2D))]
    public abstract class Trigger : MonoBehaviour
    {
        [SerializeField] private bool disableOnPlayerEnter = false;

        [SerializeField] private Collider2D coll;

        private void Awake()
        {
            HideEditorGraphics();

            if (coll == null)
            {
                Debug.LogWarning($"Trigger.Awake on {gameObject.name}: collider2D not assigned in inspector.");
                coll = GetComponent<Collider2D>();
            }

            if (coll == null)
            {
                Debug.LogError($"Trigger.Awake on {gameObject.name}: no Collider2D component found on GameObject!");
                return;
            }

            coll.isTrigger = true;
        }

        private void HideEditorGraphics()
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
                spriteRenderer.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != Player.Instance.PlayerLayer)
                return;

            TriggerEntered();

            if (disableOnPlayerEnter)
                coll.enabled = false;
        }

        protected abstract void TriggerEntered();
    }
}
