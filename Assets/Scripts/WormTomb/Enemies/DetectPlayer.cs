using UnityEngine.Events;
using WormTomb.General;

namespace WormTomb.Enemies
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
