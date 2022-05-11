using UnityEngine;
using WormTomb.General;
using WormTomb.Utils;

namespace WormTomb
{
    public class ParticleController : Singleton<ParticleController>
    {
        [SerializeField] private GameObject attackParticle;

        public void SpawnAttackParticle(Vector2 position)
        {
            var part = Instantiate(attackParticle, position, Quaternion.identity);
            this.ExecuteAfterDelay(2f, () => { Destroy(part); });
        }
    }
}
