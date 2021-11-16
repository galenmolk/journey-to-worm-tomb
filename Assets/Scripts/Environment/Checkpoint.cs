using UnityEngine;

namespace WormTomb
{
    public class Checkpoint : Trigger
    {
        public static Checkpoint CurrentCheckpoint { get; private set; }

        protected override void TriggerEntered()
        {
            Debug.Log("Current Checkpoint: " + gameObject.name);
            CurrentCheckpoint = this;
        }

        private void Start()
        {
            allowMultipleTriggers = false;
        }
    }
}
