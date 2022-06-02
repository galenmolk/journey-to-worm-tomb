using UnityEngine;
using WormTomb.Animation;

namespace WormTomb.UI
{
    public class ImageColorAnimator : ColorAnimator
    {
        [SerializeField] private ColorState defaultState;

        private void Awake()
        {
            Play(defaultState);
        }
    }
}
