using System;
using UnityEngine;

namespace WormTomb.Animation
{
    [Serializable]
    [CreateAssetMenu(menuName = MENU + NAME, fileName = NAME)]
    public class ColorState : State<ColorFrame, Color>
    {
        private const string NAME = nameof(ColorState);
    }
}
