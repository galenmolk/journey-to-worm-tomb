using UnityEngine;

namespace WormTomb
{
    public class FlipSprite : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnEnable()
        {
            PlayerInput.Instance.RunningLeft.AddListener(() => SetIsSpriteFlipped(false));
            PlayerInput.Instance.RunningRight.AddListener(() => SetIsSpriteFlipped(true));
        }

        private void SetIsSpriteFlipped(bool isFlipped)
        {
            spriteRenderer.flipX = isFlipped;
        }
    }
}
