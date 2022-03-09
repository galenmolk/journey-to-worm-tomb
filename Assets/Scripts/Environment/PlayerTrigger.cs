using UnityEngine;
using UnityEngine.Events;

namespace WormTomb
{
    [RequireComponent(typeof(Collider2D))]
    public class PlayerTrigger : MonoBehaviour
    {
        public UnityEvent OnPlayerTriggered = new UnityEvent();

        public void SetIsEnabled(bool isEnabled)
        {
            col.enabled = isEnabled;
        }
        
        [SerializeField] private bool isOneShot = true;
        
        private Collider2D col;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer != Player.Instance.PlayerLayer)
                return;

            Triggered();
            
            if (isOneShot)
                SetIsEnabled(false);
        }

        protected virtual void Triggered()
        {
            OnPlayerTriggered.Invoke();
        }

        private void Awake()
        {
            col = GetComponent<Collider2D>();
            col.isTrigger = true;
        }
    }
}
