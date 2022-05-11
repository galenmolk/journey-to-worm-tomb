using UnityEngine.SceneManagement;

namespace WormTomb.UI
{
    public static class SceneLoader
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
