using UnityEngine;
using WormTomb.Combat;

namespace WormTomb.Environment
{
    public class Hazard : MonoBehaviour
    {
        [SerializeField] private int damageAmount = 0;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log(collision.gameObject.name);
            collision.gameObject.GetComponent<IDamageable>()?.TakeDamage(damageAmount);
        }
    }
}
