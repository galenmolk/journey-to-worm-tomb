using UnityEngine;

namespace WormTomb.Enemies
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ImmovableByPlayer : MonoBehaviour
    {
        [SerializeField] private RigidbodyConstraints2D defaultConstraints = RigidbodyConstraints2D.FreezeRotation;
        
        private Rigidbody2D _rigidbody2D;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.layer == Player.Player.Instance.PlayerLayer)
                _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        private void OnCollisionExit2D(Collision2D col)
        {
            if (col.gameObject.layer == Player.Player.Instance.PlayerLayer)
                _rigidbody2D.constraints = defaultConstraints;
        }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
    }
}
