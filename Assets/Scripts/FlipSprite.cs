using UnityEngine;

namespace WormTomb
{
    public class FlipSprite : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private void OnEnable()
        {
            PlayerInput.Instance.onHorizontalInput.AddListener(SetSpriteFacing);
        }

        private void SetSpriteFacing(float runInput)
        {
            if (runInput == 0)
                return;

            spriteRenderer.flipX = runInput < 0;
        }
    }
}
