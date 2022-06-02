using UnityEngine.Events;
using WormTomb.General;

namespace WormTomb.Environment
{
    public class PickUp : Trigger
    {
        public UnityEvent OnPickUp = new UnityEvent();

        protected override void TriggerEntered()
        {
            base.TriggerEntered();
        }
    }
}
