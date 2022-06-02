using System.Collections;
using MolkExtras;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using YieldRegistry = WormTomb.General.YieldRegistry;

namespace WormTomb.UI
{
    public class PlayerInput : Singleton<PlayerInput>
    {
        public UnityEvent joystickLeft = new();
        public UnityEvent joystickRight = new();
        public UnityEvent joystickCenterX = new();
        public UnityEvent joystickCenterY = new();
        public UnityEvent joystickUp = new();
        public UnityEvent joystickDown = new();
        public UnityEvent playerAction = new();

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
            
            joystickCenterX.Invoke();
            joystickCenterY.Invoke();
        }

        private IEnumerator ReadJoystickContinuously()
        {
            while (isReadingJoystick)
            {
                ReadVertical();
                ReadHorizontal();
                yield return YieldRegistry.WaitForEndOfFrame;
            }
        }

        private void ReadHorizontal()
        {
            if (joystick.IsLeft)
                joystickLeft.Invoke();
            else if (joystick.IsRight)
                joystickRight.Invoke();
            else
                joystickCenterX.Invoke();
        }

        private void ReadVertical()
        {
            if (joystick.IsUp)
                joystickUp.Invoke();
            else if (joystick.IsDown)
                joystickDown.Invoke();
            else
                joystickCenterY.Invoke();
        }
        
        private void OnActionButtonEntered(PointerEventData eventData)
        {
            Debug.Log("Action Button!");
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
            joystickCenterX.RemoveAllListeners();
            playerAction.RemoveAllListeners();
            joystickUp.RemoveAllListeners();
        }
    }
}
