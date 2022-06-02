using UnityEngine;
using WormTomb.UI;

namespace WormTomb.General
{
    public class SceneLoadBehaviour : MonoBehaviour
    {
        [SerializeField] private SceneBinding scene;

        public void Load()
        {
            SceneLoader.LoadScene(scene);
        }
    }
}
