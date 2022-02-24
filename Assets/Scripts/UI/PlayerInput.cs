using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace WormTomb
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        public bool IsInputEnabled;
        
        // TODO Remove Input condition for release.
        public bool IsJumpButtonPressed => jumpButton.IsPressed || Input.GetKey(KeyCode.Space) || IsJoystickUp();
        
        // TODO Remove Input condition for release.
        public bool IsAttackButtonPressed => attackButton.IsPressed || Input.GetMouseButton(0);

        // TODO Remove Input condition for release.
        public bool IsLeftButtonPressed => leftButton.IsPressed || Input.GetKey(KeyCode.A) || IsJoystickLeft();

        // TODO Remove Input condition for release.
        public bool IsRightButtonPressed => rightButton.IsPressed || Input.GetKey(KeyCode.D) || IsJoystickRight();

        [NonSerialized] public readonly UnityEvent RunningLeft = new();
        [NonSerialized] public readonly UnityEvent RunningRight = new();
        [NonSerialized] public readonly UnityEvent RunningStop = new();
        [NonSerialized] public readonly UnityEvent Jump = new();
        [NonSerialized] public readonly UnityEvent Attack = new();

        [SerializeField] private CustomButton leftButton;
        [SerializeField] private CustomButton rightButton;
        [SerializeField] private CustomButton jumpButton;
        [SerializeField] private CustomButton attackButton;

        [SerializeField] private Joystick joystick;
        
        private void Update()
        {
            Horizontal();
            Vertical();
        }

        private void Horizontal()
        {
            if (IsJoystickLeft())
                RunningLeft.Invoke();
            else if (IsJoystickRight())
                RunningRight.Invoke();
            else
                RunningStop.Invoke();
        }
        
        private void Vertical()
        {
            if (IsJoystickUp())
                Jump.Invoke();
        }

        private bool IsJoystickRight()
        {
            return joystick.Horizontal > 0f;
        }
        
        private bool IsJoystickLeft()
        {
            return joystick.Horizontal < 0f;
        }
        
        private bool IsJoystickUp()
        {
            return joystick.Vertical > 0f;
        }
        
        private void Awake()
        {
            leftButton.PointerEntered.AddListener(OnLeftButtonEntered);
            leftButton.PointerExited.AddListener(OnRunButtonExited);

            rightButton.PointerEntered.AddListener(OnRightButtonEntered);
            rightButton.PointerExited.AddListener(OnRunButtonExited);

            jumpButton.PointerEntered.AddListener(OnJumpButtonEntered);
            
            attackButton.PointerEntered.AddListener(OnAttackButtonEntered);
        }

        private void OnLeftButtonEntered(PointerEventData eventData)
        {
            RunningLeft.Invoke();
        }

        private void OnRightButtonEntered(PointerEventData eventData)
        {
            RunningRight.Invoke();
        }

        private void OnRunButtonExited(PointerEventData eventData)
        {
            RunningStop.Invoke();
        }

        private void OnJumpButtonEntered(PointerEventData eventData)
        {
            Jump.Invoke();
        }

        private void OnAttackButtonEntered(PointerEventData eventData)
        {
            Attack.Invoke();
        }

        private void OnDestroy()
        {
            RunningLeft.RemoveAllListeners();
            RunningRight.RemoveAllListeners();
            RunningStop.RemoveAllListeners();
            Attack.RemoveAllListeners();
            Jump.RemoveAllListeners();
        }
    }

}