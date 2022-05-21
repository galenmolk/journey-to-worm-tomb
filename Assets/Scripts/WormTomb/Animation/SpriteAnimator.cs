using UnityEngine;

namespace WormTomb.Animation
{
    public class SpriteAnimator : CustomAnimator<SpriteState, SpriteFrame, Sprite>
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        protected override void ApplyFrame(SpriteFrame frame)
        {
            spriteRenderer.sprite = frame.Value;
        }

        private void OnValidate()
        {
            if (spriteRenderer == null)
                Debug.LogError($"{nameof(SpriteAnimator)} on {gameObject.name} doesn't have a SpriteRenderer assigned.");
        }
    }
}
