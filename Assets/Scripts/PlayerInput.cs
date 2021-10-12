using UnityEngine;
using UnityEngine.InputSystem;

namespace WormTomb
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        public readonly FloatEvent onHorizontalInput = new FloatEvent();
        public readonly FloatEvent onVerticalInput = new FloatEvent();
        
        private PlayerAction playerAction;

        private void Awake()
        {
            playerAction = new PlayerAction();
        }

        private void OnEnable()
        {
            playerAction.Enable();
            playerAction.Player.Move.performed += SetMoveInput;
        }

        private void OnDisable()
        {
            playerAction.Disable();
            onHorizontalInput.RemoveAllListeners();
            onVerticalInput.RemoveAllListeners();
        }

        private void SetMoveInput(InputAction.CallbackContext context)
        {
            onHorizontalInput.Invoke(context.ReadValue<Vector2>().x);
            onVerticalInput.Invoke(context.ReadValue<Vector2>().y);
        }
    }
}
