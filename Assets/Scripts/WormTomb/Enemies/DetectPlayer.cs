using UnityEngine.Events;

namespace WormTomb
{
    public class DetectPlayer : Trigger
    {
        public UnityEvent PlayerDetected = new UnityEvent();

        protected override void TriggerEntered()
        {
            PlayerDetected.Invoke();
        }
    }
}
