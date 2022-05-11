using UnityEngine;
using WormTomb.Combat;
using WormTomb.UI;

namespace WormTomb.Player
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
