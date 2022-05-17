using System;
using UnityEngine;

namespace WormTomb.Animation
{
    [Serializable]
    [CreateAssetMenu(menuName = MENU + NAME, fileName = NAME)]
    public class SpriteFrame : Frame<Sprite>
    {
        public const string NAME = nameof(SpriteFrame);
    }
}
