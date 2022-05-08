using UnityEngine.Events;

namespace WormTomb
{
    public class PickUp : Trigger
    {
        public UnityEvent OnPickUp = new UnityEvent();

        protected override void TriggerEntered()
        {
            
        }
    }
}
