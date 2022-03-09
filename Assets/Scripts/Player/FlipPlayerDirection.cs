using UnityEngine;

namespace WormTomb
{
    public class FlipPlayerDirection : MonoBehaviour
    {
        private readonly Vector3 leftScale = new(-1, 1, 1);
        
        private void OnEnable()
        {
            PlayerInput.Instance.joystickLeft.AddListener(() => SetIsSpriteFlipped(true));
            PlayerInput.Instance.joystickRight.AddListener(() => SetIsSpriteFlipped(false));
        }   

        private void SetIsSpriteFlipped(bool isFlipped)
        {
            transform.localScale = isFlipped ? leftScale : Vector3.one;
        }
    }
}
