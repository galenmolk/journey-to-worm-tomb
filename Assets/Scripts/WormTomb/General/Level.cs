using UnityEngine;
using WormTomb.Utils;

namespace WormTomb.General
{
    [CreateAssetMenu(fileName = NAME, menuName = MENU, order = 0)]
    public class Level : SceneBinding
    {
        private const string NAME = nameof(Level);
        private const string MENU = GameConsts.CUSTOM_ASSET_MENU + "/" + NAME;

        public Color ColorOne => colorOne;
        public Color ColorTwo => colorTwo;

        public int Index { get; private set; }
        
        [Header("Level Button Gradient")]
        [SerializeField] private Color colorOne;
        [SerializeField] private Color colorTwo;

        public void SetIndex(int index)
        {
            Index = index;
        }
    }
}
