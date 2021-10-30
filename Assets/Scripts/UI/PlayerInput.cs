using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace WormTomb
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        public bool IsJumpButtonPressed
        {
            get
            {
                // TODO Remove Input condition for release.
                return jumpButton.IsPressed || Input.GetKey(KeyCode.Space);
            }
        }

        public bool IsLeftButtonPressed
        {
            get
            {
                // TODO Remove Input condition for release.
                return leftButton.IsPressed || Input.GetKey(KeyCode.A);
            }
        }

        public bool IsRightButtonPressed
        {
            get
            {
                // TODO Remove Input condition for release.
                return rightButton.IsPressed || Input.GetKey(KeyCode.D);
            }
        }

        [NonSerialized] public UnityEvent RunningLeft = new UnityEvent();
        [NonSerialized] public UnityEvent RunningRight = new UnityEvent();
        [NonSerialized] public UnityEvent RunningStop = new UnityEvent();
        [NonSerialized] public UnityEvent Jump = new UnityEvent();

        [SerializeField] private CustomButton leftButton;
        [SerializeField] private CustomButton rightButton;
        [SerializeField] private CustomButton jumpButton;

        private void Awake()
        {
            leftButton.PointerEntered.AddListener(OnLeftButtonEntered);
            leftButton.PointerExited.AddListener(OnRunButtonExited);

            rightButton.PointerEntered.AddListener(OnRightButtonEntered);
            rightButton.PointerExited.AddListener(OnRunButtonExited);

            jumpButton.PointerEntered.AddListener(OnJumpButtonEntered);
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

        private void OnDestroy()
        {
            RunningLeft.RemoveAllListeners();
            RunningRight.RemoveAllListeners();
            RunningStop.RemoveAllListeners();
            Jump.RemoveAllListeners();
        }
    }

}