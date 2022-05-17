using System;
using UnityEngine;

namespace WormTomb.Animation
{
    [Serializable]
    [CreateAssetMenu(menuName = MENU + NAME, fileName = NAME)]
    public class SpriteState : State<SpriteFrame, Sprite>
    {
        public const string NAME = nameof(SpriteState);
    }
}
