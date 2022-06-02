using MolkExtras;
using UnityEngine;
using UnityEngine.Events;

namespace WormTomb.General
{
    [RequireComponent(typeof(Collider2D))]
    public class Trigger : MonoBehaviour
    {
        [SerializeField] protected bool allowMultipleTriggers = false;
        [SerializeField] private bool hideGraphics = true;

        [SerializeField] private Collider2D coll;

        [SerializeField] private UnityEvent triggerEntered;

        [SerializeField, Min(0f)] private float triggerDelay = 0f;
        
        private void Awake()
        {
            if (hideGraphics)
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

            if (!allowMultipleTriggers)
                coll.enabled = false;

            if (triggerDelay == 0)
                TriggerEntered();
            else
                this.ExecuteAfterDelay(triggerDelay, TriggerEntered);
        }

        protected virtual void TriggerEntered()
        {
            triggerEntered?.Invoke();
        }
    }
}
