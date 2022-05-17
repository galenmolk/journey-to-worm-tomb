using System.Collections;
using UnityEngine;
using WormTomb.General;

namespace WormTomb.Animation
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : CustomAnimator<SpriteState, SpriteFrame, Sprite>
    {
        private SpriteRenderer spriteRenderer;
        
        private IEnumerator Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
            var frames = states[0].Frames;

            while (Application.isPlaying)
            {
                for (int i = 0; i < frames.Length; i++)
                {
                    spriteRenderer.sprite = frames[i].Value;
                    yield return YieldRegistry.WaitForSeconds(0.1f);

                    if (i == frames.Length)
                        i = 0;
                }
            }
            
        }
    }
}
