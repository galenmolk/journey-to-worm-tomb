using UnityEngine;

namespace WormTomb
{
    public class Respawn : MonoBehaviour
    {
        [SerializeField] private Checkpoint startingSpawn;

        public void GoToSpawn()
        {
            Debug.Log("Respawn");
            Checkpoint checkpoint = Checkpoint.CurrentCheckpoint ?? startingSpawn;
            transform.position = checkpoint.transform.position;
        }
    }
}
