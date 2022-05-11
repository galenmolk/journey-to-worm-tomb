using UnityEngine;

namespace WormTomb.UI
{
    public class MainMenuBindings : MonoBehaviour
    {
        public void PlayButtonClicked()
        {
            Debug.Log("Play Button Clicked!");
            SceneLoader.LoadScene("Level1");
        }
    }
}
