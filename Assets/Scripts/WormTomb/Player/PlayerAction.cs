using UnityEngine;

namespace WormTomb
{
    public class PlayerAction : MonoBehaviour
    {
        [SerializeField] private Attack attack;
        [SerializeField] private PlayerInteract playerInteract;
        
        private void DetermineAction()
        {
            if (!playerInteract.TryInteract())
                attack.TryAttack();
        }
        
        private void OnEnable()
        {
            PlayerInput.Instance.playerAction.AddListener(DetermineAction);
        }
    }
}
