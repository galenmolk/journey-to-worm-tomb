using UnityEngine;

namespace WormTomb.Animation
{
    [CreateAssetMenu(menuName = MENU + NAME, fileName = NAME)]
    public class SpriteFrame : Frame<Sprite>
    {
        private const string NAME = nameof(SpriteFrame);
    }
}
