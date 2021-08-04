using UnityEngine;

public class BreakableWall : MonoBehaviour, IDamageable
{
    public void TakeDamage()
    {
        Destroy(gameObject);
    }
}
