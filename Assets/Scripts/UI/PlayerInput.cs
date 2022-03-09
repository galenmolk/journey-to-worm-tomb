using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace WormTomb
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        // TODO Remove Input condition for release.
        public bool IsJoystickUp => Input.GetKey(KeyCode.Space) || joystick.IsUp;
        
        // TODO Remove Input condition for release.
        public bool IsJoystickLeft => Input.GetKey(KeyCode.A) || joystick.IsLeft;

        // TODO Remove Input condition for release.
        public bool IsJoystickRight => Input.GetKey(KeyCode.D) || joystick.IsRight;

        [NonSerialized] public readonly UnityEvent joystickLeft = new();
        [NonSerialized] public readonly UnityEvent joystickRight = new();
        [NonSerialized] public readonly UnityEvent joystickCenter = new();
        [NonSerialized] public readonly UnityEvent joystickUp = new();
        [NonSerialized] public readonly UnityEvent playerAction = new();

        [SerializeField] private CustomButton actionButton;

        [SerializeField] private Joystick joystick;

        private bool isReadingJoystick;
        private Coroutine joystickCoroutine;
        
        private void StartReadingJoystick()
        {
            isReadingJoystick = true;
            joystickCoroutine = StartCoroutine(ReadJoystickContinuously());
        }

        private void StopReadingJoystick()
        {
            isReadingJoystick = false;

            if (joystickCoroutine != null)
                StopCoroutine(joystickCoroutine);
            
            joystickCenter.Invoke();
        }

        private IEnumerator ReadJoystickContinuously()
        {
            while (isReadingJoystick)
            {
                if (joystick.IsUp)
                    joystickUp.Invoke();
                
                if (joystick.IsLeft)
                    joystickLeft.Invoke();
                else if (joystick.IsRight)
                    joystickRight.Invoke();
                else
                    joystickCenter.Invoke();
                
                yield return YieldRegistry.WaitForEndOfFrame;
            }
        }
        
        private void OnActionButtonEntered(PointerEventData eventData)
        {
            playerAction.Invoke();
        }
        
        private void Awake()
        {
            actionButton.PointerEntered.AddListener(OnActionButtonEntered);
            joystick.pointerDown.AddListener(StartReadingJoystick);
            joystick.pointerUp.AddListener(StopReadingJoystick);
        }

        private void OnDestroy()
        {
            joystickLeft.RemoveAllListeners();
            joystickRight.RemoveAllListeners();
            joystickCenter.RemoveAllListeners();
            playerAction.RemoveAllListeners();
            joystickUp.RemoveAllListeners();
        }
    }
}
