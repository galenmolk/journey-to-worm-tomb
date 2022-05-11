using System;
using UnityEngine;
using WormTomb.Environment;

namespace WormTomb.Player
{
    public class Respawn : MonoBehaviour
    {
        public delegate void DelegateRespawn();
        public static event DelegateRespawn OnRespawn;
        
        [SerializeField] private Checkpoint startingSpawn;

        public void GoToSpawn()
        {
            Debug.Log("Respawn");
            var checkpoint = Checkpoint.CurrentCheckpoint ? Checkpoint.CurrentCheckpoint : startingSpawn;
            transform.position = checkpoint.transform.position;
            OnRespawn?.Invoke();
        }

        private void OnDestroy()
        {
            OnRespawn = null;
        }
    }
}
