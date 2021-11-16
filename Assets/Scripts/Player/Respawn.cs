using UnityEngine;

namespace WormTomb
{
    public class Respawn : MonoBehaviour
    {
        [SerializeField] private Checkpoint startingSpawn;

        private void Awake()
        {
            Player.Instance.OnDie.AddListener(GoToSpawn);
        }

        private void GoToSpawn()
        {
            Debug.Log("BeginRespawn");
            Checkpoint checkpoint = Checkpoint.CurrentCheckpoint ?? startingSpawn;
            transform.position = checkpoint.transform.position;
        }
    }
}
