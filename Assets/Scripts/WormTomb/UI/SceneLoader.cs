using UnityEngine.SceneManagement;
using WormTomb.General;

namespace WormTomb.UI
{
    public static class SceneLoader
    {
        public static void LoadScene(SceneBinding scene)
        {
            if (scene == null)
                return;
                    
            var name = scene.SceneName;
            if (!string.IsNullOrWhiteSpace(name))
                Load(name);
        }

        private static void Load(string sceneName)
        {
            TransitionFader.Instance.Fade(() =>
            {
                SceneManager.LoadScene(sceneName);
            });
        }
    }
}
