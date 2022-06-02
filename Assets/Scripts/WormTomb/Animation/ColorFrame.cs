using UnityEngine;

namespace WormTomb.Animation
{
    [CreateAssetMenu(menuName = MENU + NAME, fileName = NAME)]
    public class ColorFrame : Frame<Color>
    {
        private const string NAME = nameof(ColorFrame);
    }
}
