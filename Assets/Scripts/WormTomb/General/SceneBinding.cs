using UnityEngine;
using WormTomb.Utils;

namespace WormTomb.General
{
    [CreateAssetMenu(fileName = NAME, menuName = MENU_NAME)]
    public class SceneBinding : ScriptableObject
    {
        private const string NAME = nameof(SceneBinding);
        private const string MENU_NAME = GameConsts.CUSTOM_ASSET_MENU + "/" + NAME;

        public string SceneName => sceneName;
        [SerializeField] private string sceneName;
    }
}
