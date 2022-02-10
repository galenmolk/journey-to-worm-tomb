using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace WormTomb
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        // TODO Remove Input condition for release.
        public bool IsJumpButtonPressed => jumpButton.IsPressed || Input.GetKey(KeyCode.Space);
        
        // TODO Remove Input condition for release.
        public bool IsAttackButtonPressed => attackButton.IsPressed || Input.GetMouseButton(0);

        // TODO Remove Input condition for release.
        public bool IsLeftButtonPressed => leftButton.IsPressed || Input.GetKey(KeyCode.A);

        // TODO Remove Input condition for release.
        public bool IsRightButtonPressed => rightButton.IsPressed || Input.GetKey(KeyCode.D);

        [NonSerialized] public UnityEvent RunningLeft = new UnityEvent();
        [NonSerialized] public UnityEvent RunningRight = new UnityEvent();
        [NonSerialized] public UnityEvent RunningStop = new UnityEvent();
        [NonSerialized] public UnityEvent Jump = new UnityEvent();
        [NonSerialized] public UnityEvent Attack = new UnityEvent();

        [SerializeField] private CustomButton leftButton;
        [SerializeField] private CustomButton rightButton;
        [SerializeField] private CustomButton jumpButton;
        [SerializeField] private CustomButton attackButton;

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
            Jump.RemoveAllListeners();
        }
    }

}